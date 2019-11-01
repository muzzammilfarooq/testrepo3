using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SlotPOS.Setup_Forms
{
    public partial class frmLotSetup : Form
    {
        SlotPOSEntities ctx = new SlotPOSEntities();

        public frmLotSetup()
        {
            InitializeComponent();
        }

        private void FillGrid()
        {
            var getRecord = from a in ctx.tblLotSetups
                            select a;
            if (getRecord.ToList().Count > 0)
            {
                dgvLOT.AutoGenerateColumns = false;
                dgvLOT.DataSource = getRecord;
            }
        }

        private void ClearFields()
        {
            txtLOTName.Text = "";
            txtFromTicket.Text = "";
            txtToTicket.Text = "";
        }

        private void getLatestBoothID()
        {
            var getLastRecord = from a in ctx.tblLotSetups
                                select a;
            if (getLastRecord.ToList().Count > 0)
            {
                int last = getLastRecord.ToList().Count + 1;
                txtLOTID.Text = last.ToString();
            }
            else
            {
                txtLOTID.Text = "1";
            }

        }

        private bool ValidateForm()
        {
            ep.Clear();
            int i, j, k;
            if (txtLOTName.Text == "")
            {
                ep.SetError(txtLOTName, "Please Type LOT Name.");
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
            return true;
        }

        private bool CheckAlreadyExist()
        {
            string _lotName = txtLOTName.Text.ToLower();

            var check = from a in ctx.tblLotSetups
                        where a.LOTName.ToLower() == _lotName
                        select a;
            if (check.ToList().Count == 0)
                return true;
            else
                return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    if (CheckAlreadyExist())
                    {
                        tblLotSetup LOT = new tblLotSetup();
                        if (MessageBox.Show("Are you sure you want to Add New Record", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            LOT.LOTName = txtLOTName.Text;
                            LOT.FromTicket = long.Parse(txtFromTicket.Text);
                            LOT.ToTicket = long.Parse(txtToTicket.Text);
                            LOT.InsertedDate = DateTime.Now;
                            ctx.AddTotblLotSetups(LOT);
                            ctx.SaveChanges();
                            MessageBox.Show("Record has been Saved Successfully!!!", "Record Saved", MessageBoxButtons.OK);
                        }
                        getLatestBoothID();
                        FillGrid();
                        ClearFields();
                        txtLOTName.Focus();
                    }
                    else
                        MessageBox.Show("LOT Already Exists!!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmLotSetup_Load(object sender, EventArgs e)
        {
            FillGrid();
            getLatestBoothID();
            txtLOTName.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtLOTName.Focus();
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
