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
    public partial class frmSalesbyPaymentMethod : Form
    {
        SlotPOSEntities ctx = new SlotPOSEntities();

        public frmSalesbyPaymentMethod()
        {
            InitializeComponent();
        }

        private void FillCombo()
        {
            cmbPaymentType.Items.Add("-- All --");
            cmbPaymentType.Items.Add("Cash");
            cmbPaymentType.Items.Add("Credit Card");
            cmbPaymentType.SelectedIndex = 0;

            var getReqBy = (from a in ctx.tblCounters
                            select a).ToList();
            getReqBy.Insert(0, new tblCounter { CounterID = 0, CounterName = "-- All --" });
            if (getReqBy.ToList().Count > 0)
            {
                cmbCounter.DataSource = getReqBy;
                cmbCounter.DisplayMember = "CounterName";
                cmbCounter.ValueMember = "CounterID";
            }
        }

        private void BindReport()
        {
            DateTime dtFrom = dtFromDate.Value.Date;
            DateTime dtTo = dtToDate.Value.Date;//.AddDays(1);

            var BindPRQuery = from a in ctx.tblPOS
                              join b in ctx.tblPOSDetails on a.POSID equals b.POSID
                              join d in ctx.tblItemCategories on b.ItemCategoryID equals d.ItemCategoryID
                              join f in ctx.tblItems on b.ItemID equals f.ItemID
                              where a.Status == "Done"
                              select new { f.ItemName, a.POSID, b.Quantity, b.Price, b.NetAmount, a.PaymentType, a.SaleDate, a.CounterID};
            BindPRQuery = BindPRQuery.Where(r => r.SaleDate >= dtFrom && r.SaleDate <= dtTo);
            if (cmbCounter.SelectedIndex > 0)
            {
                long _counterId = long.Parse(cmbCounter.SelectedValue.ToString());
                BindPRQuery = BindPRQuery.Where(n => n.CounterID == _counterId);
            }
            if (cmbPaymentType.SelectedIndex > 0)
            {
                string  _paymentType = cmbPaymentType.Text;
                BindPRQuery = BindPRQuery.Where(n => n.PaymentType == _paymentType);
            }
            if (BindPRQuery.ToList().Count > 0)
            {
                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("DateFrom", dtFrom.ToString("dd-MMM-yy"), true));
                paramList.Add(new ReportParameter("DateTo", dtTo.ToString("dd-MMM-yy"), true));

                if (cmbCounter.SelectedIndex > 0)
                {
                    string _counter = cmbCounter.Text;
                    paramList.Add(new ReportParameter("Counter", _counter, true));
                }
                else
                {
                    paramList.Add(new ReportParameter("Counter", "All", true));
                }
                if (cmbPaymentType.SelectedIndex > 0)
                {
                    string _paymentType = cmbPaymentType.Text;
                    paramList.Add(new ReportParameter("PaymentMethod", _paymentType, true));
                }
                else
                {
                    paramList.Add(new ReportParameter("PaymentMethod", "N/A", true));
                }

                frmReportViewer rptPurReq = new frmReportViewer();
                rptPurReq.reportViewer1.Visible = true;
                Microsoft.Reporting.WinForms.ReportDataSource datasource = new Microsoft.Reporting.WinForms.ReportDataSource("getSalesByPaymentMethod", BindPRQuery.ToList());
                rptPurReq.reportViewer1.LocalReport.DataSources.Clear();
                rptPurReq.reportViewer1.LocalReport.DataSources.Add(datasource);
                using (StreamReader rdlcSR = new StreamReader(@"RdlcReport\rptSalesByPaymentMethod.rdlc"))
                {
                    rptPurReq.reportViewer1.LocalReport.LoadReportDefinition(rdlcSR);
                    rptPurReq.reportViewer1.LocalReport.Refresh();
                    rptPurReq.reportViewer1.LocalReport.SetParameters(paramList);
                }
                //string exeFolder = (Path.GetDirectoryName(Application.StartupPath)).Substring(0, (Path.GetDirectoryName(Application.StartupPath)).Length - 3);
                //string reportPath = Path.Combine(exeFolder, @"Reports\rptMISRequisition.rdlc");
                //rptPurReq.reportViewer1.LocalReport.ReportPath = reportPath;
                //rptPurReq.reportViewer1.LocalReport.SetParameters(paramList);
                //rptPurReq.reportViewer1.LocalReport.Refresh();
                rptPurReq.ShowDialog();
            }
            else
                MessageBox.Show("No Record Found!!", "Alert", MessageBoxButtons.OK);
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
            FillCombo();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            BindReport();
        }
    }
}
