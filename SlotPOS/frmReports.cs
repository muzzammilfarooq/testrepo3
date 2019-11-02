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
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //frmSalesbyItem SalesbyItem = new frmSalesbyItem();
            //SalesbyItem.Show();
            TodayTransTReport SalesReport = new TodayTransTReport();
            SalesReport.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            frmSalesbyPaymentMethod SalesbyPaymentMethod = new frmSalesbyPaymentMethod();
            SalesbyPaymentMethod.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            frmEventReport EventReport = new frmEventReport();
            EventReport.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            frmDailyActivityReport dailyActivity = new frmDailyActivityReport();
            dailyActivity.Show();
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            //TodayTransTReport frmTodatTransactionReport = new TodayTransTReport();
            frmPortSelect frmPort = new frmPortSelect("UserTransReport");
            frmPort.Show();
            //UserTransReport frmTodatTransactionReport = new UserTransReport();
            //frmTodatTransactionReport.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ConsumptionReport frmConsumptionReport = new ConsumptionReport();
            frmConsumptionReport.Show();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            frmCardReport frmCard = new frmCardReport();
            frmCard.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            PromotionReport frmPromotion = new PromotionReport();
            frmPromotion.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Reports.frmMasterCardUsage f = new Reports.frmMasterCardUsage();
            f.Show();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Reports.frmMemberTopUpReport m = new Reports.frmMemberTopUpReport();
            m.Show();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Reports.frmExpiredBalanceReport ex = new Reports.frmExpiredBalanceReport();
            ex.Show();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Reports.frmUnRechargeAmount f = new Reports.frmUnRechargeAmount();
            f.Show();
        }

    }
}
