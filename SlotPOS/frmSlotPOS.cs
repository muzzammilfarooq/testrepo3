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
using System.Data.Objects.SqlClient;
using SlotPOS.Class;

namespace SlotPOS
{
    public partial class frmSlotPOS : Form
    {
        public static int x1;
        public static int y1;
        //public static int x2;
        public static int ii;
        public static int xx;
        public static int xc;
        string portname = "";
        float? TotalAmount = 0;
        del MyDlg;
        del1 thisDel;
        delegate void del1();
        delegate void del(string rfidCode);
        string rfid_code { get; set; }
        long POS_ID { get; set; }
        bool isMaster = false;
        bool watchAdd = false;
        long promotionCatId = 0;
        long ItemID;
        decimal promotions = 0;
        List<string> rfidList = new List<string>();

        SlotPOSEntities ctx = new SlotPOSEntities();

        public frmSlotPOS()
        {
            InitializeComponent();
        }
        public frmSlotPOS(string portnm)
        {
            InitializeComponent();
            portname = portnm;
            //lblA.Text = "000";
            //lblB.Text = "000";
            MyDlg = new del(GetCardCode);
            thisDel = new del1(sp_catch);
            serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
        }

        private void getUserDetail(long _userId)
        {
            var getUser = (from a in ctx.tblUsers
                           join b in ctx.tblCounters on a.CounterID equals b.CounterID
                           where a.UserID == _userId
                           select new { a.UserID, a.CounterID, b.CounterName, a.Username, a.IsPrint }).SingleOrDefault();
            if (getUser != null)
            {
                lblCounter.Text = getUser.CounterName;
                lblUsername.Text = getUser.Username;

                if (getUser.IsPrint == true)
                {
                    txtTransID.ReadOnly = false;
                    btnRefresh.Visible = true;
                }
                else
                {
                    txtTransID.ReadOnly = true;
                    btnRefresh.Visible = false;
                }
            }
            else
            {
                lblCounter.Text = "N/A";
                lblUsername.Text = "N/A";
            }
        }

        private void getLatestPOSID()
        {
            SlotPOSEntities ctx1 = new SlotPOSEntities();
            var getLastRecord = (from a in ctx1.tblPOS
                                 orderby a.POSID descending
                                 select a).Take(1).SingleOrDefault();
            if (getLastRecord != null)
            {
                long last = getLastRecord.POSID + 1;
                txtTransID.Text = last.ToString();
            }
            else
            {
                txtTransID.Text = "1";
            }

        }

        private void GetOpeningDate()
        {
            var getOpeningQuery = (from a in ctx.tblOpeningClosings
                                   where a.ClosingDate == null
                                   orderby a.OpeningClosingID descending
                                   select a).Take(1).SingleOrDefault();
            if (getOpeningQuery != null)
            {
                if (getOpeningQuery.ClosingDate.ToString() == "" && getOpeningQuery.OpeningDate.ToString() != "")
                {
                    lblSaleDate.Text = getOpeningQuery.OpeningDate.ToString("dd-MMM-yy");
                    clsGlobalVar.SaleDate = Convert.ToDateTime(lblSaleDate.Text);
                    //lblStatus.Text = "Day Open";
                    //lnkLabelClose.Visible = true;
                }
                else
                {
                    frmDayOpenClose closing = new frmDayOpenClose();
                    closing.ShowDialog();
                    this.Close();
                    //lblStatus.Text = "Day Closed";
                    //label1.Visible = false;
                }
            }
            else
            {
                frmDayOpenClose closing = new frmDayOpenClose();
                closing.ShowDialog();
                this.Close();
                //lblStatus.Text = "Day Closed";
                label1.Visible = false;
            }
        }

        private void ClearFields()
        {

            //==========27-oct-2018 escap btn code====

            lblCardType.Text = "";
            ItemID = 0;
            lblTotalAmount.Text = "0";
            lblTopUpAmount.Text = "0";
            lblWristBandItem.Text = "Not Selected";
            lblBalance.Text = "";
            lblError.Visible = false;
            lblTicketIssueID.Text = "";
            lblSlotItemCount.Text = "";
            txtInHand.Text = "";
            txtSoldOut.Text = "";         
            txtRemainingTickets.Text = "";
            lblSlotItemCount.Text = "";
            dgvPOS.Rows.Clear();
            getLatestPOSID();
            DisableControls(this);
            EnableControl(lblError);
            EnableControl(txtMobileNumber);
            EnableControl(pictureBox2);
            EnableControl(lblWatchItem);
            txtItemCount.Text = string.Empty;
            txtMobileNumber.Text = string.Empty;
            TotalAmount = 0;
            lblMemberAmount.Text = "";
            panel2.Controls.Clear();
            EnableControl(lblWristBandItem);
            EnableControl(label7);
            EnableControl(label2);
            EnableControl(lblTotalAmount);
            EnableControl(btnRemoveItem);
            EnableControl(panel1);
            EnableControl(panel2);
            EnableControlsDiscreate(panel1);
            EnableControl(btnCloseOrder);
            EnableControl(dgvPOS);
            EnableControl(btnRemoveWatch);
            btnAddWatch_Click(null, null);
            txtMobileNumber.Focus();
            rfidList.RemoveRange(0, rfidList.Count);
            clsGlobalVar.IsMasterCard = false;
            lblPromotionAmount.Text = "0";
            serialPort1.Close();
            serialPort1.Open();
            promotionCatId = 0;






            //=====================================



            //txtInHand.Text = "";
            //txtSoldOut.Text = "";
            ////lblCardType.Text = "";
            //txtRemainingTickets.Text = "";
            //lblTotalAmount.Text = "0";
            //lblTopUpAmount.Text = "0";
            //lblTicketIssueID.Text = "";
            //lblSlotItemCount.Text = "";
            //lblBalance.Text = "";
            //lblCardType.Text = "";
            clsGlobalVar.IsNewCard = false;
            //clsGlobalVar.IsMasterCard = false;

           // dgvPOS.Rows.Clear();

            //serialPort1.Close();
            //serialPort1.Open();

        }

        private void createItemCateogryButton()
        {
            //var getCategory = from a in ctx.tblItemCategories
            //                  where a.IsActive == true
            //                  select a;
            var getCategory = from a in ctx.tblItemCategories
                              join b in ctx.tblUserItemCategories on a.ItemCategoryID equals b.categoryID
                              join c in ctx.tblUsers on clsGlobalVar.UserID equals  c.UserID
                              
                              where a.IsActive == true && b.IsActive == true && b.IsActive == true && b.UserID == clsGlobalVar.UserID
                              select a;

            if (getCategory.ToList().Count > 0)
            {
                foreach (var cat in getCategory)
                {
                    Button btn = new Button();
                    btn.Name = cat.ItemCategoryID.ToString();
                    btn.Location = new Point(x1, y1);
                    btn.Height = 100;
                    btn.Width = 100;
                    btn.BackColor = System.Drawing.Color.DarkRed;
                    btn.Text = cat.ItemCategory;
                    btn.Click += new EventHandler(btn_Click);
                    panel1.Controls.Add(btn);
                    if (x1 < 400)
                    {
                        x1 += 110;
                    }
                    else
                    {
                        x1 = 0;
                        y1 += 110;
                    }
                }
            }


        }

