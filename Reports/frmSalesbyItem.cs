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
    public partial class frmSalesbyItem : Form
    {
        SlotPOSEntities ctx = new SlotPOSEntities();

        public frmSalesbyItem()
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
                cmbCounter.DataSource = getCustomer;
                cmbCounter.DisplayMember = "CounterName";
                cmbCounter.ValueMember = "CounterID";
            }


            var getItem = (from a in ctx.tblItems
                               select a).ToList();
            getItem.Insert(0, new tblItem { ItemID = 0, ItemName = "-- All --" });
            if (getItem.ToList().Count > 0)
            {
                cmbItem.DataSource = getItem;
                cmbItem.DisplayMember = "ItemName";
                cmbItem.ValueMember = "ItemID";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSalesbyItem_Load(object sender, EventArgs e)
        {
            FillCombo();
            dtFromDate.Focus();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DateTime dtFrom = dtFromDate.Value.Date;
            DateTime dtTo = dtToDate.Value.Date;//.AddDays(1);

            long CounterID = long.Parse(cmbCounter.SelectedValue.ToString());
            long ItemID = long.Parse(cmbItem.SelectedValue.ToString());

           // SlotDataSetTableAdapters.GetDailyActivityReportTableAdapter ad_mis = new SlotDataSetTableAdapters.GetDailyActivityReportTableAdapter();
           // SlotDataSetTableAdapters.GetDailyActivityFooterReportTableAdapter ad_mis2 = new SlotDataSetTableAdapters.GetDailyActivityFooterReportTableAdapter();
            SlotDataSetTableAdapters.GetDailyActivityEventFooterReportTableAdapter ad_mis3 = new SlotDataSetTableAdapters.GetDailyActivityEventFooterReportTableAdapter();
            SlotDataSetTableAdapters.getNoOfEventFooterReportTableAdapter ad_mis4 = new SlotDataSetTableAdapters.getNoOfEventFooterReportTableAdapter();

            DataSet ds = new DataSet();
           // ds.Tables.Add(ad_mis.GetData(dtFrom, dtTo , CounterID, ItemID));
         //   ds.Tables.Add(ad_mis2.GetData(dtFrom, dtTo, CounterID, ItemID));
            ds.Tables.Add(ad_mis3.GetData(dtFrom, dtTo));
            ds.Tables.Add(ad_mis4.GetData(dtFrom, dtTo));

            List<ReportParameter> paramList = new List<ReportParameter>();

            paramList.Add(new ReportParameter("DateFrom", dtFrom.ToString("dd-MMM-yy"), true));
            paramList.Add(new ReportParameter("DateTo", dtTo.ToString("dd-MMM-yy"), true));

            if (cmbCounter.SelectedIndex > 0)
            {
                string counter = cmbCounter.Text;
                paramList.Add(new ReportParameter("Counter", counter, true));
            }
            else
            {
                paramList.Add(new ReportParameter("Counter", "All", true));
            }

            if (cmbItem.SelectedIndex > 0)
            {
                string item = cmbItem.Text;
                paramList.Add(new ReportParameter("Item", item, true));
            }
            else
            {
                paramList.Add(new ReportParameter("Item", "All", true));
            }

            frmReportViewer rptDailyActivity = new frmReportViewer();
            //rptDailyActivity.Visible = true;

            //ReportDataSource datasource = new ReportDataSource("GetDailyActivityReport", ds.Tables[0]);
           // ReportDataSource datasource1 = new ReportDataSource("GetDailyActivityFooterReport", ds.Tables[1]);
            ReportDataSource datasource2 = new ReportDataSource("GetDailyActivityEventFooterReport", ds.Tables[2]);
            ReportDataSource datasource3 = new ReportDataSource("getNoOfEventFooterReport", ds.Tables[3]);

            rptDailyActivity.reportViewer1.LocalReport.DataSources.Clear();
           // rptDailyActivity.reportViewer1.LocalReport.DataSources.Add(datasource);
           // rptDailyActivity.reportViewer1.LocalReport.DataSources.Add(datasource1);
            rptDailyActivity.reportViewer1.LocalReport.DataSources.Add(datasource2);
            rptDailyActivity.reportViewer1.LocalReport.DataSources.Add(datasource3);

            using (StreamReader rdlcSR = new StreamReader(@"RdlcReport\rptDailyActivity.rdlc"))
            {
                rptDailyActivity.reportViewer1.LocalReport.LoadReportDefinition(rdlcSR);
                rptDailyActivity.reportViewer1.LocalReport.Refresh();
                rptDailyActivity.reportViewer1.LocalReport.SetParameters(paramList);
            }

            rptDailyActivity.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
