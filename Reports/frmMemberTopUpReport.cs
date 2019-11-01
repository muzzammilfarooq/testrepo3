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
    public partial class frmMemberTopUpReport : Form
    {
        public frmMemberTopUpReport()
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

            SlotDataSetTableAdapters.sp_MemberFreeTopUpReportTableAdapter ad_mis = new SlotDataSetTableAdapters.sp_MemberFreeTopUpReportTableAdapter();
            SlotDataSetTableAdapters.sp_MemberPaidTopUpReportTableAdapter ad_mis1 = new SlotDataSetTableAdapters.sp_MemberPaidTopUpReportTableAdapter();

            DataSet ds = new DataSet();
            ds.Tables.Add(ad_mis.GetData(dtFrom, dtTo));
            ds.Tables.Add(ad_mis1.GetData(dtFrom, dtTo));


            List<ReportParameter> paramList = new List<ReportParameter>();

            paramList.Add(new ReportParameter("FromDate", dtFrom.ToString("dd-MMM-yy"), true));
            paramList.Add(new ReportParameter("ToDate", dtTo.ToString("dd-MMM-yy"), true));


            frmReportViewer rptPurReq = new frmReportViewer();
            rptPurReq.reportViewer1.Visible = true;
            Microsoft.Reporting.WinForms.ReportDataSource datasource = new Microsoft.Reporting.WinForms.ReportDataSource("MemberFreeTopUp", ds.Tables[0]);
            Microsoft.Reporting.WinForms.ReportDataSource datasource1 = new Microsoft.Reporting.WinForms.ReportDataSource("MemberPaidTopUp", ds.Tables[1]);

            rptPurReq.reportViewer1.LocalReport.DataSources.Clear();
            rptPurReq.reportViewer1.LocalReport.DataSources.Add(datasource);
            rptPurReq.reportViewer1.LocalReport.DataSources.Add(datasource1);

            using (StreamReader rdlcSR = new StreamReader(@"RdlcReport\rptMemeberTopUpReport.rdlc"))
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
