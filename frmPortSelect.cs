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
    public partial class frmPortSelect : Form
    {
        string frm = "";
        public frmPortSelect()
        {
            InitializeComponent();
        }
        public frmPortSelect(string stringFrm)
        {
            InitializeComponent();
            frm = stringFrm;
        }

        private void frmPortSelect_Load(object sender, EventArgs e)
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; i++)
            {
                comboBox1.Items.Add(ports[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (frm=="POS")
                {
                    this.Hide();
                    frmSlotPOS fm1 = new frmSlotPOS(comboBox1.SelectedItem.ToString());
                    fm1.Show();
                }
                else if(frm=="Encoding")
                {
                    this.Hide();
                    frmEncoding fm1 = new frmEncoding(comboBox1.SelectedItem.ToString());
                    fm1.Show();
                }
                else if (frm == "BCheck")
                {
                    this.Hide();
                    frmBalChecker balance = new frmBalChecker(comboBox1.SelectedItem.ToString());
                    balance.Show();
                }
                else if (frm== "UserTransReport")
                {
                    this.Hide();
                    UserTransReport UT = new UserTransReport(comboBox1.SelectedItem.ToString());
                    UT.Show();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; i++)
            {
                comboBox1.Items.Add(ports[i]);
            }
        }
    }
}