        void btn_Click(object sender, EventArgs e)
        {
            int len = sender.ToString().Length;
            var button = sender as Button;

            if (button != null)
            {
                panel2.Controls.Clear();
                ii = 0;
                xx = 0;


                long itemCategoryId = long.Parse(button.Name.ToString());
                var getCat = (from a in ctx.tblItemCategories
                              where a.ItemCategoryID == itemCategoryId && a.IsSlotCategory == true && a.IsActive==true
                              select a).SingleOrDefault();
              
                if (getCat != null)
                {
                  
                    getQtyInHand(long.Parse(itemCategoryId.ToString()));
                    lblCategoryID.Text = getCat.ItemCategoryID.ToString();

                    if (lblTicketIssueID.Text == "" && txtInHand.Text == "" && txtSoldOut.Text == "" && txtRemainingTickets.Text == "")
                    {
                        MessageBox.Show("Please Assign Ticket(s) to this Category in order to Sale", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bool check = CheckStockAvailability();
                    if (check == false)
                        return;


                    //bool stockCheck = checkStock();
                    //if (stockCheck == false)
                    //    return;
                }
                else
                {
                    txtInHand.Text = "";
                    txtSoldOut.Text = "";
                    txtRemainingTickets.Text = "";
                    lblTicketIssueID.Text = "";
                    lblCategoryID.Text = "";
                }


                var checkPromotionCat = (from a in ctx.tblItemCategories
                                        where a.ItemCategoryID == itemCategoryId && a.Promotions ==true
                                        select new {a.Promotions}).FirstOrDefault();
                var getItem = from a in ctx.tblItems          
                              where a.ItemCategoryID == itemCategoryId && a.IsActive == true
                              select a;
                if (getItem.ToList().Count > 0)
                {
                    if (checkPromotionCat !=null)
                    {
                        promotionCatId = itemCategoryId;
                    }
                    //SSK
                    foreach (var item in getItem)
                    {
                        if (item.IsCriteria == true)
                        {
                            var day = System.DateTime.Now.DayOfWeek.ToString();
                            bool? monday = null;
                            bool? tue = null;
                            bool? wed = null;
                            bool? thu = null;
                            bool? fri = null;
                            bool? sat = null;
                            bool? sund = null;

                            if (day == "Monday")
                            {
                                monday = true;
                            }
                            if (day == "Tuesday")
                            {
                                tue = true;
                            }
                            if (day == "Wednesday")
                            {
                                wed = true;
                            }
                            if (day == "Thursday")
                            {
                                thu = true;
                            }
                            if (day == "Friday")
                            {
                                fri = true;
                            }
                            if (day == "Saturday")
                            {
                                sat = true;
                            }
                            if (day == "Sunday")
                            {
                                sund = true;
                            }

                            var date = DateTime.Now.Date;
                            DateTime dateTime = DateTime.Now;
                            var strMaxFormat = dateTime.ToString("HH:mm:ss");
                            TimeSpan ftime = TimeSpan.Parse(strMaxFormat);

                            if (item.IsTimeBase == true && item.FromTime <= ftime && item.ToTime >= ftime && item.FromDate == null && item.Todate == null && item.IsDayBase == false)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsTimeBase == true && item.FromTime <= ftime && item.ToTime >= ftime && item.IsDateBase == true && item.FromDate <= date && item.Todate >= date && item.IsDayBase == false)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            //time base
                            else if (item.IsDateBase == true && item.FromDate <= date && item.Todate >= date && item.FromTime == null && item.ToTime == null && item.IsDayBase == false)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            //date base

                            else if (item.IsDayBase == true && item.IsMonday == monday && item.FromTime == null && item.ToTime == null && item.FromDate == null && item.Todate == null)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }

                            else if (item.IsDayBase == true && item.IsMonday == monday && item.IsTimeBase == true && item.FromTime <= ftime && item.ToTime >= ftime && item.IsDateBase == true && item.FromDate <= date && item.Todate >= date)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsTuesday == tue && item.FromTime == null && item.ToTime == null && item.FromDate == null && item.Todate == null)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsTuesday == tue && item.IsTimeBase == true && item.FromTime <= ftime && item.ToTime >= ftime && item.IsDateBase == true && item.FromDate <= date && item.Todate >= date)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsWednesday == wed && item.FromTime == null && item.ToTime == null && item.FromDate == null && item.Todate == null)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsWednesday == wed && item.IsTimeBase == true && item.FromTime <= ftime && item.ToTime >= ftime && item.IsDateBase == true && item.FromDate <= date && item.Todate >= date)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsThusday == thu && item.FromTime == null && item.ToTime == null && item.FromDate == null && item.Todate == null)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsThusday == thu && item.IsTimeBase == true && item.FromTime <= ftime && item.ToTime >= ftime && item.IsDateBase == true && item.FromDate <= date && item.Todate >= date)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsFriday == fri && item.FromTime == null && item.ToTime == null && item.FromDate == null && item.Todate == null)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsFriday == fri && item.IsTimeBase == true && item.FromTime <= ftime && item.ToTime >= ftime && item.IsDateBase == true && item.FromDate <= date && item.Todate >= date)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsSaturday == sat && item.FromTime == null && item.ToTime == null && item.FromDate == null && item.Todate == null)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsSaturday == sat && item.IsTimeBase == true && item.FromTime <= ftime && item.ToTime >= ftime && item.IsDateBase == true && item.FromDate <= date && item.Todate >= date)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsSunday == sund && item.FromTime == null && item.ToTime == null && item.FromDate == null && item.Todate == null)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsSunday == sund && item.IsTimeBase == true && item.FromTime <= ftime && item.ToTime >= ftime && item.IsDateBase == true && item.FromDate <= date && item.Todate >= date)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            //day and time base
                            else if (item.IsDayBase == true && item.IsMonday == monday && item.IsTimeBase == true && item.FromTime <= ftime && item.ToTime >= ftime)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsTuesday == tue && item.IsTimeBase == true && item.FromTime <= ftime && item.ToTime >= ftime)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsWednesday == wed && item.IsTimeBase == true && item.FromTime <= ftime && item.ToTime >= ftime)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsThusday == thu && item.IsTimeBase == true && item.FromTime <= ftime && item.ToTime >= ftime)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsFriday == fri && item.IsTimeBase == true && item.FromTime <= ftime && item.ToTime >= ftime)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsSaturday == sat && item.IsTimeBase == true && item.FromTime <= ftime && item.ToTime >= ftime)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsSunday == sund && item.IsTimeBase == true && item.FromTime <= ftime && item.ToTime >= ftime)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }

                            // date and day base
                            else if (item.IsDayBase == true && item.IsMonday == monday && item.IsDateBase == true && item.FromDate <= date && item.Todate >= date && item.IsTimeBase == false)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsTuesday == tue && item.IsDateBase == true && item.FromDate <= date && item.Todate >= date && item.IsTimeBase == false)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsWednesday == wed && item.IsDateBase == true && item.FromDate <= date && item.Todate >= date && item.IsTimeBase == false)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsTuesday == thu && item.IsDateBase == true && item.FromDate <= date && item.Todate >= date && item.IsTimeBase == false)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsFriday == fri && item.IsDateBase == true && item.FromDate <= date && item.Todate >= date && item.IsTimeBase == false)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsSaturday == sat && item.IsDateBase == true && item.FromDate <= date && item.Todate >= date && item.IsTimeBase == false)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            else if (item.IsDayBase == true && item.IsSunday == sund && item.IsDateBase == true && item.FromDate <= date && item.Todate >= date && item.IsTimeBase == false)
                            {
                                createItemsButton(item.ItemID.ToString(), item.ItemName);
                            }
                            //
                        }
                        else
                        {
                            createItemsButton(item.ItemID.ToString(), item.ItemName);
                        }
                    }
                }
                lblCategoryName.Text = button.Text;
                panel2.Focus();
                SendKeys.Send("Tab");
            }
        }

        private void createItemsButton(string GrpCode, string GrpName)
        {
            Button btnItem = new Button();
            btnItem.Name = GrpCode;
            btnItem.Location = new Point(ii, xx);
            btnItem.Height = 100;
            btnItem.Width = 100;
            btnItem.BackColor = System.Drawing.Color.DarkRed;
            btnItem.Text = GrpName;

            btnItem.Click += new EventHandler(btnItem_Click);
            btnItem.KeyDown += new KeyEventHandler(btnItem_KeyDown);

            panel2.Controls.Add(btnItem);

            if (ii < 400)
            {
                ii += 110;
            }
            else
            {
                ii = 0;
                xx += 110;
            }
        }

        void btnItem_Click(object sender, EventArgs e)
        {



            int len = sender.ToString().Length;
            var button = sender as Button;

            xc = 0;
            try
            {
                if (button != null)
                {


                    int Qty = 0;
                    int todayQty = 0;
                    long ItemID = long.Parse(button.Name.ToString());

                    var getCategoryByItemID = (from a in ctx.tblItems
                                               join b in ctx.tblItemCategories on a.ItemCategoryID equals b.ItemCategoryID
                                               // join c in ctx.tblCounters on  b.ItemCategoryID equals c.CounterID
                                               where a.ItemID == ItemID
                                               select new { a.ItemCategoryID, a.ItemID, a.ItemName, a.Price, b.IsSlotCategory, b.DiscreateItem,b.Promotions ,a.RfidWatch }).SingleOrDefault();
                    if (getCategoryByItemID != null)
                    {
                        if (getCategoryByItemID.Promotions ==true)
                        {
                            if (clsGlobalVar.IsMasterCard != true)
                            {
                                lblPromotionAmount.Text = (float.Parse(lblPromotionAmount.Text) + float.Parse(getCategoryByItemID.Price.ToString())).ToString();
                            }
                            else
                            {
                                serialPort1.Close();
                                MessageBox.Show("Promotions amount not allowed to master card");
                                serialPort1.Open();

                            }
                        }
                        else if (getCategoryByItemID.DiscreateItem != true)
                        {
                            if (getCategoryByItemID != null)
                            {
                                TotalAmount += float.Parse(getCategoryByItemID.Price.ToString());
                            }
                            if (clsGlobalVar.IsNewCard)
                            {
                                lblTopUpAmount.Text = (TotalAmount - Convert.ToDouble(clsGlobalVar.NewCardAmount)).ToString();
                            }
                            else
                            {
                                lblTopUpAmount.Text = TotalAmount.ToString();
                            }


                        }
                      
                        else
                        {

                            if (clsGlobalVar.IsMasterCard == true)
                            {
                                serialPort1.Close();
                                MessageBox.Show("Can't Insert item with Master Card");
                                serialPort1.Open();
                                return;
                            }

                            if (getCategoryByItemID.RfidWatch == true)
                            {
                                this.ItemID = getCategoryByItemID.ItemID;

                                lblWristBandItem.Text = getCategoryByItemID.ItemName;
                                ////frmD = new frmDiscount();
                                ////frmD.ShowDialog();

                                ////if (btnAddWatch.BackColor == Color.DarkRed && btnRemoveWatch.BackColor == Color.DarkRed)
                                ////{

                                ////    rfidCard = false;

                                ////}
                                ////else
                                ////{
                                ////    rfidCard = true;
                                ////}

                                //if (!btnAddWatch.Enabled)
                                //{
                                //    watchAdd = true;

                                //}
                                //else
                                //{
                                //    watchAdd = false;
                                //}

                                return;
                            }

                            Qty = 1;

                            for (int i = 0; i < dgvPOS.Rows.Count - 1; i++)
                            {

                                if (dgvPOS.Rows[i].Cells[1].Value.ToString() == ItemID.ToString())
                                {
                                    Qty = int.Parse(dgvPOS.Rows[i].Cells[3].Value.ToString());
                                    Qty = Qty + 1;
                                    if (getCategoryByItemID.IsSlotCategory == true)
                                    {
                                        if (Qty > int.Parse(txtRemainingTickets.Text))
                                        {
                                            MessageBox.Show("Now You Have (0) Qty Available.");
                                            return;
                                        }
                                    }
                                    dgvPOS.Rows[i].Cells[3].Value = Qty.ToString();
                                    dgvPOS.Rows[i].Cells[5].Value = Qty * getCategoryByItemID.Price;
                                    lblTotalAmount.Text = (TotalAmount + GetTotalAmountGirdItems()).ToString();

                                    lblItemName.Text = getCategoryByItemID.ItemName;
                                    todayQty = countItem(getCategoryByItemID.ItemID);
                                    txtItemCount.Text = todayQty.ToString();

                                    return;
                                }
                            }
                            if (getCategoryByItemID.IsSlotCategory == true)
                            {
                                if ((lblSlotItemCount.Text == "" ? 0 : int.Parse(lblSlotItemCount.Text)) == 1)
                                {
                                    MessageBox.Show("You cannot Insert " + button.Text + " in Current Transaction");
                                    return;
                                }
                                if (Qty > int.Parse(txtRemainingTickets.Text))
                                {
                                    MessageBox.Show("Now You Have (0) Qty Available.");
                                    return;
                                }

                                dgvPOS.Rows.Add(getCategoryByItemID.ItemCategoryID, getCategoryByItemID.ItemID, getCategoryByItemID.ItemName, Qty, getCategoryByItemID.Price, Qty * getCategoryByItemID.Price, "YES", lblTicketIssueID.Text);
                                lblSlotItemCount.Text = "1";
                            }
                            else
                                dgvPOS.Rows.Add(getCategoryByItemID.ItemCategoryID, getCategoryByItemID.ItemID, getCategoryByItemID.ItemName, Qty, getCategoryByItemID.Price, Qty * getCategoryByItemID.Price, "NO", "0");

                        }
                        lblTotalAmount.Text = (TotalAmount + GetTotalAmountGirdItems()).ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        float GetTotalAmountGirdItems()
        {
            float iTotalAmount = 0;

            foreach (DataGridViewRow row in dgvPOS.Rows)
            {
                if (dgvPOS.Rows[row.Index].Cells[5].Value != null)
                    iTotalAmount += float.Parse(dgvPOS.Rows[row.Index].Cells[5].Value.ToString());
            }
            return iTotalAmount;
        }
        void btnItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ClearFields();
                //lblCardType.Text = "";
                //ItemID = 0;
                //lblTotalAmount.Text = "0";
                //lblTopUpAmount.Text = "0";
                //lblWristBandItem.Text = "Not Selected";
                //lblMemberAmount.Text = "";
                ////lblTicketIssueID.Text = "";
                //lblSlotItemCount.Text = "";
                //dgvPOS.Rows.Clear();
                //getLatestPOSID();
                //rfidList.RemoveRange(0, rfidList.Count);
                //clsGlobalVar.IsMasterCard = false;
                //serialPort1.Close();
                //serialPort1.Open();
            }
        }

        private int countItem(long _itemId)
        {
            int Qty = 0;
            DateTime saleDate = DateTime.Parse(lblSaleDate.Text).Date;
            var checkData = (from pos in ctx.tblPOSDetails
                             join b in ctx.tblPOS on pos.POSID equals b.POSID
                             where pos.ItemID == _itemId && b.SaleDate == saleDate && b.Status == "Done"
                             select new { pos.Quantity, pos.Price });
            if (checkData.ToList().Count > 0)
            {
                var totalQty = checkData.Sum(d => d.Quantity);
                Qty = int.Parse(totalQty.ToString());
            }
            return Qty;
        }

        float? GetTotalAmount()
        {

            return TotalAmount;
        }

        int GetTotalQty()
        {
            int iTotalQty = 0;

            foreach (DataGridViewRow row in dgvPOS.Rows)
            {
                if (dgvPOS.Rows[row.Index].Cells[3].Value != null && dgvPOS.Rows[row.Index].Cells[6].Value.ToString() == "YES")
                    iTotalQty += int.Parse(dgvPOS.Rows[row.Index].Cells[3].Value.ToString());
            }
            return iTotalQty;
        }

        long _fromTicket = 0;
        long _toTicket = 0;
        long _balanceTicket = 0;
        private void getQtyInHand(long _categoryID)
        {
            var getIssueData = (from a in ctx.tblTicketIssues
                                join b in ctx.tblLotSetups on a.LOTID equals b.LOTID
                                where a.CategoryID == _categoryID
                                orderby a.TicketIssueID descending
                                select new { a.TicketIssueID, a.FromTicket, a.ToTicket, a.BalanceTicket, a.LOTID, b.LOTName }).Take(1).SingleOrDefault();
            if (getIssueData != null)
            {
                lblTicketIssueID.Text = getIssueData.TicketIssueID.ToString();
                txtLOT.Text = getIssueData.LOTName;
                _fromTicket = long.Parse(getIssueData.FromTicket.ToString());
                _toTicket = long.Parse(getIssueData.ToTicket.ToString());
                _balanceTicket = long.Parse(getIssueData.BalanceTicket.ToString());


                var checkData = (from pos in ctx.tblPOSDetails
                                 join k in ctx.tblPOS on pos.POSID equals k.POSID
                                 where pos.ItemCategoryID == _categoryID && pos.TicketIssueID == getIssueData.TicketIssueID && pos.TicketIssueID != 0 && k.Status == "Done"
                                 select new { pos.Quantity, pos.Price });
                if (checkData.ToList().Count > 0)
                {
                    var totalQty = checkData.Sum(d => d.Quantity);

                    txtInHand.Text = (_fromTicket + totalQty) + " - " + _toTicket;
                    txtSoldOut.Text = totalQty.ToString();
                    long _difference = _toTicket - (_fromTicket - 1);
                    long _remainingTicket = _difference - long.Parse(txtSoldOut.Text);
                    txtRemainingTickets.Text = _remainingTicket.ToString();
                }
                else
                {
                    var getTicketNo = (from a in ctx.tblTicketIssues
                                       where a.CategoryID == _categoryID
                                       orderby a.TicketIssueID descending
                                       select new { a.FromTicket, a.ToTicket }).Take(1).SingleOrDefault();
                    if (getTicketNo != null)
                    {
                        txtInHand.Text = _fromTicket + " - " + _toTicket;
                        txtSoldOut.Text = "0";
                        long _difference = _toTicket - (_fromTicket - 1);
                        long _remainingTicket = _difference - long.Parse(txtSoldOut.Text);
                        txtRemainingTickets.Text = _remainingTicket.ToString();
                    }
                }
            }
            else
            {
                lblTicketIssueID.Text = "";
                txtInHand.Text = "";
                txtSoldOut.Text = "";
                txtRemainingTickets.Text = "";
                txtLOT.Text = "";
            }
        }

        private bool CheckStockAvailability()
        {
            long _qty = GetTotalQty();
            long _balanceTicket = txtRemainingTickets.Text == "" ? 0 : long.Parse(txtRemainingTickets.Text);

            if (lblTicketIssueID.Text != "" && txtInHand.Text != "" && txtSoldOut.Text != "" && txtRemainingTickets.Text != "")
            {
                if (_qty > _balanceTicket)
                {
                    MessageBox.Show("You have " + _balanceTicket + " Ticket(s) Available in This Category, You Cannot Select This Category", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                    return true;
            }
            else
                return true;
        }

        //private bool checkStock()
        //{
        //    long ticketIssueId = long.Parse(lblTicketIssueID.Text);

        //    var checkTicket = (from a in ctx.tblTicketIssues
        //                       where a.TicketIssueID == ticketIssueId
        //                       select a).SingleOrDefault();
        //    if (checkTicket != null)
        //        return true;
        //    else
        //    {
        //        MessageBox.Show("Please Assign Ticket(s) to this Category in order to Sale", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return false;
        //    }

        //}


        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            string ItemName = dgvPOS.Rows[0].Cells[1].Value == null ? null : dgvPOS.Rows[0].Cells[1].Value.ToString();
            if (ItemName != null)
            {
                if (dgvPOS.SelectedRows.Count > 0)
                {
                    if (dgvPOS.SelectedRows[0].Cells[3].Value == null)
                        return;

                    int Qty = int.Parse(dgvPOS.SelectedRows[0].Cells[3].Value.ToString());
                    decimal Price = decimal.Parse(dgvPOS.SelectedRows[0].Cells[4].Value.ToString());
                    Qty = Qty - 1;
                    if (Qty >= 1)
                    {
                        dgvPOS.SelectedRows[0].Cells[3].Value = Qty.ToString();
                        dgvPOS.SelectedRows[0].Cells[5].Value = Qty * Price;
                    }
                    else if (Qty == 0)
                    {
                        if (dgvPOS.SelectedRows[0].Cells[8].Value == null)
                        {
                            dgvPOS.Rows.RemoveAt(dgvPOS.CurrentRow.Index);
                            lblSlotItemCount.Text = "";
                        }
                        else
                        {
                            return;
                        }
                    }
                    lblTotalAmount.Text = (GetTotalAmount() + GetTotalAmountGirdItems()).ToString();
                    lblTopUpAmount.Text = GetTotalAmount().ToString();
                }
                else
                {
                    //lblSlotItemCount.Text = "";
                    MessageBox.Show("Please select Row before pressing Remove Item button.", "Slot POS", MessageBoxButtons.OK);
                }
            }

        }


        private void button24_Click(object sender, EventArgs e)
        {
            if ((lblTotalAmount.Text != "" && lblTotalAmount.Text != "0") || (lblPromotionAmount.Text != "" && lblPromotionAmount.Text != "0") || clsGlobalVar.FreeEntry == true)
            {

                if (clsGlobalVar.FreeEntry==true)
                {
                     if (lblTopUpAmount.Text == "")
                        {
                            lblTopUpAmount.Text = "0";
                        }
                   
                }
                getLatestPOSID();
                //string ItemName = dgvPOS.Rows[0].Cells[1].Value == null ? null : dgvPOS.Rows[0].Cells[1].Value.ToString();
                //if (ItemName == null)
                //{
                //    MessageBox.Show("Please add Item(s) before Closing Order!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                SlotPOSEntities ctx1 = new SlotPOSEntities();
                long posId = long.Parse(txtTransID.Text);
                var checkPOS = (from a in ctx1.tblPOS
                                where a.POSID == posId
                                select a).SingleOrDefault();
                if (checkPOS == null)
                {
                    bool check = CheckStockAvailability();
                    if (check == true)
                    {
                        tblPOS pos = new tblPOS();
                        pos.UserID = clsGlobalVar.UserID;
                        pos.CounterID = clsGlobalVar.CounterID;
                        pos.SaleDate = DateTime.Parse(lblSaleDate.Text);
                        //pos.POSTime = DateTime.Now.ToString("HH:mm:ss tt");
                        pos.Status = "Pending";
                        pos.TotalAmount = lblTotalAmount.Text;
                        pos.InsertedDateTime = DateTime.Now;
                        pos.MobileNo = txtMobileNumber.Text;
                        ctx1.AddTotblPOS(pos);
                        ctx1.SaveChanges();
                        POS_ID = pos.POSID;
                        //Insert Data in Detail Table

                        //==============================
                        //         For TopUP Amount
                        //=============================


                        //tblPOSDetail _detail = new tblPOSDetail();

                        //_detail.POSID = pos.POSID;
                        //_detail.Quantity = 1;
                        //_detail.p
                        ////  _detail.ItemCategoryID = long.Parse(dgvPOS.Rows[i].Cells[0].Value.ToString());
                        ////  _detail.ItemID = long.Parse(dgvPOS.Rows[i].Cells[1].Value.ToString());
                        ////  _detail.Quantity = int.Parse(dgvPOS.Rows[i].Cells[3].Value.ToString());
                        ////   _detail.Price = dgvPOS.Rows[i].Cells[4].Value.ToString();
                        //// _detail.NetAmount = dgvPOS.Rows[i].Cells[5].Value.ToString();
                        ////  _detail.TicketIssueID = long.Parse(dgvPOS.Rows[i].Cells[7].Value.ToString());
                        //ctx1.AddTotblPOSDetails(_detail);
                        //ctx1.SaveChanges();



                        //==============================
                        int y = dgvPOS.Rows.Count - 1;
                        for (int i = 0; i < y; i++)
                        {
                            //  SlotPOSEntities ctx1 = new SlotPOSEntities();
                            tblPOSDetail detail = new tblPOSDetail();
                            detail.POSID = pos.POSID;
                            detail.ItemCategoryID = long.Parse(dgvPOS.Rows[i].Cells[0].Value.ToString());
                            detail.ItemID = long.Parse(dgvPOS.Rows[i].Cells[1].Value.ToString());
                            detail.Quantity = int.Parse(dgvPOS.Rows[i].Cells[3].Value.ToString());
                            detail.Price = dgvPOS.Rows[i].Cells[4].Value.ToString();
                            detail.NetAmount = dgvPOS.Rows[i].Cells[5].Value.ToString();
                            detail.TicketIssueID = long.Parse(dgvPOS.Rows[i].Cells[7].Value.ToString());
                            ctx1.AddTotblPOSDetails(detail);
                            ctx1.SaveChanges();
                        }
                        serialPort1.Close();
                        promotions = lblPromotionAmount.Text == "" ? 0 : decimal.Parse(lblPromotionAmount.Text);
                        if (txtMobileNumber.Text.TrimStart().TrimEnd() == "" || ((lblTopUpAmount.Text == "" || lblTopUpAmount.Text == "0") && clsGlobalVar.FreeEntry != true && promotions <= 0))
                        {
                            frmPaymentMode PaymentMode = new frmPaymentMode(POS_ID, decimal.Parse(lblTotalAmount.Text), "No Card", 0, rfidList, promotions, promotionCatId);
                            PaymentMode.ShowDialog();
                        }
                        else
                        {
                            frmPaymentMode PaymentMode = new frmPaymentMode(POS_ID, decimal.Parse(lblTotalAmount.Text), txtMobileNumber.Text, decimal.Parse(lblTopUpAmount.Text), rfidList, promotions,promotionCatId);
                            PaymentMode.ShowDialog();
                        }
                        serialPort1.Open();
                    }
                    else
                        return;
                }

                //serialPort1.Close();
                //promotions = lblPromotionAmount.Text == "" ? 0 : decimal.Parse(lblPromotionAmount.Text);
                //if (txtMobileNumber.Text.TrimStart().TrimEnd() == "" || ((lblTopUpAmount.Text == "" || lblTopUpAmount.Text == "0") && clsGlobalVar.FreeEntry!=true && promotions <=0))
                //{
                //    frmPaymentMode PaymentMode = new frmPaymentMode(POS_ID, decimal.Parse(lblTotalAmount.Text), "No Card", 0, rfidList,promotions);
                //    PaymentMode.ShowDialog();
                //}
                //else
                //{
                //    frmPaymentMode PaymentMode = new frmPaymentMode(POS_ID, decimal.Parse(lblTotalAmount.Text), txtMobileNumber.Text, decimal.Parse(lblTopUpAmount.Text), rfidList,promotions);
                //    PaymentMode.ShowDialog();
                //}
                //serialPort1.Open();

                if (clsGlobalVar.IsPaymentDone == true)
                {
                   
                    //TotalAmount = 0;
                    //lblWristBandItem.Text = "";
                    //ItemID = 0;
                 //   getLatestPOSID();
                    ClearFields();
                    if (lblCategoryID.Text != "")
                        getQtyInHand(long.Parse(lblCategoryID.Text));
                    //DisableControls(this);


                   

                    //EnableControl(txtMobileNumber);
                    //EnableControl(pictureBox2);
                    //========================

                    //EnableControl(label7);
                    //EnableControl(lblWatchItem);
                    //EnableControl(label2);
                    //EnableControl(lblWristBandItem);
                    //EnableControl(lblTotalAmount);
                    //EnableControl(btnRemoveItem);
                    //EnableControl(panel1);
                    //EnableControl(panel2);
                    //EnableControlsDiscreate(panel1);
                    //EnableControl(btnCloseOrder);
                    //EnableControl(dgvPOS);
                    //EnableControl(btnRemoveWatch);
                    //btnAddWatch_Click(null, null);
                    //lblWristBandItem.Text = "Not Selected";
                    ////=======================
                    //txtMobileNumber.Text = string.Empty;
                    //txtMobileNumber.Focus();
                    //lblCardType.Text = "";
                    //lblPromotionAmount.Text = "0";
                    //lblMemberAmount.Text = "";
                    //rfidList.RemoveRange(0, rfidList.Count);
                    //serialPort1.Close();
                    //serialPort1.Open();
                }
                txtItemCount.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Please add some amount");
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                this.Close();
            }
            catch (Exception)
            {


            }

        }

        private void frmSlotPOS_Load(object sender, EventArgs e)
        {
            x1 = 0;
            y1 = 0;

            getUserDetail(clsGlobalVar.UserID);
            getLatestPOSID();
            GetOpeningDate();
            createItemCateogryButton();
            DisableControls(this);
            EnableControl(lblError);
            EnableControl(txtMobileNumber);
            EnableControl(pictureBox2);
            //========================

            EnableControl(label7);
            EnableControl(lblWatchItem);
            EnableControl(label2);
            EnableControl(lblWristBandItem);
            EnableControl(lblTotalAmount);
            EnableControl(btnRemoveItem);
            EnableControl(panel1);
            EnableControl(panel2);
            EnableControlsDiscreate(panel1);
            EnableControl(btnCloseOrder);
            EnableControl(dgvPOS);
            EnableControl(btnRemoveWatch);
            btnAddWatch_Click(null, null);

            //=======================
            txtMobileNumber.Focus();
            txtMobileNumber.Select();
            serialPort1.PortName = portname;
            serialPort1.BaudRate = 9600;
            serialPort1.Open();
            if (clsGlobalVar.FreeEntry == true)
            {
                lblTotalAmount.Text = "0";
            }
            if (clsGlobalVar.closeDate==true)
            {
                lnkLabelClose.Visible = true;
            }
            //GetCardCode("0007254937");
        }

        private void lnkLabelClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDayOpenClose closing = new frmDayOpenClose();
            this.Close();
            closing.ShowDialog();
        }

        private void dgvPOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ClearFields();
                //ItemID = 0;
                //lblCardType.Text = "";
                //lblTotalAmount.Text = "0";
                //lblTopUpAmount.Text = "0";
                //lblWristBandItem.Text = "Not Selected";
                ////lblTicketIssueID.Text = "";
                //lblSlotItemCount.Text = "";
                //lblMemberAmount.Text = "";
                //dgvPOS.Rows.Clear();
                //getLatestPOSID();
                //clsGlobalVar.IsMasterCard = false;
                //rfidList.RemoveRange(0, rfidList.Count);
            }
        }

        private void frmSlotPOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ClearFields();
                //lblCardType.Text = "";
                //ItemID = 0;
                //lblTotalAmount.Text = "0";
                //lblTopUpAmount.Text = "0";
                //lblWristBandItem.Text = "Not Selected";
                //lblBalance.Text = "";
                //lblError.Visible = false;
                ////lblTicketIssueID.Text = "";
                //lblSlotItemCount.Text = "";
                //dgvPOS.Rows.Clear();
                //getLatestPOSID();
                //DisableControls(this);
                //EnableControl(lblError);
                //EnableControl(txtMobileNumber);
                //EnableControl(pictureBox2);
                //EnableControl(lblWatchItem);
                //txtItemCount.Text = string.Empty;
                //txtMobileNumber.Text = string.Empty;
                //TotalAmount = 0;
                //lblMemberAmount.Text = "";
                //panel2.Controls.Clear();
                //EnableControl(lblWristBandItem);
                //EnableControl(label7);
                //EnableControl(label2);
                //EnableControl(lblTotalAmount);
                //EnableControl(btnRemoveItem);
                //EnableControl(panel1);
                //EnableControl(panel2);
                //EnableControlsDiscreate(panel1);
                //EnableControl(btnCloseOrder);
                //EnableControl(dgvPOS);
                //EnableControl(btnRemoveWatch);
                //btnAddWatch_Click(null, null);
                //txtMobileNumber.Focus();
                //rfidList.RemoveRange(0, rfidList.Count);
                //clsGlobalVar.IsMasterCard = false;
                //lblPromotionAmount.Text = "0";
                //serialPort1.Close();
                //serialPort1.Open();
            }
            if (e.KeyCode==Keys.F6)
            {
                   int PromotionAmount = lblPromotionAmount.Text == "" ? 0 : int.Parse(lblPromotionAmount.Text);
                   if (PromotionAmount > 0)
                   {
                       frmDeduction frmd = new SlotPOS.frmDeduction(PromotionAmount);
                       frmd.ShowDialog();
                       if ((PromotionAmount - clsGlobalVar.DeductionAmount) >= 0)
                       {
                           lblPromotionAmount.Text = (PromotionAmount - clsGlobalVar.DeductionAmount).ToString();
                       }
                   }
            }
            if (e.KeyCode == Keys.F5)
            {
                int TopUpAmount = lblTopUpAmount.Text == "" ? 0 : int.Parse(lblTopUpAmount.Text);

                if (lblTotalAmount.Text.TrimStart().TrimEnd() != "")
                {
                    if (clsGlobalVar.IsNewCard)
                    {
                      
                        if (Convert.ToDouble(lblTopUpAmount.Text) > 0)
                        {
                            frmDeduction frmd = new SlotPOS.frmDeduction(TopUpAmount);
                            frmd.ShowDialog();
                            if (clsGlobalVar.DeductionAmount != 0 && (TopUpAmount - clsGlobalVar.DeductionAmount) >= 0)
                            {

                                TotalAmount = TotalAmount - clsGlobalVar.DeductionAmount;
                                if (clsGlobalVar.IsNewCard)
                                {
                                    lblTopUpAmount.Text = (TotalAmount - Convert.ToDouble(clsGlobalVar.NewCardAmount)).ToString();
                                }
                                else
                                {
                                    lblTopUpAmount.Text = TotalAmount.ToString();
                                }

                                lblTotalAmount.Text = (TotalAmount + GetTotalAmountGirdItems()).ToString();
                                clsGlobalVar.DeductionAmount = 0;

                            }

                        }
                        else
                        {
                            MessageBox.Show("Decduct amount can't be greater than TopUp amount");
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(lblTopUpAmount.Text) > 0)
                        {
                            frmDeduction frmd = new SlotPOS.frmDeduction(TopUpAmount);
                            frmd.ShowDialog();
                            if (clsGlobalVar.DeductionAmount != 0 && (TopUpAmount - clsGlobalVar.DeductionAmount) >= 0)
                            {

                                TotalAmount = TotalAmount - clsGlobalVar.DeductionAmount;
                                if (clsGlobalVar.IsNewCard)
                                {
                                    lblTopUpAmount.Text = (TotalAmount - Convert.ToDouble(clsGlobalVar.NewCardAmount)).ToString();
                                }
                                else
                                {
                                    lblTopUpAmount.Text = TotalAmount.ToString();
                                }

                                lblTotalAmount.Text = (TotalAmount + GetTotalAmountGirdItems()).ToString();
                                clsGlobalVar.DeductionAmount = 0;

                            }
                        }
                        else
                        {
                            MessageBox.Show("Decduct amount can't be greater than TopUp amount");
                        }
                    }

                }
            }

            if (e.KeyCode == Keys.F3)
            {
                if ((lblTotalAmount.Text != "" && lblTotalAmount.Text != "0") || (lblPromotionAmount.Text != "" && lblPromotionAmount.Text != "0") || clsGlobalVar.FreeEntry == true && promotions <= 0)
                {
                    if (clsGlobalVar.FreeEntry == true)
                    {
                        if (lblTopUpAmount.Text == "")
                        {
                            lblTopUpAmount.Text = "0";
                        }

                    }
                    getLatestPOSID();
                    //string ItemName = dgvPOS.Rows[0].Cells[1].Value == null ? null : dgvPOS.Rows[0].Cells[1].Value.ToString();
                    //if (ItemName == null)
                    //{
                    //    MessageBox.Show("Please add Item(s) before Closing Order!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}
                    SlotPOSEntities ctx1 = new SlotPOSEntities();
                    long posId = long.Parse(txtTransID.Text);
                    var checkPOS = (from a in ctx1.tblPOS
                                    where a.POSID == posId
                                    select a).SingleOrDefault();
                    if (checkPOS == null)
                    {
                        bool check = CheckStockAvailability();
                        if (check == true)
                        {
                            tblPOS pos = new tblPOS();
                            pos.UserID = clsGlobalVar.UserID;
                            pos.CounterID = clsGlobalVar.CounterID;
                            pos.SaleDate = DateTime.Parse(lblSaleDate.Text);
                            //pos.POSTime = DateTime.Now.ToString("HH:mm:ss tt");
                            pos.Status = "Pending";
                            pos.TotalAmount = lblTotalAmount.Text;
                            pos.InsertedDateTime = DateTime.Now;
                            pos.MobileNo = txtMobileNumber.Text;
                            ctx1.AddTotblPOS(pos);
                            ctx1.SaveChanges();
                            POS_ID = pos.POSID;
                            //Insert Data in Detail Table

                            //==============================
                            //         For TopUP Amount
                            //=============================


                            //tblPOSDetail _detail = new tblPOSDetail();

                            //_detail.POSID = pos.POSID;
                            //_detail.Quantity = 1;
                            //_detail.p
                            ////  _detail.ItemCategoryID = long.Parse(dgvPOS.Rows[i].Cells[0].Value.ToString());
                            ////  _detail.ItemID = long.Parse(dgvPOS.Rows[i].Cells[1].Value.ToString());
                            ////  _detail.Quantity = int.Parse(dgvPOS.Rows[i].Cells[3].Value.ToString());
                            ////   _detail.Price = dgvPOS.Rows[i].Cells[4].Value.ToString();
                            //// _detail.NetAmount = dgvPOS.Rows[i].Cells[5].Value.ToString();
                            ////  _detail.TicketIssueID = long.Parse(dgvPOS.Rows[i].Cells[7].Value.ToString());
                            //ctx1.AddTotblPOSDetails(_detail);
                            //ctx1.SaveChanges();



                            //==============================
                            int y = dgvPOS.Rows.Count - 1;
                            for (int i = 0; i < y; i++)
                            {
                                //  SlotPOSEntities ctx1 = new SlotPOSEntities();
                                tblPOSDetail detail = new tblPOSDetail();
                                detail.POSID = pos.POSID;
                                detail.ItemCategoryID = long.Parse(dgvPOS.Rows[i].Cells[0].Value.ToString());
                                detail.ItemID = long.Parse(dgvPOS.Rows[i].Cells[1].Value.ToString());
                                detail.Quantity = int.Parse(dgvPOS.Rows[i].Cells[3].Value.ToString());
                                detail.Price = dgvPOS.Rows[i].Cells[4].Value.ToString();
                                detail.NetAmount = dgvPOS.Rows[i].Cells[5].Value.ToString();
                                detail.TicketIssueID = long.Parse(dgvPOS.Rows[i].Cells[7].Value.ToString());
                                ctx1.AddTotblPOSDetails(detail);
                                ctx1.SaveChanges();
                            }
                            serialPort1.Close();
                            promotions = lblPromotionAmount.Text == "" ? 0 : decimal.Parse(lblPromotionAmount.Text);
                            if (txtMobileNumber.Text.TrimStart().TrimEnd() == "" || ((lblTopUpAmount.Text == "" || lblTopUpAmount.Text == "0") && clsGlobalVar.FreeEntry != true))
                            {
                                frmPaymentMode PaymentMode = new frmPaymentMode(POS_ID, decimal.Parse(lblTotalAmount.Text), "No Card", 0, rfidList, promotions, promotionCatId);
                                PaymentMode.ShowDialog();
                            }
                            else
                            {
                                frmPaymentMode PaymentMode = new frmPaymentMode(POS_ID, decimal.Parse(lblTotalAmount.Text), txtMobileNumber.Text, decimal.Parse(lblTopUpAmount.Text), rfidList, promotions, promotionCatId);
                                PaymentMode.ShowDialog();
                            }
                            serialPort1.Open();
                        }
                        else
                            return;
                    }

                    //serialPort1.Close();
                    //if (txtMobileNumber.Text.TrimStart().TrimEnd() == "" || ((lblTopUpAmount.Text == "" || lblTopUpAmount.Text == "0") && clsGlobalVar.FreeEntry != true))
                    //{
                    //    frmPaymentMode PaymentMode = new frmPaymentMode(POS_ID, decimal.Parse(lblTotalAmount.Text), "No Card", 0, rfidList,promotions);
                    //    PaymentMode.ShowDialog();
                    //}
                    //else
                    //{
                    //    frmPaymentMode PaymentMode = new frmPaymentMode(POS_ID, decimal.Parse(lblTotalAmount.Text), txtMobileNumber.Text, decimal.Parse(lblTopUpAmount.Text), rfidList,promotions);
                    //    PaymentMode.ShowDialog();
                    //}
                    //serialPort1.Open();

                    if (clsGlobalVar.IsPaymentDone == true)
                    {
                        ClearFields();
                        //TotalAmount = 0;
                        //lblWristBandItem.Text = "";
                        //ItemID = 0;
                        //getLatestPOSID();
                        if (lblCategoryID.Text != "")
                            getQtyInHand(long.Parse(lblCategoryID.Text));
                        //DisableControls(this);
                        //EnableControl(txtMobileNumber);
                        //EnableControl(pictureBox2);
                        ////========================

                        //EnableControl(label7);
                        //EnableControl(lblWatchItem);
                        //EnableControl(label2);
                        //EnableControl(lblWristBandItem);
                        //EnableControl(lblTotalAmount);
                        //EnableControl(btnRemoveItem);
                        //EnableControl(panel1);
                        //EnableControl(panel2);
                        //EnableControlsDiscreate(panel1);
                        //EnableControl(btnCloseOrder);
                        //EnableControl(dgvPOS);
                        //EnableControl(btnRemoveWatch);
                        //btnAddWatch_Click(null, null);
                        //lblWristBandItem.Text = "Not Selected";
                        ////=======================
                        //txtMobileNumber.Text = string.Empty;
                        //txtMobileNumber.Focus();
                        //lblCardType.Text = "";
                        //rfidList.RemoveRange(0, rfidList.Count);
                        //serialPort1.Close();
                        //serialPort1.Open();
                    }
                    txtItemCount.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Please add some amount");
                }
            }
        }

        private void btnRemoveItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ClearFields();
                //lblCardType.Text = "";
                //ItemID = 0;
                //lblTotalAmount.Text = "0";
                ////lblTicketIssueID.Text = "";
                //lblSlotItemCount.Text = "";
                //lblMemberAmount.Text = "";
                //lblWristBandItem.Text = "Not Selected";
                //dgvPOS.Rows.Clear();
                //getLatestPOSID();
                //rfidList.RemoveRange(0, rfidList.Count);
                //clsGlobalVar.IsMasterCard = false;
                //serialPort1.Close();
                //serialPort1.Open();
            }
        }

        private void btnCloseOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ClearFields();
                //lblCardType.Text = "";
                //lblTotalAmount.Text = "0";
                //lblTopUpAmount.Text = "0";
                //lblMemberAmount.Text = "";
                //lblWristBandItem.Text = "Not Selected";
                //ItemID = 0;
                //EnableControl(btnRemoveWatch);
                //btnAddWatch_Click(null, null);
                ////lblTicketIssueID.Text = "";
                //lblSlotItemCount.Text = "";
                //dgvPOS.Rows.Clear();
                //getLatestPOSID();
                //rfidList.RemoveRange(0, rfidList.Count);
                //clsGlobalVar.IsMasterCard = false;
                //serialPort1.Close();
                //serialPort1.Open();
            }
        }


        private void RunBill(ReportDataSource datasource)
        {
            LocalReport report = new LocalReport();
            StreamReader rdlcSR = new StreamReader(@"RdlcReport\rptPrintBill.rdlc");
            report.LoadReportDefinition(rdlcSR);
            report.DataSources.Add(datasource);
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

        private void PrintBill(long _posID)
        {
            SlotDataSetTableAdapters.getPrintBillTableAdapter ad_mis = new SlotDataSetTableAdapters.getPrintBillTableAdapter();
            //     SlotDataSetTableAdapters.getPrintBillCardTableAdapter ad_mis1 = new SlotDataSetTableAdapters.getPrintBillCardTableAdapter();
            //SlotDataSetTableAdapters.sp_getPrintBillItemTableAdapter ad_mis2 = new SlotDataSetTableAdapters.sp_getPrintBillItemTableAdapter();

            DataSet ds = new DataSet();
            ds.Tables.Add(ad_mis.GetData(_posID));
            //    ds.Tables.Add(ad_mis1.GetData(_posID));
            //ds.Tables.Add(ad_mis2.GetData(_posID));

            ReportDataSource datasource = new ReportDataSource("getPrintBill", ds.Tables[0]);

            RunBill(datasource);
        }
        private void txtTransID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                long posId = long.Parse(txtTransID.Text);
                PrintBill(posId);
            }
        }

        private void txtTransID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getLatestPOSID();
        }

        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                DisableControls(c);
            }
            con.Enabled = false;
            lnkLabelClose.Enabled = true;

        }
        private void EnableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                EnableControls(c);
            }
            con.Enabled = true;
        }
        private void EnableControl(Control con)
        {
            if (con != null)
            {
                con.Enabled = true;
                EnableControl(con.Parent);
            }
        }
        private void EnableControlsDiscreate(Control con)
        {

            foreach (Control c in con.Controls)
            {
                long buttonID = Convert.ToInt64(c.Name);
                var btn = ctx.tblItemCategories.FirstOrDefault(t => t.ItemCategoryID == buttonID && t.DiscreateItem == true);
                if (btn != null)
                {
                    c.Enabled = true;
                }

            }

        }
        private void DisableControl(Control con)
        {
            if (con != null)
            {
                con.Enabled = false;
                //DisableControl(con.Parent);
            }
        }


        public void GetCardCode(string rfidCode)
        {
            if (rfidCode.Length == 10)
            {
                lblMemberAmount.Text = "";
                lblError.Text = "";
                lblCardType.Text = "";
                lblPromotionAmount.Text = "0";
                //var userRecord = ctx.tblRFIDs.Where(x => x.RFIDCode == txtMobileNumber.Text).FirstOrDefault();
                SlotPOSEntities ctx1 = new SlotPOSEntities();
                tblRFID userRecord = new tblRFID();
                userRecord = ctx1.tblRFIDs.Where(x => x.RFIDCode == rfidCode).FirstOrDefault();

                if (userRecord != null)
                {
                    #region WristBand
                    //===================================================
                    //                  Wrist Band               
                    //===================================================
                    if (userRecord.IsRFIDWatch == true)
                    {
                        if (userRecord.IsActive != true && !rfidList.Contains(userRecord.RFIDCode) && watchAdd)
                        {
                            // lblCardType.Text = userRecord.CardType;

                            var getCategoryByItemID = (from a in ctx.tblItems
                                                       join b in ctx.tblItemCategories on a.ItemCategoryID equals b.ItemCategoryID
                                                       where a.ItemID == this.ItemID
                                                       select new { a.ItemCategoryID, a.ItemID, a.ItemName, a.Price, b.IsSlotCategory }).SingleOrDefault();

                            if (getCategoryByItemID != null)
                            {
                                rfidList.Add(userRecord.RFIDCode);
                                dgvPOS.Rows.Add(getCategoryByItemID.ItemCategoryID, getCategoryByItemID.ItemID, getCategoryByItemID.ItemName, 1, getCategoryByItemID.Price, 1 * getCategoryByItemID.Price, "NO", "0", userRecord.RFIDCode);
                                lblTotalAmount.Text = (TotalAmount + GetTotalAmountGirdItems()).ToString();
                            }
                        }
                        else if ((userRecord.IsActive == true || rfidList.Contains(userRecord.RFIDCode)) && watchAdd)
                        {
                            lblError.Visible = true;
                            lblError.Text = "Already Active";

                        }
                        else if(watchAdd!=true)
                        {

                            int count = 0;
                            foreach (DataGridViewRow item in dgvPOS.Rows)
                            {
                                if (item.Cells["RFID"].Value != null && item.Cells["RFID"].Value.ToString() != string.Empty)
                                {
                                    if (item.Cells["RFID"].Value.ToString() == rfidCode)
                                    {
                                        rfidList.Remove(rfidCode);
                                        dgvPOS.Rows.RemoveAt(count);
                                        break;
                                    }

                                }
                                count++;
                            }


                            // lblSlotItemCount.Text = "";
                            lblTotalAmount.Text = GetTotalAmount().ToString();

                        }
                        ////txtMobileNumber.Text = "";
                        ////if (userRecord.IsActive != true)
                        ////{





                        ////}
                        return;
                    }
                    #endregion WristBand
                    #region RfidCard
                    //===================================================
                    //                  RFID Card               
                    //===================================================
                    txtMobileNumber.Text = rfidCode;

                    if (userRecord.IsActive != true)
                    {
                        if (!clsGlobalVar.IsCardActivationFormOpen)
                        {
                            clsGlobalVar.IsCardActivationFormOpen = true;
                            frmCardActivation cardform = new frmCardActivation(txtMobileNumber.Text);
                            cardform.ShowDialog();


                            //if (MessageBox.Show("This is a new card. Do you want to activate this card?", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            if (clsGlobalVar.IsCardActivated == true)
                            {
                                //tblRFID obj_rfid = ctx.tblRFIDs.SingleOrDefault(x => x.RFIDCode == txtMobileNumber.Text);
                                //obj_rfid.IsActive = 1;
                                //obj_rfid.Amount = 0;
                                //obj_rfid.CardActiveDateTime = DateTime.Now;
                                //obj_rfid.CardType = "Regular";
                                //ctx.SaveChanges();

                                rfid_code = txtMobileNumber.Text;
                                EnableControls(this);
                                DisableControl(txtMobileNumber);
                                lblError.Visible = false;
                                lblBalance.Text = "0";
                                lblCardType.Text = userRecord.CardType;
                                TotalAmount = Convert.ToInt64(clsGlobalVar.BasicCardAmount) + Convert.ToInt64(clsGlobalVar.NewCardAmount);
                                lblTopUpAmount.Text = Convert.ToInt64(clsGlobalVar.BasicCardAmount).ToString();
                                lblTotalAmount.Text = TotalAmount.ToString();
                            }
                            else
                            {
                                txtMobileNumber.Text = "";
                            }
                        }

                    }
                    else
                    {
                        clsGlobalVar.IsMasterCard = userRecord.IsMaster ?? false;


                        if (dgvPOS.RowCount > 1 && clsGlobalVar.IsMasterCard == true)
                        {

                            serialPort1.Close();
                            MessageBox.Show("Can't Insert  Master Card  with item");
                            serialPort1.Open();
                            txtMobileNumber.Text = "";
                            clsGlobalVar.IsMasterCard = false;
                            return;

                        }

                        tblNewCard newc = new tblNewCard();
                        newc = ctx1.tblNewCards.Where(x => x.RfidCode == txtMobileNumber.Text).FirstOrDefault();
                        if (newc != null)
                        {
                            if (newc.Status == "Pending")
                            {
                                clsGlobalVar.IsNewCard = true;
                                TotalAmount = Convert.ToInt64(clsGlobalVar.BasicCardAmount) + Convert.ToInt64(clsGlobalVar.NewCardAmount);
                                lblTotalAmount.Text = TotalAmount.ToString();
                                lblTopUpAmount.Text = (TotalAmount - Convert.ToInt64(clsGlobalVar.NewCardAmount)).ToString();
                                lblError.Visible = false;
                                lblCardType.Text = userRecord.CardType;
                                lblBalance.Text = userRecord.Amount.ToString();
                                rfid_code = txtMobileNumber.Text;
                                EnableControls(this);
                                DisableControl(txtMobileNumber);
                            }
                            else
                            {
                                lblError.Visible = false;
                                lblBalance.Text = userRecord.Amount.ToString();
                                lblCardType.Text = userRecord.CardType;
                                rfid_code = txtMobileNumber.Text;
                                EnableControls(this);
                                DisableControl(txtMobileNumber);
                            }

                        }
                        else if (userRecord.CardType == "Member" && userRecord.IsMemberActive == true)
                        {
                            tblRFID userPrincipalRecord = ctx1.tblRFIDs.SingleOrDefault(t => t.RFIDCode == userRecord.MemberPrincipalCode);
                            lblError.Visible = false;
                            lblBalance.Text = (userRecord.Amount).ToString();
                            lblCardType.Text = userRecord.CardType;
                            lblMemberAmount.Text = userPrincipalRecord.MemberAmount.ToString();
                            rfid_code = txtMobileNumber.Text;
                            EnableControls(this);
                            DisableControl(txtMobileNumber);
                        }
                    }

                }
                    #endregion RfidCard
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Invalid Card";
                    txtMobileNumber.Text = "";
                }

            }
        }
        private void txtMobileNumber_TextChanged(object sender, EventArgs e)
        {


            //if (txtMobileNumber.Text.Length == 10)
            //{


            //    tblRFID userRecord = new tblRFID();
            //    //var userRecord = ctx.tblRFIDs.Where(x => x.RFIDCode == txtMobileNumber.Text).FirstOrDefault();
            //    SlotPOSEntities ctx1 = new SlotPOSEntities();
            //    userRecord = ctx1.tblRFIDs.Where(x => x.RFIDCode == txtMobileNumber.Text).FirstOrDefault();
            //    if (userRecord != null)
            //    {
            //        if (userRecord.IsActive != 1)
            //        {
            //            frmCardActivation cardform = new frmCardActivation(txtMobileNumber.Text);
            //            cardform.ShowDialog();


            //            //if (MessageBox.Show("This is a new card. Do you want to activate this card?", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            //            if (clsGlobalVar.IsCardActivated == true)
            //            {
            //                //tblRFID obj_rfid = ctx.tblRFIDs.SingleOrDefault(x => x.RFIDCode == txtMobileNumber.Text);
            //                //obj_rfid.IsActive = 1;
            //                //obj_rfid.Amount = 0;
            //                //obj_rfid.CardActiveDateTime = DateTime.Now;
            //                //obj_rfid.CardType = "Regular";
            //                //ctx.SaveChanges();

            //                rfid_code = txtMobileNumber.Text;
            //                EnableControls(this);
            //                DisableControl(txtMobileNumber);
            //                lblError.Visible = false;
            //                lblBalance.Text = "0";
            //            }
            //            else
            //            {
            //                txtMobileNumber.Text = "";
            //            }

            //        }
            //        else
            //        {
            //            lblError.Visible = false;
            //            lblBalance.Text = userRecord.Amount.ToString();
            //            rfid_code = txtMobileNumber.Text;
            //            EnableControls(this);
            //            DisableControl(txtMobileNumber);
            //        }

            //    }
            //    else
            //    {
            //        lblError.Visible = true;
            //        lblError.Text = "Invalid Card";
            //        txtMobileNumber.Text = "";
            //    }

            //}
        }

        private void txtMobileNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                String s = serialPort1.ReadLine().TrimEnd();
                this.BeginInvoke(MyDlg, s);
            }
            catch (Exception)
            {


                //  this.Invoke(thisDel);

            }

        }
        private void sp_catch()
        {
            lblTotalAmount.Text = "0";
            lblTopUpAmount.Text = "0";
            //lblTicketIssueID.Text = "";
            lblSlotItemCount.Text = "";
            //dgvPOS.Rows.Clear();
            getLatestPOSID();
        }

        private void frmSlotPOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
        }

        private void btnAddWatch_Click(object sender, EventArgs e)
        {
            btnAddWatch.BackColor = Color.DarkGreen;
            btnRemoveWatch.BackColor = Color.DarkRed;
            watchAdd = true;
            btnAddWatch.Enabled = false;
            btnRemoveWatch.Enabled = true;


        }

        private void btnRemoveWatch_Click(object sender, EventArgs e)
        {
            btnRemoveWatch.BackColor = Color.DarkGreen;
            btnAddWatch.BackColor = Color.DarkRed;
            watchAdd = false;
            btnAddWatch.Enabled = true;
            btnRemoveWatch.Enabled = false;


        }
    }
}
