using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;


namespace SlotPOS.Reports
{
    public partial class frmUnRechargeAmount : Form
    {
        public frmUnRechargeAmount()
        {
            InitializeComponent();
        }

        private void frmUnRechargeAmount_Load(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime fromdate = Convert.ToDateTime(dtFromDate.Value.ToShortDateString());
                DateTime todate = Convert.ToDateTime(dtToDate.Value.ToShortDateString());


                SlotDataSetTableAdapters.Sp_RechargeAmountUnusedBalanceTableAdapter ad_mis = new SlotDataSetTableAdapters.Sp_RechargeAmountUnusedBalanceTableAdapter();
                DataSet ds = new DataSet();
                ds.Tables.Add(ad_mis.GetData(fromdate, todate));

                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("DateFrom", fromdate.ToString("dd-MMM-yy"), true));
                paramList.Add(new ReportParameter("DateTo", todate.ToString("dd-MMM-yy"), true));

                frmReportViewer rptDailyActivity = new frmReportViewer();
             

                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);


                rptDailyActivity.reportViewer1.LocalReport.DataSources.Clear();
                rptDailyActivity.reportViewer1.LocalReport.DataSources.Add(datasource);

                using (StreamReader rdlcSR = new StreamReader(@"RdlcReport\rptUnRechargeAmount.rdlc"))
                {
                    rptDailyActivity.reportViewer1.LocalReport.LoadReportDefinition(rdlcSR);
                    rptDailyActivity.reportViewer1.LocalReport.Refresh();
                    rptDailyActivity.reportViewer1.LocalReport.SetParameters(paramList);
                }

                rptDailyActivity.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
