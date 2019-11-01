using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Reporting.WinForms;
using System.Drawing.Imaging;
using System.Drawing.Printing;


namespace SlotPOS
{
    public partial class TodayTransTReport : Form
    {
        SlotPOSEntities ctx = new SlotPOSEntities();

        public TodayTransTReport()
        {
            InitializeComponent();
            FillCombo();
        }

        private void FillCombo()
        {
            var getCustomer = (from a in ctx.tblUsers
                               select a).ToList();
            getCustomer.Insert(0, new tblUser { UserID = 0, Username = "-- All --" });
            if (getCustomer.ToList().Count > 0)
            {
                comboBox1.DataSource = getCustomer;
                comboBox1.DisplayMember = "Username";
                comboBox1.ValueMember = "UserID";
            }
        }

        private void BindReport()
        {

            //DateTime dtTo = dtToDate.Value.Date;//.AddDays(1);

            //var BindPRQuery = from a in ctx.tblPOS
            //                  join b in ctx.tblPOSDetails on a.POSID equals b.POSID
            //                  join d in ctx.tblItemCategories on b.ItemCategoryID equals d.ItemCategoryID
            //                  join f in ctx.tblItems on b.ItemID equals f.ItemID
            //                  where a.Status == "Done"
            //                  select new { f.ItemName, a.POSID, b.Quantity, b.Price, b.NetAmount, a.PaymentType, a.SaleDate, a.CounterID};
            //BindPRQuery = BindPRQuery.Where(r => r.SaleDate >= dtFrom && r.SaleDate <= dtTo);
            //if (cmbCounter.SelectedIndex > 0)
            //{
            //    long _counterId = long.Parse(cmbCounter.SelectedValue.ToString());
            //    BindPRQuery = BindPRQuery.Where(n => n.CounterID == _counterId);
            //}
            //if (cmbPaymentType.SelectedIndex > 0)
            //{
            //    string  _paymentType = cmbPaymentType.Text;
            //    BindPRQuery = BindPRQuery.Where(n => n.PaymentType == _paymentType);
            //}
            //if (BindPRQuery.ToList().Count > 0)
            //{
            //    List<ReportParameter> paramList = new List<ReportParameter>();

            //    paramList.Add(new ReportParameter("DateFrom", dtFrom.ToString("dd-MMM-yy"), true));
            //    paramList.Add(new ReportParameter("DateTo", dtTo.ToString("dd-MMM-yy"), true));

            //    if (cmbCounter.SelectedIndex > 0)
            //    {
            //        string _counter = cmbCounter.Text;
            //        paramList.Add(new ReportParameter("Counter", _counter, true));
            //    }
            //    else
            //    {
            //        paramList.Add(new ReportParameter("Counter", "All", true));
            //    }
            //    if (cmbPaymentType.SelectedIndex > 0)
            //    {
            //        string _paymentType = cmbPaymentType.Text;
            //        paramList.Add(new ReportParameter("PaymentMethod", _paymentType, true));
            //    }
            //    else
            //    {
            //        paramList.Add(new ReportParameter("PaymentMethod", "N/A", true));
            //    }
            //SlotDataSetTableAdapters.todayTransactionTableAdapter ad_mis2 = new SlotDataSetTableAdapters.todayTransactionTableAdapter();

            //DataSet ds = new DataSet();
            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("FromDate", dtFromDate.Value.ToShortDateString(), true));
            paramList.Add(new ReportParameter("ToDate", dtToDate.Value.ToShortDateString(), true));
            paramList.Add(new ReportParameter("CounterID", comboBox1.Text, true));


            if (comboBox1.SelectedIndex > 0)
            {
                long _counterId = long.Parse(comboBox1.SelectedValue.ToString());

                //   BindPRQuery = BindPRQuery.Where(n => n.CounterID == _counterId);
            }

