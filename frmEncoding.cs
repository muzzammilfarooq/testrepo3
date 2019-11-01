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
    public partial class frmEncoding : Form
    {
        string portname = "";
        del MyDlg;
        string entranceName ="";
        delegate void del(string rfidCode);
        public frmEncoding()
        {
            InitializeComponent();
        }
        SlotPOSEntities spe = new SlotPOSEntities();


        public frmEncoding(string portnm)
        {
            InitializeComponent();
            portname = portnm;
            //lblA.Text = "000";
            //lblB.Text = "000";
            MyDlg = new del(GetCardCode);
            serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
        }
        public void GetCardCode(string rfidCode)
        {
            if (rfidCode.Length == 10)
            {
                if (rbtnRC.Checked || rbtnRWB.Checked)
                {
                    if (rbtnAladinEntrance.Checked || rbtnClubEntrance.Checked)
                    {
                        List<tblRFID> lstrfid = spe.tblRFIDs.Where(tblRFID => tblRFID.RFIDCode == rfidCode).ToList();
                        if (lstrfid.Count > 0)
                        {
                            label1.Visible = true;
                            label1.ForeColor = Color.Red;
                            label1.Text = "Card Already Encoded.";

                        }
                        else
                        {
                            if (rbtnClubEntrance.Checked)
                            {
                                entranceName = "Club";
                            }
                            else if (rbtnAladinEntrance.Checked)
                            {
                                entranceName = "Aladin";
                            }

                            label1.Visible = true;
                            label1.ForeColor = Color.Green;
                            label1.Text = "Encoded Successfully.";

                            tblRFID tbrfid = new tblRFID();
                            tbrfid.RFIDCode = rfidCode;
                            tbrfid.Entrance = entranceName;
                            if (rbtnRWB.Checked)
                            {
                                tbrfid.CardType = "RFIDWatch";
                                tbrfid.IsRFIDWatch = true;
                            }
                            else
                            {
                                tbrfid.IsRFIDWatch = false;
                            }
                            tbrfid.UpdateDateTime = DateTime.Now;
                            spe.tblRFIDs.AddObject(tbrfid);
                            spe.SaveChanges();


                        }
                    }
                    else
                    {
                        label1.Visible = true;
                        label1.Text = "Please Select Card Entrance.";
                    }
                }
                else
                {
                    label1.Visible = true;
                    label1.Text = "Please Select Card Category.";
                }
            }
        }
       

        private void frmEncoding_Load(object sender, EventArgs e)
        {
           
            serialPort1.PortName = portname;
            serialPort1.BaudRate = 9600;
            serialPort1.Open();

           
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
         //   if (rbtnAladinEntrance.Checked || rbtnClubEntrance.Checked)
            {
                try
                {
                    String s = serialPort1.ReadLine().TrimEnd();

                    this.BeginInvoke(MyDlg, s);
                }
                catch
                {

                }
            }
            //else
            //{

            //    MessageBox.Show("Please Select Card Entrance");
            //}
        }

        private void frmEncoding_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
        }

        private void rbtnAladinEntrance_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtnClubEntrance_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
