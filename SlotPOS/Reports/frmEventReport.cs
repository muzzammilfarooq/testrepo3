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

namespace SlotPOS
{
    public partial class frmEventReport : Form
    {
        SlotPOSEntities ctx = new SlotPOSEntities();

        public frmEventReport()
        {
            InitializeComponent();
        }

        private void FillCombo()
        {
            var getCustomer = (from a in ctx.tblEvents
                            select a).ToList();
            getCustomer.Insert(0, new tblEvent { EventID = 0, CustomerName = "-- All --" });
            if (getCustomer.ToList().Count > 0)
            {
                cmbCustomer.DataSource = getCustomer;
                cmbCustomer.DisplayMember = "CustomerName";
                cmbCustomer.ValueMember = "EventID";
            }
        }

        private void BindReport()
        {
            DateTime dtFrom = dtFromDate.Value.Date;
            DateTime dtTo = dtToDate.Value.Date;//.AddDays(1);

            var BindPRQuery = from a in ctx.tblEvents
                              join b in ctx.tblEventDetails on a.EventID equals b.EventID
                              select new { a.EventDate, a.EventID, a.EventName, a.CustomerName, a.PhoneNumber, a.EmailAddress, a.TotalPlanAmount, b.AdvanceAmount, b.BalanceAmount, b.BalanceAmountRec, b.PaymentType };
            BindPRQuery = BindPRQuery.Where(r => r.EventDate >= dtFrom && r.EventDate <= dtTo);
            if (cmbCustomer.SelectedIndex > 0)
            {
                long _counterId = long.Parse(cmbCustomer.SelectedValue.ToString());
                BindPRQuery = BindPRQuery.Where(n => n.EventID == _counterId);
            }
            if (BindPRQuery.ToList().Count > 0)
            {
                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("DateFrom", dtFrom.ToString("dd-MMM-yy"), true));
                paramList.Add(new ReportParameter("DateTo", dtTo.ToString("dd-MMM-yy"), true));

                if (cmbCustomer.SelectedIndex > 0)
                {
                    string customer = cmbCustomer.Text;
                    paramList.Add(new ReportParameter("Customer", customer, true));
                }
                else
                {
                    paramList.Add(new ReportParameter("Customer", "All", true));
                }

                frmReportViewer rptPurReq = new frmReportViewer();
                rptPurReq.reportViewer1.Visible = true;
                Microsoft.Reporting.WinForms.ReportDataSource datasource = new Microsoft.Reporting.WinForms.ReportDataSource("getEventDetail", BindPRQuery.ToList());
                rptPurReq.reportViewer1.LocalReport.DataSources.Clear();
                rptPurReq.reportViewer1.LocalReport.DataSources.Add(datasource);
                using (StreamReader rdlcSR = new StreamReader(@"RdlcReport\rptEventDetail.rdlc"))
                {
                    rptPurReq.reportViewer1.LocalReport.LoadReportDefinition(rdlcSR);
                    rptPurReq.reportViewer1.LocalReport.Refresh();
                    rptPurReq.reportViewer1.LocalReport.SetParameters(paramList);
                }
                rptPurReq.ShowDialog();
            }
            else
                MessageBox.Show("No Record Found!!", "Alert", MessageBoxButtons.OK);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEventReport_Load(object sender, EventArgs e)
        {
            FillCombo();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            BindReport();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
