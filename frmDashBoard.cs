using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SlotPOS.Class;

namespace SlotPOS
{
    public partial class DashBoard : Form
    {

        public static bool? IsRegular = false;
        public static bool? IsSSMember = false;
        public static bool? IsGuest = false;
        public static bool? IsEvent = false;
        public static bool? IsMaster = false;
        public DashBoard()
        {
            InitializeComponent();
        }

        public DashBoard(string _username)
        {
            InitializeComponent();
            lblWelcome.Text = _username;
            getUserRights();
        }

        private void getUserRights()
        {
            SlotPOSEntities ctx = new SlotPOSEntities();
            long userId = clsGlobalVar.UserID;

            var getDetail = (from a in ctx.tblUsers
                             where a.UserID == userId
                             select a).SingleOrDefault();
            if (getDetail != null)
            {
                if (getDetail.UserSetup == true)
                    pictureBox4.Visible = true;
                if (getDetail.ItemCategorySetup == true)
                    pictureBox6.Visible = true;
                if (getDetail.ItemSetup == true)
                    pictureBox8.Visible = true;
                if (getDetail.LOTSetup == true)
                    frmLotSetup.Visible = true;
                if (getDetail.TicketIssuance == true)
                    button2.Visible = true;
                if (getDetail.PointOfSale == true)
                    pictureBox12.Visible = true;
                if (getDetail.SlotScreen == true)
                    pictureBox19.Visible = true;
                if (getDetail.EventSetup == true)
                    pictureBox10.Visible = true;
                if (getDetail.EventTransaction == true)
                    pictureBox14.Visible = true;
                if (getDetail.Reports == true)
                    pictureBox16.Visible = true;
                if (getDetail.Encoding == true)
                    pictureBox20.Visible = true;
                if (getDetail.IsRegular != null)
                {
                    IsRegular = getDetail.IsRegular;
                }
                if (getDetail.IsSSMember != null)
                {
                    IsSSMember = getDetail.IsSSMember;
                }

                if (getDetail.IsGuest != null)
                {
                    IsGuest = getDetail.IsGuest;
                }
                if (getDetail.IsEvent != null)
                {
                    IsEvent = getDetail.IsEvent;
                }
                if (getDetail.IsMasterCard != null)
                {
                    IsMaster = getDetail.IsMasterCard;
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmCounterSetup CounterSetup = new frmCounterSetup();
            CounterSetup.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            frmItemCategorySetup ItemCategory = new frmItemCategorySetup();
            ItemCategory.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            frmItemSetup ItemSetup = new frmItemSetup();
            ItemSetup.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            frmEventSetup EventSetup = new frmEventSetup();
            EventSetup.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            frmPortSelect SlotPOS = new frmPortSelect("POS");
            SlotPOS.Show();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            frmEvent Event = new frmEvent();
            Event.Show();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            frmReports Report = new frmReports();
            Report.Show();
        }

        private void frmLotSetup_Click(object sender, EventArgs e)
        {
            Setup_Forms.frmLotSetup lotSetup = new Setup_Forms.frmLotSetup();
            lotSetup.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmTicketIssue ticketIssue = new frmTicketIssue();
            ticketIssue.Show();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            frmSlotScreen SlotScreen = new frmSlotScreen();
            SlotScreen.Show();
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            frmPortSelect Encoding = new frmPortSelect("Encoding");
            Encoding.Show();
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            frmPortSelect balance = new frmPortSelect("BCheck");
            balance.Show();

        }
    }
}