            SlotDataSetTableAdapters.todayTransactionTableAdapter ad_mis = new SlotDataSetTableAdapters.todayTransactionTableAdapter();
            SlotDataSetTableAdapters.sp_TodayRechargeAmountTableAdapter tdt = new SlotDataSetTableAdapters.sp_TodayRechargeAmountTableAdapter();
            SlotDataSetTableAdapters.sp_TotalCashSaleTableAdapter dtcash = new SlotDataSetTableAdapters.sp_TotalCashSaleTableAdapter();
            SlotDataSetTableAdapters.sp_TodayCardSaleTableAdapter dtcard = new SlotDataSetTableAdapters.sp_TodayCardSaleTableAdapter();
            SlotDataSetTableAdapters.sp_EntranceTableAdapter dtent = new SlotDataSetTableAdapters.sp_EntranceTableAdapter();
            SlotDataSetTableAdapters.GetDailyActivityReportTableAdapter gridData = new SlotDataSetTableAdapters.GetDailyActivityReportTableAdapter();
            SlotDataSetTableAdapters.sp_CardSaleTableAdapter CardSale = new SlotDataSetTableAdapters.sp_CardSaleTableAdapter();
            SlotDataSetTableAdapters.sp_TotalCashSaleByPaymentTypeTableAdapter dtcashByPayment = new SlotDataSetTableAdapters.sp_TotalCashSaleByPaymentTypeTableAdapter();

            DataSet ds = new DataSet();

            ds.Tables.Add(ad_mis.GetData(dtToDate.Value, dtFromDate.Value));
            ds.Tables.Add(tdt.GetData(dtToDate.Value.Date, dtFromDate.Value.Date, long.Parse(comboBox1.SelectedValue.ToString())));
            ds.Tables.Add(dtcash.GetData(dtToDate.Value, dtFromDate.Value, long.Parse(comboBox1.SelectedValue.ToString())));
            ds.Tables.Add(dtcard.GetData(dtToDate.Value, dtFromDate.Value));
            ds.Tables.Add(dtent.GetData(dtToDate.Value, dtFromDate.Value, long.Parse(comboBox1.SelectedValue.ToString())));
            ds.Tables.Add(gridData.GetData(dtFromDate.Value, dtToDate.Value,long.Parse(comboBox1.SelectedValue.ToString()), 0));
            ds.Tables.Add(CardSale.GetData(dtToDate.Value, dtFromDate.Value, long.Parse(comboBox1.SelectedValue.ToString())));
            ds.Tables.Add(dtcashByPayment.GetData(dtToDate.Value, dtFromDate.Value, long.Parse(comboBox1.SelectedValue.ToString())));

            frmReportViewer rptPurReq = new frmReportViewer();
            rptPurReq.reportViewer1.Visible = true;
            Microsoft.Reporting.WinForms.ReportDataSource datasource1 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[3]);
            Microsoft.Reporting.WinForms.ReportDataSource datasource2 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", ds.Tables[2]);
            Microsoft.Reporting.WinForms.ReportDataSource datasource3 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet3", ds.Tables[0]);
            Microsoft.Reporting.WinForms.ReportDataSource datasource4 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet4", ds.Tables[1]);
            Microsoft.Reporting.WinForms.ReportDataSource datasource5 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet5", ds.Tables[4]);
            Microsoft.Reporting.WinForms.ReportDataSource datasource6 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet6", ds.Tables[5]);
            Microsoft.Reporting.WinForms.ReportDataSource datasource7 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet7", ds.Tables[6]);
            Microsoft.Reporting.WinForms.ReportDataSource datasource8 = new Microsoft.Reporting.WinForms.ReportDataSource("TotalSaleByPaymentMethod", ds.Tables[7]);


            rptPurReq.reportViewer1.LocalReport.DataSources.Clear();
            rptPurReq.reportViewer1.LocalReport.DataSources.Add(datasource1);
            rptPurReq.reportViewer1.LocalReport.DataSources.Add(datasource2);
            rptPurReq.reportViewer1.LocalReport.DataSources.Add(datasource3);
            rptPurReq.reportViewer1.LocalReport.DataSources.Add(datasource4);
            rptPurReq.reportViewer1.LocalReport.DataSources.Add(datasource5);
            rptPurReq.reportViewer1.LocalReport.DataSources.Add(datasource6);
            rptPurReq.reportViewer1.LocalReport.DataSources.Add(datasource7);
            rptPurReq.reportViewer1.LocalReport.DataSources.Add(datasource8);
            using (StreamReader rdlcSR = new StreamReader(@"RdlcReport\SalesReport.rdlc"))
            {
                rptPurReq.reportViewer1.LocalReport.LoadReportDefinition(rdlcSR);
                rptPurReq.reportViewer1.LocalReport.Refresh();
                rptPurReq.reportViewer1.LocalReport.SetParameters(paramList);


            }
            //string exeFolder = (Path.GetDirectoryName(Application.StartupPath)).Substring(0, (Path.GetDirectoryName(Application.StartupPath)).Length - 3);
            //  string reportPath = @"RdlcReport\todayTransReport.rdlc";
            //rptPurReq.reportViewer1.LocalReport.ReportPath = reportPath;

