using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SlotPOS
{
    public partial class frmEvent : Form
    {
        SlotPOSEntities ctx = new SlotPOSEntities();

        public frmEvent()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillComboBox()
        {
            var fillLOT = (from a in ctx.tblEvents
                           select a).ToList();
            fillLOT.Insert(0, new tblEvent { EventID = 0, CustomerName = "--Select Customer--" });
            if (fillLOT.ToList().Count > 0)
            {
                cmbCustomer.DataSource = fillLOT;
                cmbCustomer.ValueMember = "EventID";
                cmbCustomer.DisplayMember = "CustomerName";
            }
        }

        private void FillPaymentType()
        {
            cmbPaymentType.Items.Insert(0, "-- Select Payment Type --");
            cmbPaymentType.Items.Insert(1, "Cash");
            cmbPaymentType.Items.Insert(2, "Credit Card");
            cmbPaymentType.SelectedIndex = 0;
        }

        private void FillGrid()
        {
            var getRecord = from a in ctx.tblEventDetails
                            join d in ctx.tblEvents on a.EventID equals d.EventID
                            select new { a.EventDetailID, a.EventID, d.EventDate, d.EventName, d.CustomerName, d.PhoneNumber, d.EmailAddress, d.TotalPlanAmount, a.AdvanceAmount, a.BalanceAmount, a.BalanceAmountRec};
            if (txtSearchEventDate.Text != "")
            {
                DateTime _eventDate = DateTime.Parse(txtSearchEventDate.Text);
                getRecord = getRecord.Where(r => r.EventDate == _eventDate);
            }
            if (txtSearchCustomerName.Text != "")
            {
                string _customerName = txtSearchCustomerName.Text;
                getRecord = getRecord.Where(r => r.CustomerName.Contains(_customerName));
            }
            if (txtSearchPhNo.Text != "")
            {
                string _phNo = txtPhNo.Text;
                getRecord = getRecord.Where(r => r.PhoneNumber.Contains(_phNo));
            }
            if (getRecord.ToList().Count > 0)
            {
                dgvEvent.AutoGenerateColumns = false;
                dgvEvent.DataSource = getRecord;
            }
        }

        private void ClearFields()
        {
            cmbPaymentType.SelectedIndex = 0;
            cmbCustomer.SelectedIndex = 0;
            txtEventDate.Text = "";
            txtEventName.Text = "";
            txtPhNo.Text = "";
            txtEmail.Text = "";
            txtSlotTime.Text = "";
            txtNoOfGuest.Text = "";
            txtPlanAmount.Text = "";
            txtAdvanceAmount.Text = "";
            txtBalanceAmount.Text = "";
            txtBalAmountRec.Text = "";
            cmbCustomer.Focus();
        }

        private void getLatestEventDtlID()
        {
            var getLastRecord = (from a in ctx.tblEventDetails
                                 orderby a.EventDetailID descending
                                 select a).Take(1).SingleOrDefault();
            if (getLastRecord != null)
            {
                long last = getLastRecord.EventDetailID + 1;
                txtEventTransID.Text = last.ToString();
            }
            else
            {
                txtEventTransID.Text = "1";
            }
        }

        private bool ValidateForm()
        {
            ep.Clear();
            if (cmbPaymentType.SelectedIndex == 0)
            {
                ep.SetError(cmbCustomer, "Please Select Payment Type.");
                return false;
            }
            if (cmbCustomer.SelectedIndex == 0)
            {
                ep.SetError(cmbCustomer, "Please Select Customer.");
                return false;
            }
            decimal balAmountRec = txtBalAmountRec.Text == "" ? 0 : decimal.Parse(txtBalAmountRec.Text);
            if (balAmountRec > decimal.Parse(txtBalanceAmount.Text))
            {
                MessageBox.Show("You have Entered the Amount which is greater than Balance Amount", "Error",MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void getEventByID(long _eventID)
        {
            var checkData = (from b in ctx.tblEventDetails
                             where b.EventID == _eventID
                             select b);
            if (checkData.ToList().Count > 0)
            {

                var getEventData = (from b in ctx.tblEventDetails
                                    join c in ctx.tblEvents on b.EventID equals c.EventID
                                    where b.EventID == _eventID
                                    orderby b.EventDetailID descending
                                    select new { c.EventDate, c.EventName, c.PhoneNumber, c.EmailAddress, c.SlotTime, c.NoOfGuest, c.TotalPlanAmount, b.AdvanceAmount, b.BalanceAmount, b.BalanceAmountRec}).First();

                if (getEventData != null)
                {
                    txtAdvanceAmount.ReadOnly = true;
                    txtEventDate.Text = DateTime.Parse(getEventData.EventDate.ToString()).ToString("dd-MMM-yyyy");
                    txtEventName.Text = getEventData.EventName;
                    txtPhNo.Text = getEventData.PhoneNumber;
                    txtEmail.Text = getEventData.EmailAddress;
                    txtSlotTime.Text = getEventData.SlotTime;
                    txtNoOfGuest.Text = getEventData.NoOfGuest.ToString();
                    txtPlanAmount.Text = getEventData.TotalPlanAmount.ToString();
                    txtAdvanceAmount.Text = getEventData.AdvanceAmount.ToString();
                    txtBalanceAmount.Text = getEventData.BalanceAmount.ToString();
                    cmbPaymentType.Focus();
                }
            }
            else
            {
                var getData = (from a in ctx.tblEvents
                               where a.EventID == _eventID
                               select a).SingleOrDefault();
                if (getData != null)
                {
                    txtEventDate.Text = getData.EventDate.ToString();
                    txtEventName.Text = getData.EventName;
                    txtPhNo.Text = getData.PhoneNumber;
                    txtEmail.Text = getData.EmailAddress;
                    txtSlotTime.Text = getData.SlotTime;
                    txtNoOfGuest.Text = getData.NoOfGuest.ToString();
                    txtPlanAmount.Text = getData.TotalPlanAmount.ToString();
                    cmbPaymentType.Focus();
                }
            }
        }

        private void frmEvent_Load(object sender, EventArgs e)
        {
            FillPaymentType();
            FillComboBox();
            FillGrid();
            getLatestEventDtlID();
            cmbCustomer.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm() == true)
                {
                    tblEventDetail eventDtl = new tblEventDetail();
                    if (MessageBox.Show("Are you sure you want to Add New Record", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        eventDtl.EventID = long.Parse(cmbCustomer.SelectedValue.ToString());
                        eventDtl.AdvanceAmount = decimal.Parse(txtAdvanceAmount.Text);
                        if(txtBalAmountRec.Text == "" )
                            eventDtl.BalanceAmount = decimal.Parse(txtBalanceAmount.Text);
                        else
                            eventDtl.BalanceAmount = decimal.Parse(txtBalanceAmount.Text) - decimal.Parse(txtBalAmountRec.Text);
                        eventDtl.PaymentType = cmbPaymentType.Text;
                        eventDtl.BalanceAmountRec = txtBalAmountRec.Text == "" ? 0 : decimal.Parse(txtBalAmountRec.Text);
                        eventDtl.InsertedDate = DateTime.Now;
                        ctx.AddTotblEventDetails(eventDtl);
                        ctx.SaveChanges();

                        MessageBox.Show("Record has been Saved Successfully!!!", "Record Saved", MessageBoxButtons.OK);
                        FillGrid();
                    }
                    getLatestEventDtlID();
                    ClearFields();
                    cmbCustomer.Focus();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex > 0)
            {
                getEventByID(long.Parse(cmbCustomer.SelectedValue.ToString()));
                if (txtBalanceAmount.Text != "" && decimal.Parse(txtBalanceAmount.Text) == 0M)
                {
                    MessageBox.Show("This Event Has Been Closed!!", "Event", MessageBoxButtons.OK);
                    btnSave.Visible = false;
                    return;
                }
                else
                    btnSave.Visible = true;
            }
        }

        private void txtAdvanceAmount_TextChanged(object sender, EventArgs e)
        {
            decimal planAmount = txtPlanAmount.Text == "" ? 0 : decimal.Parse(txtPlanAmount.Text);
            decimal advanceAmount = txtAdvanceAmount.Text == "" ? 0 : decimal.Parse(txtAdvanceAmount.Text);
            decimal balanceAmount = txtBalanceAmount.Text == "" ? 0 : decimal.Parse(txtBalanceAmount.Text);

            balanceAmount = planAmount - advanceAmount;
            txtBalanceAmount.Text = balanceAmount.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAdvanceAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBalanceAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBalAmountRec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void PrintReport(long _eventID)
        {
            var getPrintData = from a in ctx.tblEvents
                               join b in ctx.tblEventDetails on a.EventID equals b.EventID
                               where a.EventID == _eventID
                               select new { a.EventDate, a.EventName, a.CustomerName, a.PhoneNumber, a.EmailAddress, a.SlotTime, a.NoOfGuest, a.TotalPlanAmount, TransactionDate = b.InsertedDate, b.AdvanceAmount, b.BalanceAmount, b.BalanceAmountRec};
            if (getPrintData.ToList().Count > 0)
            {
                frmReportViewer rptRequsition = new frmReportViewer();
                rptRequsition.reportViewer1.Visible = true;
                Microsoft.Reporting.WinForms.ReportDataSource datasource = new Microsoft.Reporting.WinForms.ReportDataSource("getEventPreview", getPrintData.ToList());
                rptRequsition.reportViewer1.LocalReport.DataSources.Clear();
                rptRequsition.reportViewer1.LocalReport.DataSources.Add(datasource);
                using (StreamReader rdlcSR = new StreamReader(@"RdlcReport\rptEventPreview.rdlc"))
                {
                    rptRequsition.reportViewer1.LocalReport.LoadReportDefinition(rdlcSR);

                    rptRequsition.reportViewer1.LocalReport.Refresh();
                }
                rptRequsition.ShowDialog();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintReport(long.Parse(cmbCustomer.SelectedValue.ToString()));
        }
    }
}
