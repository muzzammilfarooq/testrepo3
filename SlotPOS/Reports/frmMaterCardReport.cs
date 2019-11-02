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
    public partial class frmMasterReport : Form
    {
        SlotPOSEntities ctx = new SlotPOSEntities();

        public frmMasterReport()
        {
            InitializeComponent();
        }

        private void FillCombo()
        {
            //var getCustomer = (from a in ctx.tblEvents
            //                select a).ToList();
            //getCustomer.Insert(0, new tblEvent { EventID = 0, CustomerName = "-- All --" });
            //if (getCustomer.ToList().Count > 0)
            //{
            //    cmbCustomer.DataSource = getCustomer;
            //    cmbCustomer.DisplayMember = "CustomerName";
            //    cmbCustomer.ValueMember = "EventID";
            //}
        }

        private void BindReport()
        {
            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("FromDate", dtFromDate.Value.ToShortDateString(), true));
            paramList.Add(new ReportParameter("ToDate", dtToDate.Value.ToShortDateString(), true));
         
            SlotDataSetTableAdapters.sp_CardBalanceDetailsTableAdapter ad_mis = new SlotDataSetTableAdapters.sp_CardBalanceDetailsTableAdapter();



            DataSet ds = new DataSet();
            ds.Tables.Add(ad_mis.GetData(dtFromDate.Value, dtToDate.Value));


            frmReportViewer rptPurReq = new frmReportViewer();
            rptPurReq.reportViewer1.Visible = true;
            Microsoft.Reporting.WinForms.ReportDataSource datasource1 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]);




            rptPurReq.reportViewer1.LocalReport.DataSources.Clear();
            rptPurReq.reportViewer1.LocalReport.DataSources.Add(datasource1);

            using (StreamReader rdlcSR = new StreamReader(@"RdlcReport\CardBalanceDetailsReport.rdlc"))
            {
                rptPurReq.reportViewer1.LocalReport.LoadReportDefinition(rdlcSR);
                rptPurReq.reportViewer1.LocalReport.Refresh();
                rptPurReq.reportViewer1.LocalReport.SetParameters(paramList);


            }
            //string exeFolder = (Path.GetDirectoryName(Application.StartupPath)).Substring(0, (Path.GetDirectoryName(Application.StartupPath)).Length - 3);
            //  string reportPath = @"RdlcReport\todayTransReport.rdlc";
            //rptPurReq.reportViewer1.LocalReport.ReportPath = reportPath;

            rptPurReq.reportViewer1.LocalReport.Refresh();
            rptPurReq.ShowDialog();
           
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
