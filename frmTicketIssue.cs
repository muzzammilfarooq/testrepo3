using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects.SqlClient;

namespace SlotPOS
{
    public partial class frmTicketIssue : Form
    {
        SlotPOSEntities ctx = new SlotPOSEntities();

        public frmTicketIssue()
        {
            InitializeComponent();
        }

        private void FillComboBox()
        {
            var fillLOT = (from a in ctx.tblLotSetups
                           select a).ToList();
            fillLOT.Insert(0, new tblLotSetup { LOTID = 0, LOTName = "--Select LOT--" });
            if (fillLOT.ToList().Count > 0)
            {
                cmbLOT.DataSource = fillLOT;
                cmbLOT.ValueMember = "LOTID";
                cmbLOT.DisplayMember = "LOTName";
            }
        }

        private void FillItemCateogry()
        {
            var getItem = (from a in ctx.tblItemCategories
                           where a.IsActive == true && a.IsSlotCategory == true
                           select a).ToList();
            getItem.Insert(0, new tblItemCategory { ItemCategoryID = 0, ItemCategory = "-- Select Category --" });
            if (getItem.ToList().Count > 0)
            {
                cmbItemCategory.DataSource = getItem;
                cmbItemCategory.DisplayMember = "ItemCategory";
                cmbItemCategory.ValueMember = "ItemCategoryID";
            }
        }


        private void FillGrid()
        {
            var getRecord = from a in ctx.tblTicketIssues
                            join b in ctx.tblItemCategories on a.CategoryID equals b.ItemCategoryID
                            join d in ctx.tblLotSetups on a.LOTID equals d.LOTID
                            select new { a.TicketIssueID, a.IssueDate, a.LOTID, a.FromTicket, a.ToTicket, a.BalanceTicket, d.LOTName, b.ItemCategory };
            if (getRecord.ToList().Count > 0)
            {
                dgvIssue.AutoGenerateColumns = false;
                dgvIssue.DataSource = getRecord;
            }
        }

        private void ClearFields()
        {
            dtIssueDate.Value = DateTime.Now;
            cmbLOT.SelectedIndex = 0;
            cmbItemCategory.SelectedIndex = 0;
            txtTicketStock.Text = "";
            txtFromTicket.Text = "";
            txtToTicket.Text = "";
            txtBalance.Text = "";
            txtTotalTicket.Text = "";
            lblToTicket.Text = "";
            dtIssueDate.Focus();
        }

        private void getLatestIssueID()
        {
            var getLastRecord = from a in ctx.tblTicketIssues
                                select a;
            if (getLastRecord.ToList().Count > 0)
            {
                int last = getLastRecord.ToList().Count + 1;
                txtTicketIssueID.Text = last.ToString();
            }
            else
            {
                txtTicketIssueID.Text = "1";
            }

        }

        private bool ValidateForm()
        {
            ep.Clear();
            int i, j;
            if (cmbLOT.SelectedIndex == 0)
            {
                ep.SetError(cmbLOT, "Please Select LOT Name.");
                return false;
            }
            if (txtFromTicket.Text == "")
            {
                ep.SetError(txtFromTicket, "Please Type From Ticket No.");
                return false;
            }
            if (!int.TryParse(txtFromTicket.Text, out i))
            {
                ep.SetError(txtFromTicket, "From Ticket Field Should be in Number.");
                return false;
            }
            if (txtToTicket.Text == "")
            {
                ep.SetError(txtToTicket, "Please Type To Ticket No.");
                return false;
            }
            if (!int.TryParse(txtToTicket.Text, out j))
            {
                ep.SetError(txtToTicket, "To Ticket Field Should be in Number.");
                return false;
            }
            if (cmbItemCategory.SelectedIndex == 0)
            {
                ep.SetError(cmbItemCategory, "Please Select Item Category.");
                return false;
            }
            if (cmbItemCategory.SelectedIndex > 0)
            {
                int balanceQty = getBalanceTicket(long.Parse(cmbItemCategory.SelectedValue.ToString()));
                if (balanceQty > 0 || balanceQty == -1)
                {
                    MessageBox.Show("You cannot assign tickets to this Category until all previous Tickets Sold Out!!", "Error",MessageBoxButtons.OK);
                    ClearFields();
                    return false;
                }
            }
            if (cmbLOT.SelectedIndex > 0)
            {
                if (long.Parse(txtTotalTicket.Text) == 0)
                {
                    MessageBox.Show("This LOT Already Assigned to other Slot Category, please use differnt Slot.");
                    return false;
                }
            }
            if (int.Parse(txtToTicket.Text) > int.Parse(lblToTicket.Text))
            {
                MessageBox.Show("Issuance To Ticket Should be smaller than LOT To Ticket.");
                ClearFields();
                return false;
            }
            if (int.Parse(txtFromTicket.Text) > int.Parse(lblFromTicket.Text))
            {
                MessageBox.Show("Issuance From Ticket Should be smaller than LOT From Ticket.");
                ClearFields();
                return false;
            }
            return true;
        }

