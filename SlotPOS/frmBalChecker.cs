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
    public partial class frmBalChecker : Form
    {
        SlotPOSEntities slt = new SlotPOSEntities();
        string portname = "";
        del MyDlg;
        delegate void del(string rfidCode);
        int timerValue = 5000;
        public frmBalChecker()
        {
            InitializeComponent();
        }

        public frmBalChecker(string portnm)
        {
            InitializeComponent();
            portname = portnm;
            //lblA.Text = "000";
            //lblB.Text = "000";
            MyDlg = new del(GetBalance);
            serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort1.ReadLine().TrimEnd();
                if (data.Length == 10)
                {
                    this.BeginInvoke(MyDlg, data);
                }
            }
            catch
            {

            }
        }
        public void GetBalance(string rfidCode)
        {
            if (rfidCode.Length == 10)
            {
               // rfidCode = "0013938919";
                var item = slt.bal_checker(rfidCode).ToList();

                if (item[0].IsActive==true)
                {
                    lblStatus.Text = "Active";
                }
                else if (item[0].IsActive == false)
                {
                    lblStatus.Text = "Not Active";
                }
                else
                {
                    lblStatus.Text = "Not Registered";
                }

                lblCardType.Text = item[0].CardType;
                lblEntranceType.Text = item[0].EntranceType;
                lblAVB.Text = item[0].Amount.ToString();
                lblMemberBal.Text = item[0].MemberMonthlyAmount.ToString();

                lblCB.Text = item[0].ConsumedBalance.ToString();

                lblTdyConAmnt.Text = item[0].ToDayCB.ToString();

                lbltDayRchrgAmnt.Text = item[0].ToDayRechargedAmnt.ToString();

                 timerValue = 5000;
            }
        }

        private void frmBalChecker_Load(object sender, EventArgs e)
        {
            serialPort1.PortName = portname;
            serialPort1.BaudRate = 9600;
            serialPort1.Open();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblAVB_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblCB_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timerValue == 0)
            {
                lblAVB.Text = "";
                lblCB.Text = "";
                lblStatus.Text = "";
                lbltDayRchrgAmnt.Text = "";
                lblTdyConAmnt.Text = "";
                lblCardType.Text = "";
                lblMemberBal.Text = "";
                lblEntranceType.Text = "";

            }
            if(timerValue>0)
            timerValue -= 5000;
        }
    }
}
