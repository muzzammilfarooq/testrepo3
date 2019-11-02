using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Microsoft.Reporting;
using Microsoft.Reporting.WinForms;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using SlotPOS.Class;

namespace SlotPOS
{
    public partial class frmPaymentMode : Form
    {
        SlotPOSEntities ctx = new SlotPOSEntities();
        List<string> rfidCodeList = new List<string>();
        string rfid_code = string.Empty;
        decimal RecharcgeAmount = 0;
        decimal promotionAmount = 0;
        long promotionCatId;
        public frmPaymentMode()
        {
            InitializeComponent();
        }

        public frmPaymentMode(long _posId, decimal _totalAmount, string rfidCode, decimal _RechAmnt, List<string> rfidList, decimal promotions, long promotionCatId)
        {
            InitializeComponent();
            lblPOSID.Text = _posId.ToString();
            lblTotalAmount.Text = _totalAmount.ToString();
            txtRecAmount.Text = _totalAmount.ToString();
            rfidCodeList = rfidList;
            RecharcgeAmount = _RechAmnt;
            txtBalanceAmount.Text = "0";
            Class.clsGlobalVar.IsPaymentDone = false;
            rfid_code = rfidCode;
            this.promotionCatId = promotionCatId;
            promotionAmount = promotions;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintBill(long _posID)
        {
            SlotDataSetTableAdapters.getPrintBillTableAdapter ad_mis = new SlotDataSetTableAdapters.getPrintBillTableAdapter();
            SlotDataSetTableAdapters.getPrintBillCardTableAdapter ad_mis1 = new SlotDataSetTableAdapters.getPrintBillCardTableAdapter();

            DataSet ds = new DataSet();
            ds.Tables.Add(ad_mis.GetData(_posID));
            ds.Tables.Add(ad_mis1.GetData(_posID));
            ReportDataSource datasource = new ReportDataSource("getPrintBill", ds.Tables[0]);
            ReportDataSource datasource1 = new ReportDataSource("getPrintBillCard", ds.Tables[1]);
            RunBill(datasource, datasource1);
        }
        private void PrintBillCard(long _posID)
        {
            SlotDataSetTableAdapters.getPrintBillCardTableAdapter ad_mis = new SlotDataSetTableAdapters.getPrintBillCardTableAdapter();

            DataSet ds = new DataSet();
            ds.Tables.Add(ad_mis.GetData(_posID));

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
            RunBillCard(datasource);
        }
        private void PrintBillItem(long _posDetailID)
        {
            SlotDataSetTableAdapters.sp_getPrintBillItemTableAdapter ad_mis = new SlotDataSetTableAdapters.sp_getPrintBillItemTableAdapter();

            DataSet ds = new DataSet();
            ds.Tables.Add(ad_mis.GetData(_posDetailID));

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
            RunBillItem(datasource);

        }
        private void RunBillCard(ReportDataSource datasource)
        {
            LocalReport report = new LocalReport();
            StreamReader rdlcSR = new StreamReader(@"RdlcReport\CardAmountSlip.rdlc");
            report.LoadReportDefinition(rdlcSR);
            report.DataSources.Add(datasource);
            Export(report);
            m_currentPageIndex = 0;
            Print(1);
        }
        private void RunBillItem(ReportDataSource datasource)
        {
            LocalReport report = new LocalReport();
            StreamReader rdlcSR = new StreamReader(@"RdlcReport\ItemSlip.rdlc");
            report.LoadReportDefinition(rdlcSR);
            report.DataSources.Add(datasource);
            Export(report);
            m_currentPageIndex = 0;
            Print(1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            int RecAmount = txtRecAmount.Text == "" ? 0 : int.Parse(txtRecAmount.Text);
            int TotalAmount = lblTotalAmount.Text == "" ? 0 : int.Parse(lblTotalAmount.Text);



            if (RecAmount < TotalAmount && chkDiscount.Checked==false)
            {
                MessageBox.Show("Received Amount is less than Total Amount!!", "Error", MessageBoxButtons.OK);
                //txtQty.Focus();
                return;
            }
            if (rbtnCash.Checked == false && rbtnCreditCard.Checked == false)
            {
                MessageBox.Show("Please Select Payment Mode!!", "Error", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Are you sure you want to Add New Record", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                long PosId = long.Parse(lblPOSID.Text);
                using (SlotPOSEntities ctx1 = new SlotPOSEntities())
                {
                    if (!clsGlobalVar.IsMasterCard)
                    {

                        var updateRecord = (from a in ctx1.tblPOS
                                            where a.POSID == PosId && a.Status == "Pending"
                                            select a).SingleOrDefault();

                        if (updateRecord != null)
                        {
                            
                            updateRecord.PaymentType = rbtnCash.Checked == true ? "Cash" : rbtnCreditCard.Checked == true ? "Credit Card" : "";
                           // updateRecord.Status = "Done";
                            updateRecord.PaidAmount = txtRecAmount.Text;
                            updateRecord.BalanceAmount = txtBalanceAmount.Text;
                            updateRecord.NetAmount = lblNetAmount.Text;
                            //Discount changes Start===============================================
                            if (chkDiscount.Checked)
                            {
                                updateRecord.DiscountID = Convert.ToInt32(lblDiscountID.Text);
                                updateRecord.DiscountPer = Convert.ToDecimal(txtDiscountPer.Text);
                                updateRecord.DiscountAmount = Convert.ToDecimal(lblDiscounted.Text);
                                updateRecord.IsDiscount = true;
                                

                            }

                            //Discount changes END===============================================
                            // ctx1.SaveChanges();
                            string cardType = "";



                            if (rfid_code != "" && rfid_code != null && rfid_code != "No Card" && RecAmount > 0 || promotionAmount > 0)
                            {
                                try
                                {
                                    tblRFID obj_rfid = new tblRFID();
                                    obj_rfid = ctx1.tblRFIDs.Where(t => t.RFIDCode == rfid_code).FirstOrDefault();
                                    bool? isMaster = obj_rfid.IsMaster;
                                    cardType = obj_rfid.CardType;
                                    obj_rfid.Amount = obj_rfid.Amount + RecharcgeAmount + promotionAmount;
                                    obj_rfid.UpdateDateTime = DateTime.Now;

                                    //================Promotions===============
                                    if (promotionAmount > 0)
                                    {

                                        tblPromotion promotions = new tblPromotion();
                                        promotions.Amount = promotionAmount;
                                        promotions.InsertedDateTime = DateTime.Now;
                                        promotions.SaleDate = clsGlobalVar.SaleDate;
                                        promotions.RfidId = obj_rfid.Id;
                                        promotions.RfidCode = obj_rfid.RFIDCode;
                                        promotions.POSId = PosId;
                                        promotions.PromotionCategoryId = promotionCatId;
                                        ctx1.AddTotblPromotions(promotions);

                                    }
                                    //=======================================
                                    // ctx1.SaveChanges();



                                    //MessageBox.Show("Amount --> "+obj_rfid.Amount);

                                    //// ctx.AcceptAllChanges();

                                    //========New work date feb/6/2018=================
                                    if (cardType != "Member" && obj_rfid.IsRFIDWatch != true)
                                    {
                                        tblNewCard obj_newCard = new tblNewCard();
                                        obj_newCard = ctx1.tblNewCards.Where(t => t.RfidCode == rfid_code).FirstOrDefault();
                                        if (obj_newCard.Status == "Pending")
                                        {
                                            obj_newCard.CardAmount = clsGlobalVar.NewCardAmount;
                                            obj_newCard.FirstBalance = clsGlobalVar.BasicCardAmount;
                                            obj_newCard.DateTime = DateTime.Now;
                                            obj_newCard.RfidCode = rfid_code;
                                            obj_newCard.Status = "Done";
                                            obj_newCard.SaleDate = clsGlobalVar.SaleDate;
                                            obj_newCard.POSID = PosId;
                                            //     ctx1.SaveChanges();
                                            //// ctx.AcceptAllChanges();

                                        }
                                    }

                                    tblRechargeAmount Obj_RechargeAmount = new tblRechargeAmount();
                                    Obj_RechargeAmount.RfidCode = rfid_code;
                                    Obj_RechargeAmount.RechargeAmount = RecharcgeAmount;
                                    Obj_RechargeAmount.SaleDate = clsGlobalVar.SaleDate;
                                    Obj_RechargeAmount.DateTime = DateTime.Now;
                                    Obj_RechargeAmount.POSID = PosId;
                                    //=================add master code code Feb-8-2018=============


                                    Obj_RechargeAmount.IsMaster = false;

                                    //============================================================

                                    ctx1.AddTotblRechargeAmounts(Obj_RechargeAmount);
                                   // ctx1.SaveChanges();
                                    // ctx.AcceptAllChanges();
                                    //===============================================
                                    updateRecord.Status = "Done";
                                    //if (RecharcgeAmount > 0)
                                    //    PrintBillCard(PosId);
                                }
                                catch
                                {

                                    //updateRecord.Status = "Pending";
                                    MessageBox.Show("Something went wrorng ,Please re-enter order again");
                                    this.Close();
                                    return;
                                }
                            }
                           
                           

                          
                            var getPrint = (from a in ctx.tblPOSDetails
                                            where a.POSID == PosId
                                            select new { a.POSDetail }).Distinct();


                            if (getPrint != null && updateRecord.Status != "Done")
                            {
                                updateRecord.Status = "Done";
                                
                            }

                            if (updateRecord.Status == "Done")
                            {
                                ctx1.SaveChanges();
                                if (RecharcgeAmount > 0)
                                    PrintBillCard(PosId);
                                if (getPrint != null)
                                {
                                    for (int i = 0; i < rfidCodeList.Count; i++)
                                    {
                                        string strcode = rfidCodeList[i];
                                        tblRFID tblRfids = ctx.tblRFIDs.FirstOrDefault(t => t.RFIDCode == strcode);
                                        if (tblRfids != null)
                                        {
                                            tblRfids.IsActive = true;
                                            ctx.SaveChanges();
                                        }
                                    }

                                    foreach (var print in getPrint)
                                    {
                                        long POSIDDetail = long.Parse(print.POSDetail.ToString());
                                        PrintBillItem(POSIDDetail);
                                    }
                                }                             
                                PrintBill(PosId);
                                Class.clsGlobalVar.IsPaymentDone = true;
                                this.Close();
                            }
                            else
                            {

                                //updateRecord.Status = "Pending";
                                MessageBox.Show("Something went wrorng ,Please re-enter order again");
                                this.Close();
                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Something went wrorng ,Please re-enter order again");
                            this.Close();
                            return;
                           // MessageBox.Show("Something went wrorng, please close payment form and re-enter Close order button");
                        }
                    }
                    else
                    {
                        try
                        {
                            //========New work date feb/6/2018=================
                            tblNewCard obj_newCard = new tblNewCard();
                            obj_newCard = ctx1.tblNewCards.Where(t => t.RfidCode == rfid_code).FirstOrDefault();
                            if (obj_newCard.Status == "Pending")
                            {
                                obj_newCard.CardAmount = 0;
                                obj_newCard.FirstBalance = 0;
                                obj_newCard.DateTime = DateTime.Now;
                                obj_newCard.RfidCode = rfid_code;
                                obj_newCard.Status = "Done";
                                obj_newCard.SaleDate = clsGlobalVar.SaleDate;
                                ctx1.SaveChanges();
                                //  ctx.AcceptAllChanges();

                            }
                        }
                        catch
                        {
                        }

                        tblRechargeAmount Obj_RechargeAmount = new tblRechargeAmount();
                        Obj_RechargeAmount.RfidCode = rfid_code;
                        Obj_RechargeAmount.RechargeAmount = RecharcgeAmount;
                        Obj_RechargeAmount.DateTime = DateTime.Now;

                        //=================add master code code Feb-8-2018=============

                        Obj_RechargeAmount.DateTime = DateTime.Now;
                        Obj_RechargeAmount.IsMaster = true;
                        Obj_RechargeAmount.SaleDate = clsGlobalVar.SaleDate;
                        //============================================================

                        ctx1.AddTotblRechargeAmounts(Obj_RechargeAmount);
                        ctx1.SaveChanges();
                        // ctx.AcceptAllChanges();
                        //===============================================

                        //MessageBox.Show("Record has been successfully updated");
                        tblRFID obj_rfid = new tblRFID();
                        obj_rfid = ctx1.tblRFIDs.Where(t => t.RFIDCode == rfid_code).FirstOrDefault();
                        bool? isMaster = obj_rfid.IsMaster;
                        obj_rfid.Amount = obj_rfid.Amount + RecharcgeAmount;
                        obj_rfid.UpdateDateTime = DateTime.Now;
                        ctx1.SaveChanges();

                        PrintBill(PosId);

                        Class.clsGlobalVar.IsPaymentDone = true;
                        this.Close();
                    }
                }//using ctx1 end bracket
            }
        }

        private void txtRecAmount_TextChanged(object sender, EventArgs e)
        {
            if (!txtRecAmount.Text.All(d => Char.IsNumber(d)))
            {
                MessageBox.Show("Please enter only numeric values!!", "Slot POS System", MessageBoxButtons.OK);
            }
            else
            {
                decimal _amount = lblTotalAmount.Text == "" ? 0 : decimal.Parse(lblTotalAmount.Text);
                decimal _recAmount = txtRecAmount.Text == "" ? 0 : decimal.Parse(txtRecAmount.Text);
                decimal _balance = _recAmount - _amount;

                txtBalanceAmount.Text = _balance.ToString();
                if (chkDiscount.Checked)
                {
                    decimal _amount1 = lblNetAmount.Text == "" ? 0 : decimal.Parse(lblNetAmount.Text);
                    decimal _recAmount1 = txtRecAmount.Text == "" ? 0 : decimal.Parse(txtRecAmount.Text);
                    decimal _balance1 = _recAmount1 - _amount1;
                    txtBalanceAmount.Text = _balance1.ToString();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtnCash_CheckedChanged(object sender, EventArgs e)
        {
            lblPaymentMode.Text = "Cash";
            txtRecAmount.ReadOnly = false;
            txtRecAmount.Focus();
        }

        private void rbtnCreditCard_CheckedChanged(object sender, EventArgs e)
        {
            lblPaymentMode.Text = "Credit Card";
            txtRecAmount.ReadOnly = true;
            txtRecAmount.Focus();
        }

        private void txtRecAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                int RecAmount = txtRecAmount.Text == "" ? 0 : int.Parse(txtRecAmount.Text);
                int TotalAmount = lblTotalAmount.Text == "" ? 0 : int.Parse(lblTotalAmount.Text);



                if (RecAmount < TotalAmount)
                {
                    MessageBox.Show("Received Amount is less than Total Amount!!", "Error", MessageBoxButtons.OK);
                    //txtQty.Focus();
                    return;
                }
                if (rbtnCash.Checked == false && rbtnCreditCard.Checked == false)
                {
                    MessageBox.Show("Please Select Payment Mode!!", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to Add New Record", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    long PosId = long.Parse(lblPOSID.Text);
                    using (SlotPOSEntities ctx1 = new SlotPOSEntities())
                    {
                        if (!clsGlobalVar.IsMasterCard)
                        {

                            var updateRecord = (from a in ctx1.tblPOS
                                                where a.POSID == PosId && a.Status == "Pending"
                                                select a).SingleOrDefault();

                            if (updateRecord != null)
                            {
                                updateRecord.PaymentType = rbtnCash.Checked == true ? "Cash" : rbtnCreditCard.Checked == true ? "Credit Card" : "";
                                // updateRecord.Status = "Done";
                                updateRecord.PaidAmount = txtRecAmount.Text;
                                updateRecord.BalanceAmount = txtBalanceAmount.Text;
                                // ctx1.SaveChanges();
                                string cardType = "";



                                if (rfid_code != "" && rfid_code != null && rfid_code != "No Card" && RecAmount > 0 || promotionAmount > 0)
                                {
                                    try
                                    {
                                        tblRFID obj_rfid = new tblRFID();
                                        obj_rfid = ctx1.tblRFIDs.Where(t => t.RFIDCode == rfid_code).FirstOrDefault();
                                        bool? isMaster = obj_rfid.IsMaster;
                                        cardType = obj_rfid.CardType;
                                        obj_rfid.Amount = obj_rfid.Amount + RecharcgeAmount + promotionAmount;
                                        obj_rfid.UpdateDateTime = DateTime.Now;

                                        //================Promotions===============
                                        if (promotionAmount > 0)
                                        {

                                            tblPromotion promotions = new tblPromotion();
                                            promotions.Amount = promotionAmount;
                                            promotions.InsertedDateTime = DateTime.Now;
                                            promotions.SaleDate = clsGlobalVar.SaleDate;
                                            promotions.RfidId = obj_rfid.Id;
                                            promotions.RfidCode = obj_rfid.RFIDCode;
                                            promotions.POSId = PosId;
                                            promotions.PromotionCategoryId = promotionCatId;
                                            ctx1.AddTotblPromotions(promotions);

                                        }
                                        //=======================================
                                        // ctx1.SaveChanges();



                                        //MessageBox.Show("Amount --> "+obj_rfid.Amount);

                                        //// ctx.AcceptAllChanges();

                                        //========New work date feb/6/2018=================
                                        if (cardType != "Member" && obj_rfid.IsRFIDWatch != true)
                                        {
                                            tblNewCard obj_newCard = new tblNewCard();
                                            obj_newCard = ctx1.tblNewCards.Where(t => t.RfidCode == rfid_code).FirstOrDefault();
                                            if (obj_newCard.Status == "Pending")
                                            {
                                                obj_newCard.CardAmount = clsGlobalVar.NewCardAmount;
                                                obj_newCard.FirstBalance = clsGlobalVar.BasicCardAmount;
                                                obj_newCard.DateTime = DateTime.Now;
                                                obj_newCard.RfidCode = rfid_code;
                                                obj_newCard.Status = "Done";
                                                obj_newCard.SaleDate = clsGlobalVar.SaleDate;
                                                obj_newCard.POSID = PosId;
                                                //     ctx1.SaveChanges();
                                                //// ctx.AcceptAllChanges();

                                            }
                                        }

                                        tblRechargeAmount Obj_RechargeAmount = new tblRechargeAmount();
                                        Obj_RechargeAmount.RfidCode = rfid_code;
                                        Obj_RechargeAmount.RechargeAmount = RecharcgeAmount;
                                        Obj_RechargeAmount.SaleDate = clsGlobalVar.SaleDate;
                                        Obj_RechargeAmount.DateTime = DateTime.Now;
                                        Obj_RechargeAmount.POSID = PosId;
                                        //=================add master code code Feb-8-2018=============


                                        Obj_RechargeAmount.IsMaster = false;

                                        //============================================================

                                        ctx1.AddTotblRechargeAmounts(Obj_RechargeAmount);
                                        // ctx1.SaveChanges();
                                        // ctx.AcceptAllChanges();
                                        //===============================================
                                        updateRecord.Status = "Done";
                                        //if (RecharcgeAmount > 0)
                                        //    PrintBillCard(PosId);
                                    }
                                    catch
                                    {

                                        //updateRecord.Status = "Pending";
                                        MessageBox.Show("Something went wrorng ,Please re-enter order again");
                                        this.Close();
                                        return;
                                    }
                                }

                              


                                var getPrint = (from a in ctx.tblPOSDetails
                                                where a.POSID == PosId
                                                select new { a.POSDetail }).Distinct();


                                if (getPrint != null && updateRecord.Status != "Done")
                                {
                                    updateRecord.Status = "Done";

                                }

                                if (updateRecord.Status == "Done")
                                {
                                    ctx1.SaveChanges();
                                    if (RecharcgeAmount > 0)
                                        PrintBillCard(PosId);
                                    if (getPrint != null)
                                    {

                                        for (int i = 0; i < rfidCodeList.Count; i++)
                                        {
                                            string strcode = rfidCodeList[i];
                                            tblRFID tblRfids = ctx.tblRFIDs.FirstOrDefault(t => t.RFIDCode == strcode);
                                            if (tblRfids != null)
                                            {
                                                tblRfids.IsActive = true;
                                                ctx.SaveChanges();
                                            }
                                        }

                                        foreach (var print in getPrint)
                                        {
                                            long POSIDDetail = long.Parse(print.POSDetail.ToString());
                                            PrintBillItem(POSIDDetail);
                                        }
                                    }
                                    PrintBill(PosId);
                                    Class.clsGlobalVar.IsPaymentDone = true;
                                    this.Close();
                                }
                                else
                                {

                                    //updateRecord.Status = "Pending";
                                    MessageBox.Show("Something went wrorng ,Please re-enter order again");
                                    this.Close();
                                    return;
                                }

                            }
                            else
                            {
                                MessageBox.Show("Something went wrorng ,Please re-enter order again");
                                this.Close();
                                return;
                                // MessageBox.Show("Something went wrorng, please close payment form and re-enter Close order button");
                            }
                        }
                        else
                        {
                            try
                            {
                                //========New work date feb/6/2018=================
                                tblNewCard obj_newCard = new tblNewCard();
                                obj_newCard = ctx1.tblNewCards.Where(t => t.RfidCode == rfid_code).FirstOrDefault();
                                if (obj_newCard.Status == "Pending")
                                {
                                    obj_newCard.CardAmount = 0;
                                    obj_newCard.FirstBalance = 0;
                                    obj_newCard.DateTime = DateTime.Now;
                                    obj_newCard.RfidCode = rfid_code;
                                    obj_newCard.Status = "Done";
                                    obj_newCard.SaleDate = clsGlobalVar.SaleDate;
                                    ctx1.SaveChanges();
                                    //  ctx.AcceptAllChanges();

                                }
                            }
                            catch
                            {
                            }

                            tblRechargeAmount Obj_RechargeAmount = new tblRechargeAmount();
                            Obj_RechargeAmount.RfidCode = rfid_code;
                            Obj_RechargeAmount.RechargeAmount = RecharcgeAmount;
                            Obj_RechargeAmount.DateTime = DateTime.Now;

                            //=================add master code code Feb-8-2018=============

                            Obj_RechargeAmount.DateTime = DateTime.Now;
                            Obj_RechargeAmount.IsMaster = true;
                            Obj_RechargeAmount.SaleDate = clsGlobalVar.SaleDate;
                            //============================================================

                            ctx1.AddTotblRechargeAmounts(Obj_RechargeAmount);
                            ctx1.SaveChanges();
                            // ctx.AcceptAllChanges();
                            //===============================================

                            //MessageBox.Show("Record has been successfully updated");
                            tblRFID obj_rfid = new tblRFID();
                            obj_rfid = ctx1.tblRFIDs.Where(t => t.RFIDCode == rfid_code).FirstOrDefault();
                            bool? isMaster = obj_rfid.IsMaster;
                            obj_rfid.Amount = obj_rfid.Amount + RecharcgeAmount;
                            obj_rfid.UpdateDateTime = DateTime.Now;
                            ctx1.SaveChanges();

                            PrintBill(PosId);

                            Class.clsGlobalVar.IsPaymentDone = true;
                            this.Close();
                        }
                    }//using ctx1 end bracket
                }
            }
        }




        private void RunBill(ReportDataSource datasource,ReportDataSource datasource1)
        {
            ReportParameter parameters = new ReportParameter();
            LocalReport report = new LocalReport();
            StreamReader rdlcSR = new StreamReader(@"RdlcReport\rptPrintBill.rdlc");
            report.LoadReportDefinition(rdlcSR);
            parameters = new ReportParameter("RFIDCode", rfid_code);
            report.SetParameters(parameters);
            report.DataSources.Add(datasource);
            report.DataSources.Add(datasource1);
            Export(report);
            m_currentPageIndex = 0;
            Print(1);
        }

        private void Print(short pages)
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.Copies = pages;
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }
      
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }


        private Stream CreateStream(string name,
        string fileNameExtension, Encoding encoding,
        string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8cm</PageWidth>
                <PageHeight>29.7cm</PageHeight>
                <MarginTop>0.2cm</MarginTop>
                <MarginLeft>0.2cm</MarginLeft>
                <MarginRight>0.2cm</MarginRight>
                <MarginBottom>0.2cm</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);


            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);


            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);


            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);


            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void frmPaymentMode_Load(object sender, EventArgs e)
        {
            //rbtnCash_CheckedChanged(null, null);
            lblNetAmount.Text = lblTotalAmount.Text;
        }

        private void txtRecAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//&& (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void txtCompanyCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtCompanyCode.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var CheckCompanyCode = (from a in ctx.tblDiscounts
                                           where a.CompanyCode == txtCompanyCode.Text
                                           select a).SingleOrDefault();
                    if (CheckCompanyCode!= null)
                    {
                        lblDiscountID.Text = (CheckCompanyCode.id).ToString();
                        txtCompanyName.Text = CheckCompanyCode.Company;
                        txtDiscountPer.Text = (CheckCompanyCode.DiscountPER).ToString();
                        txtCardType.Text = CheckCompanyCode.CardType;
                    }
                    else
                    {
                        MessageBox.Show("Code Not Valid","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        txtCompanyName.Text = "";
                        txtDiscountPer.Text = "";
                    }
                }
            }
          
        }

        private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            txtCompanyCode.Text = "";
            txtCompanyName.Text = "";
            txtDiscountPer.Text = "";
            txtCardType.Text = "";
            lblDiscountID.Text = "";
            if (chkDiscount.Checked)
            {
                GRBDiscount.Enabled = true;
                txtCompanyCode.Focus();
            }
            else
            {
                GRBDiscount.Enabled = false;
                lblDiscounted.Text = "0";
                lblNetAmount.Text = lblTotalAmount.Text;
                txtRecAmount.Text = lblTotalAmount.Text;
            }
        }

        private void txtDiscountPer_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscountPer.Text!= "")
            {
               
                lblDiscounted.Text = (Convert.ToDecimal(lblTotalAmount.Text)* Convert.ToDecimal(txtDiscountPer.Text)/100).ToString();
                lblNetAmount.Text = (Convert.ToDecimal(lblTotalAmount.Text)-(Convert.ToDecimal(lblDiscounted.Text))).ToString();
                txtRecAmount.Text = lblNetAmount.Text;
            }
        }
    }
}
