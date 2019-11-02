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
    public partial class frmEventSetup : Form
    {
        SlotPOSEntities ctx = new SlotPOSEntities();

        public frmEventSetup()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void FillGrid()
        {
            var searchRecord = from a in ctx.tblEvents
                               select a;
            if (searchRecord.ToList().Count > 0)
            {
                dgvEvent.AutoGenerateColumns = false;
                dgvEvent.DataSource = searchRecord;
            }
            else
            {
                dgvEvent.DataSource = null;
                //MessageBox.Show("No Record Found!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearFields()
        {
            dtEventDate.Value = DateTime.Now;
            txtEventName.Text = "";
            txtCustomerName.Text = "";
            txtPhNo.Text = "";
            txtEmail.Text = "";
            txtSlotTime.Text = "";
            txtNoOfGuest.Text = "";
            txtPlanAmount.Text = "";
        }

        private void getLatestEventID()
        {
            var getLastRecord = (from a in ctx.tblEvents
                                 orderby a.EventID descending
                                 select a).Take(1).SingleOrDefault();
            if (getLastRecord != null)
            {
                long last = getLastRecord.EventID + 1;
                txtEventID.Text = last.ToString();
            }
            else
            {
                txtEventID.Text = "1";
            }
        }

        private bool ValidateForm()
        {
            ep.Clear();
            if (txtEventName.Text == "")
            {
                ep.SetError(txtEventName, "Please Enter Event Name.");
                return false;
            }
            if (txtCustomerName.Text == "")
            {
                ep.SetError(txtCustomerName, "Please Enter Customer Name.");
                return false;
            }
            if (txtPlanAmount.Text == "")
            {
                ep.SetError(txtPlanAmount, "Please Enter Total Plan Amount.");
                return false;
            }
            return true;
        }

        private void frmEventSetup_Load(object sender, EventArgs e)
        {
            FillGrid();
            getLatestEventID();
            dtEventDate.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm() == true)
                {
                    tblEvent events = new tblEvent();
                    if (MessageBox.Show("Are you sure you want to Add New Record", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        events.EventDate = dtEventDate.Value;
                        events.EventName = txtEventName.Text;
                        events.CustomerName = txtCustomerName.Text;
                        events.PhoneNumber = txtPhNo.Text;
                        events.EmailAddress = txtEmail.Text;
                        events.SlotTime = txtSlotTime.Text;
                        events.NoOfGuest = int.Parse(txtNoOfGuest.Text);
                        events.TotalPlanAmount = decimal.Parse(txtPlanAmount.Text);
                        events.IsActive = true;
                        events.InsertedDate = DateTime.Now;
                        ctx.AddTotblEvents(events);
                        ctx.SaveChanges();

                        MessageBox.Show("Record has been Saved Successfully!!!", "Record Saved", MessageBoxButtons.OK);
                        FillGrid();
                    }
                    getLatestEventID();
                    ClearFields();
                    dtEventDate.Focus();
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
            getLatestEventID();
            dtEventDate.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPlanAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtNoOfGuest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        
    }
}