        private void getLOTByID(int _lotID)
        {
            long FromTicket;
            long ToTicket;
            long TotalTicket;

            var checkData = (from b in ctx.tblTicketIssues
                             where b.LOTID == _lotID
                             select b);
            if (checkData.ToList().Count > 0)
            {

                var getIssueData = (from b in ctx.tblTicketIssues
                                    join c in ctx.tblLotSetups on b.LOTID equals c.LOTID
                                    where b.LOTID == _lotID
                                    orderby b.TicketIssueID descending
                                    select new { b.FromTicket,b.ToTicket,b.BalanceTicket }).First();

                if (getIssueData != null)
                {
                    FromTicket = long.Parse(getIssueData.FromTicket.ToString());
                    ToTicket = long.Parse(getIssueData.ToTicket.ToString());
                    long BalanceTicket = long.Parse(getIssueData.BalanceTicket.ToString());

                    if (BalanceTicket != 0)
                        txtTicketStock.Text = (ToTicket + 1) + " - " + (ToTicket + BalanceTicket);
                    else
                        txtTicketStock.Text = FromTicket + " - " + ToTicket;
                    TotalTicket = (ToTicket + BalanceTicket) - (ToTicket);
                    txtTotalTicket.Text = TotalTicket.ToString();
                    lblFromTicket.Text = FromTicket.ToString();
                    lblToTicket.Text = (ToTicket + BalanceTicket).ToString();
                }
            }
            else
            {
                var getData = (from a in ctx.tblLotSetups
                               where a.LOTID == _lotID
                               select new {a.LOTID, a.FromTicket, a.ToTicket }).SingleOrDefault();
                if (getData != null)
                {
                    FromTicket = long.Parse(getData.FromTicket.ToString());
                    ToTicket = long.Parse(getData.ToTicket.ToString());
                    txtTicketStock.Text = FromTicket + " - " + ToTicket;
                    TotalTicket = (ToTicket) - (FromTicket - 1);
                    txtTotalTicket.Text = TotalTicket.ToString();
                    lblFromTicket.Text = FromTicket.ToString();
                    lblToTicket.Text = ToTicket.ToString();
                }
                else
                    txtTotalTicket.Text = "0";
            }
        }

        private void Calculation()
        {
            long FromTicket = txtFromTicket.Text == "" ? 0 : long.Parse(txtFromTicket.Text);
            long ToTicket = txtToTicket.Text == "" ? 0 : long.Parse(txtToTicket.Text);

            long TotalTicket = (ToTicket) - (FromTicket - 1);

            long TicketInStock = txtTotalTicket.Text == "" ? 0 : long.Parse(txtTotalTicket.Text);

            long BalanceTicket = TicketInStock - TotalTicket;
            if (BalanceTicket >= 0)
                txtBalance.Text = BalanceTicket.ToString();
            else
                return;
        }

        private void frmTicketIssue_Load(object sender, EventArgs e)
        {
            FillComboBox();
            FillItemCateogry();
            FillGrid();
            getLatestIssueID();
            dtIssueDate.Focus();
        }

        private void cmbLOT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLOT.SelectedIndex > 0)
            {
                int _lotID = int.Parse(cmbLOT.SelectedValue.ToString());
                getLOTByID(_lotID);

                if (long.Parse(txtTotalTicket.Text) == 0)
                {
                    MessageBox.Show("This LOT Already Assigned to other Slot Category, please use differnt Slot.");
                    ClearFields();
                }
            }
            else
            {
                txtTotalTicket.Text = "0";
            }
        }

        private void txtFromTicket_TextChanged(object sender, EventArgs e)
        {
            if (txtFromTicket.Text != "")
            {
                Calculation();
            }
        }

        private void txtToTicket_TextChanged(object sender, EventArgs e)
        {
            if (txtToTicket.Text != "")
            {
                Calculation();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm() == true)
                {
                    tblTicketIssue issue = new tblTicketIssue();
                    if (MessageBox.Show("Are you sure you want to Add New Record", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        issue.IssueDate = dtIssueDate.Value;
                        issue.LOTID = int.Parse(cmbLOT.SelectedValue.ToString());
                        issue.CategoryID = long.Parse(cmbItemCategory.SelectedValue.ToString());
                        issue.FromTicket = long.Parse(txtFromTicket.Text);
                        issue.ToTicket = long.Parse(txtToTicket.Text);
                        issue.BalanceTicket = long.Parse(txtBalance.Text);
                        issue.InsertedDate = DateTime.Now;
                        ctx.AddTotblTicketIssues(issue);
                        ctx.SaveChanges();
                        MessageBox.Show("Record has been Saved Successfully!!!", "Record Saved", MessageBoxButtons.OK);

                        getLatestIssueID();
                        FillGrid();
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private int getBalanceTicket(long _categoryID)
        {
            int balanceQty = 0;
            var getIssueData = (from a in ctx.tblTicketIssues
                                join b in ctx.tblLotSetups on a.LOTID equals b.LOTID
                                where a.CategoryID == _categoryID
                                orderby a.TicketIssueID descending
                                select new { a.TicketIssueID, a.FromTicket, a.ToTicket, a.BalanceTicket, a.LOTID, b.LOTName }).Take(1).SingleOrDefault();
            if (getIssueData != null)
            {
                var checkData = (from pos in ctx.tblPOSDetails
                                 where pos.ItemCategoryID == _categoryID && pos.TicketIssueID == getIssueData.TicketIssueID
                                 select new { pos.Quantity, pos.Price });
                if (checkData.ToList().Count > 0)
                {
                    var totalQty = checkData.Sum(d => d.Quantity);
                    if (totalQty == getIssueData.ToTicket)
                        return 0;
                    balanceQty = int.Parse(totalQty.ToString());
                }
                else
                    return -1;
            }
            return balanceQty;
        }

        private void cmbItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItemCategory.SelectedIndex > 0)
            {
                long categoryId = long.Parse(cmbItemCategory.SelectedValue.ToString());
                int balanceQty = getBalanceTicket(categoryId);
                
                
                if (balanceQty > 0 || balanceQty == -1)
                {
                    MessageBox.Show("You cannot assign tickets to this Category until all previous Tickets Sold Out!!", "Error", MessageBoxButtons.OK);
                    ClearFields();
                }
            }
        }

        private void txtFromTicket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtToTicket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
