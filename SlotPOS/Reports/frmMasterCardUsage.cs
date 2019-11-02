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
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace SlotPOS.Reports
{
    public partial class frmMasterCardUsage : Form
    {
        public frmMasterCardUsage()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DateTime dtFrom = dtFromDate.Value.Date;
            DateTime dtTo = dtToDate.Value.Date;//.AddDays(1);

            SlotDataSetTableAdapters.Sp_MasterCardUsageReportTableAdapter ad_mis = new SlotDataSetTableAdapters.Sp_MasterCardUsageReportTableAdapter();
            DataSet ds = new DataSet();
            ds.Tables.Add(ad_mis.GetData(dtFrom, dtTo));

            List<ReportParameter> paramList = new List<ReportParameter>();

            paramList.Add(new ReportParameter("FromDate", dtFrom.ToString("dd-MMM-yy"), true));
            paramList.Add(new ReportParameter("ToDate", dtTo.ToString("dd-MMM-yy"), true));


            frmReportViewer rptPurReq = new frmReportViewer();
            rptPurReq.reportViewer1.Visible = true;
            Microsoft.Reporting.WinForms.ReportDataSource datasource1 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]);




            rptPurReq.reportViewer1.LocalReport.DataSources.Clear();
            rptPurReq.reportViewer1.LocalReport.DataSources.Add(datasource1);

            using (StreamReader rdlcSR = new StreamReader(@"RdlcReport\rptMasterCardUsage.rdlc"))
            {
                rptPurReq.reportViewer1.LocalReport.LoadReportDefinition(rdlcSR);
                rptPurReq.reportViewer1.LocalReport.Refresh();
                rptPurReq.reportViewer1.LocalReport.SetParameters(paramList);
            }
            
            rptPurReq.reportViewer1.LocalReport.Refresh();
            rptPurReq.ShowDialog();
            
        }
    }
}