            rptPurReq.reportViewer1.LocalReport.Refresh();
            rptPurReq.ShowDialog();
            // }
            //else
            //    MessageBox.Show("No Record Found!!", "Alert", MessageBoxButtons.OK);
            // }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSalesbyPaymentMethod_Load(object sender, EventArgs e)
        {
            //FillCombo();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            BindReport();
            //  PrintBill();
        }
        private void PrintBill()
        {
            //SlotDataSetTableAdapters.getPrintBillTableAdapter ad_mis = new SlotDataSetTableAdapters.getPrintBillTableAdapter();

            //DataSet ds = new DataSet();
            //ds.Tables.Add(ad_mis.GetData(_posID));

            //ReportDataSource datasource = new ReportDataSource("getPrintBill", ds.Tables[0]);
            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("FromDate", dtFromDate.Value.ToShortDateString(), true));
            paramList.Add(new ReportParameter("ToDate", dtToDate.Value.ToShortDateString(), true));
            SlotDataSetTableAdapters.todayTransactionTableAdapter ad_mis = new SlotDataSetTableAdapters.todayTransactionTableAdapter();
            SlotDataSetTableAdapters.sp_TodayRechargeAmountTableAdapter tdt = new SlotDataSetTableAdapters.sp_TodayRechargeAmountTableAdapter();
            SlotDataSetTableAdapters.sp_TotalCashSaleTableAdapter dtcash = new SlotDataSetTableAdapters.sp_TotalCashSaleTableAdapter();
            SlotDataSetTableAdapters.sp_TodayCardSaleTableAdapter dtcard = new SlotDataSetTableAdapters.sp_TodayCardSaleTableAdapter();
            SlotDataSetTableAdapters.sp_EntranceTableAdapter dtent = new SlotDataSetTableAdapters.sp_EntranceTableAdapter();


            DataSet ds = new DataSet();
            ds.Tables.Add(ad_mis.GetData(dtToDate.Value, dtFromDate.Value));
            ds.Tables.Add(tdt.GetData(dtToDate.Value, dtFromDate.Value, long.Parse(comboBox1.SelectedValue.ToString())));
            ds.Tables.Add(dtcash.GetData(dtToDate.Value, dtFromDate.Value, long.Parse(comboBox1.SelectedValue.ToString())));
            ds.Tables.Add(dtcard.GetData(dtToDate.Value, dtFromDate.Value));
            ds.Tables.Add(dtent.GetData(dtToDate.Value, dtFromDate.Value, long.Parse(comboBox1.SelectedValue.ToString())));

            frmReportViewer rptPurReq = new frmReportViewer();
            rptPurReq.reportViewer1.Visible = true;
            Microsoft.Reporting.WinForms.ReportDataSource datasource1 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[3]);
            Microsoft.Reporting.WinForms.ReportDataSource datasource2 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", ds.Tables[2]);
            Microsoft.Reporting.WinForms.ReportDataSource datasource3 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet3", ds.Tables[0]);
            Microsoft.Reporting.WinForms.ReportDataSource datasource4 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet4", ds.Tables[1]);
            Microsoft.Reporting.WinForms.ReportDataSource datasource5 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet5", ds.Tables[4]);
            Microsoft.Reporting.WinForms.ReportDataSource datasource6 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet5", ds.Tables[5]);
            RunBill(datasource1, datasource2, datasource3, datasource4, datasource5);
        }

        private void RunBill(ReportDataSource datasource1, ReportDataSource datasource2, ReportDataSource datasource3, ReportDataSource datasource4, ReportDataSource datasource5)
        {
            LocalReport report = new LocalReport();
            StreamReader rdlcSR = new StreamReader(@"RdlcReport\SalesReport.rdlc");
            report.LoadReportDefinition(rdlcSR);
            //   report.DataSources.Add(datasource);
            report.DataSources.Add(datasource1);
            report.DataSources.Add(datasource2);
            report.DataSources.Add(datasource3);
            report.DataSources.Add(datasource4);
            report.DataSources.Add(datasource5);
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
    }
}
