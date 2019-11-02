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
using SlotPOS.Class;

namespace SlotPOS
{
    public partial class frmDailyActivityReport : Form
    {
        SlotPOSEntities ctx = new SlotPOSEntities();

        public frmDailyActivityReport()
        {
            InitializeComponent();
        }

        private void FillCombo()
        {
            var getCustomer = (from a in ctx.tblCounters
                               select a).ToList();
            getCustomer.Insert(0, new tblCounter { CounterID = 0, CounterName = "-- All --" });
            if (getCustomer.ToList().Count > 0)
            {
                cmbCustomer.DataSource = getCustomer;
                cmbCustomer.DisplayMember = "CounterName";
                cmbCustomer.ValueMember = "CounterID";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            FillCombo();
            dtFromDate.Focus();
        }

        private void btnView_Click(object sender, EventArgs e)
        {

            //DateTime date = dtFromDate.Value.Date;
            //long CounterID = long.Parse(cmbCustomer.SelectedValue.ToString());

            //SlotDataSetTableAdapters.GetDailyActivityReportTableAdapter ad_mis = new SlotDataSetTableAdapters.GetDailyActivityReportTableAdapter();
            //SlotDataSetTableAdapters.GetDailyActivityFooterReportTableAdapter ad_mis2 = new SlotDataSetTableAdapters.GetDailyActivityFooterReportTableAdapter();
            //SlotDataSetTableAdapters.GetDailyActivityEventFooterReportTableAdapter ad_mis3 = new SlotDataSetTableAdapters.GetDailyActivityEventFooterReportTableAdapter();
            //SlotDataSetTableAdapters.getNoOfEventFooterReportTableAdapter ad_mis4 = new SlotDataSetTableAdapters.getNoOfEventFooterReportTableAdapter();

            //DataSet ds = new DataSet();
            //ds.Tables.Add(ad_mis.GetData(date, CounterID));
            //ds.Tables.Add(ad_mis2.GetData(date, CounterID));
            //ds.Tables.Add(ad_mis3.GetData(date));
            //ds.Tables.Add(ad_mis4.GetData(date));

            //List<ReportParameter> paramList = new List<ReportParameter>();

            //string DataParameter = DateTime.Parse(dtFromDate.Value.ToString()).ToString("dd-MMM-yy");
            //paramList.Add(new ReportParameter("Date", DataParameter, true));

            //frmReportViewer rptDailyActivity = new frmReportViewer();
            ////rptDailyActivity.Visible = true;

            //ReportDataSource datasource = new ReportDataSource("GetDailyActivityReport", ds.Tables[0]);
            //ReportDataSource datasource1 = new ReportDataSource("GetDailyActivityFooterReport", ds.Tables[1]);
            //ReportDataSource datasource2 = new ReportDataSource("GetDailyActivityEventFooterReport", ds.Tables[2]);
            //ReportDataSource datasource3 = new ReportDataSource("getNoOfEventFooterReport", ds.Tables[3]);

            //rptDailyActivity.reportViewer1.LocalReport.DataSources.Clear();
            //rptDailyActivity.reportViewer1.LocalReport.DataSources.Add(datasource);
            //rptDailyActivity.reportViewer1.LocalReport.DataSources.Add(datasource1);
            //rptDailyActivity.reportViewer1.LocalReport.DataSources.Add(datasource2);
            //rptDailyActivity.reportViewer1.LocalReport.DataSources.Add(datasource3);

            //using (StreamReader rdlcSR = new StreamReader(@"RdlcReport\rptDailyActivity.rdlc"))
            //{
            //    rptDailyActivity.reportViewer1.LocalReport.LoadReportDefinition(rdlcSR);
            //    rptDailyActivity.reportViewer1.LocalReport.Refresh();
            //    rptDailyActivity.reportViewer1.LocalReport.SetParameters(paramList);
            //}

            //rptDailyActivity.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
