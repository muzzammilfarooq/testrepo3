using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SlotPOS
{
    public partial class frmDayOpenClose : Form
    {
        SlotPOSEntities ctx = new SlotPOSEntities();

        public frmDayOpenClose()
        {
            InitializeComponent();
        }

        private void getOpeningDate()
        {
            var getOpeningQuery = (from a in ctx.tblOpeningClosings
                                   where a.ClosingDate == null
                                   orderby a.OpeningClosingID descending
                                   select a).Take(1).SingleOrDefault();
            if (getOpeningQuery != null)
            {
                lblOpeningClosingID.Text = getOpeningQuery.OpeningClosingID.ToString();
                lblSaleDate.Text = getOpeningQuery.OpeningDate.ToString("dd-MMM-yy");
                //lblOpenDate.Visible = true;

                if (getOpeningQuery.OpeningDate.ToString() != "" && getOpeningQuery.ClosingDate.ToString() == "")
                {
                    btnOpening.Enabled = false;
                    btnClosing.Enabled = true;
                    btnClosing.BackColor = System.Drawing.Color.Green;
                }
                else if (getOpeningQuery.OpeningDate.ToString() != "" && getOpeningQuery.ClosingDate.ToString() != "")
                {
                    btnOpening.Enabled = true;
                    btnClosing.Enabled = false;
                    btnOpening.BackColor = System.Drawing.Color.Green;
                }
            }
            else
            {
                var getClosingQuery = (from a in ctx.tblOpeningClosings
                                       orderby a.OpeningClosingID descending
                                       select a).Take(1).SingleOrDefault();
                if (getClosingQuery != null)
                {
                    label2.Text = "Closing Date :";
                    lblSaleDate.Text = DateTime.Parse(getClosingQuery.ClosingDate.ToString()).ToString("dd-MMM-yy");
                }
                btnOpening.Enabled = true;
                btnClosing.Enabled = false;
                btnOpening.BackColor = System.Drawing.Color.Green;

            }
            lblSystemDate.Text = DateTime.Now.ToString("dd-MMM-yy");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDayOpenClose_Load(object sender, EventArgs e)
        {
            getOpeningDate();
        }

        private void btnOpening_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to open a new day?", "Opening / Closing Day", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    tblOpeningClosing opening = new tblOpeningClosing();

                    opening.OpeningDate = DateTime.Parse(lblSystemDate.Text);
                    ctx.AddTotblOpeningClosings(opening);
                    ctx.SaveChanges();

                    MessageBox.Show("Day Opened", "Opening / Closing Day");
                    btnOpening.Enabled = false;
                    btnOpening.BackColor = System.Drawing.Color.Red;
                    btnClosing.BackColor = System.Drawing.Color.Green;
                    btnClosing.Enabled = true;
                    getOpeningDate();
                    frmSlotPOS pos = new frmSlotPOS();
                    pos.Close();
                    this.Close();
                }
                catch { }
            }
        }

        private void btnClosing_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close current day?", "Opening / Closing Day", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    long _openingClosingID = long.Parse(lblOpeningClosingID.Text);

                    var updateQuery = (from a in ctx.tblOpeningClosings
                                       where a.OpeningClosingID == _openingClosingID
                                       select a).SingleOrDefault();

                    

                    if (updateQuery != null)
                    {

                        using (SlotPOSEntities ctx1 = new SlotPOSEntities())
                        {

                            var tblServer = ctx.tblServerStatus.Where(X => X.SaleDate == updateQuery.OpeningDate).OrderByDescending(t => t.ServerOPenDate).Take(1).FirstOrDefault();
                            if (tblServer != null)
                            {
                                if (tblServer.ServerCloseDate == null)
                                {
                                    MessageBox.Show("Please Stop Server Application for Day Closing");
                                    return;
                                }
                            }
                        }
                        //code here
                        updateQuery.ClosingDate = DateTime.Parse(lblSystemDate.Text);
                        var RechargeBalance = (from a in ctx.tblRechargeAmounts
                                               where a.SaleDate == updateQuery.OpeningDate
                                               select a.RechargeAmount).Sum();

                        // Un Used Balance
                        var UnUsedBalance = (from a in ctx.tblRFIDs

                                             where a.IsActive == true && a.IsMaster == false
                                             select a.Amount).Sum();

                        // Used Blaance
                        var UsedBalance = (from a in ctx.tblTransactions

                                           where a.SaleDate == updateQuery.OpeningDate && a.IsMaster == false
                                           select a.Amount).DefaultIfEmpty(0).Sum();

                        tblBalanceHistoryDateWise b = new tblBalanceHistoryDateWise();
                        b.RechargeAmount = Convert.ToDecimal(RechargeBalance);
                        b.UnUsedBalance = UnUsedBalance;
                        b.UsedBalance = UsedBalance;
                        b.SaleDate = updateQuery.OpeningDate;
                        b.IsActive = true;
                        ctx.AddTotblBalanceHistoryDateWises(b);
                        ctx.SaveChanges();
                        MessageBox.Show("Day Closed", "Opening / Closing Day");
                        btnOpening.Enabled = true;
                        btnClosing.Enabled = false;
                        btnClosing.BackColor = System.Drawing.Color.Red;
                        btnOpening.BackColor = System.Drawing.Color.Green;
                        getOpeningDate();
                        
                    }

                    var checkRecord = from a in ctx.tblSlots
                                      select a;
                    if (checkRecord != null)
                    {
                        foreach (var b in checkRecord)
                        {
                            SlotPOSEntities ctx1 = new SlotPOSEntities();

                            var updateRecord = (from c in ctx1.tblSlots
                                                where c.SlotSetupID == b.SlotSetupID
                                                select c).SingleOrDefault();
                            if (updateRecord != null)
                            {
                                updateRecord.Status = null;
                                ctx1.SaveChanges();
                                this.Close();
                            }
                        }
                    }
                }
                catch { }
            }
        }
    }
}
