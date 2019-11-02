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
    public partial class frmDeduction : Form
    {

        float? TotolAmount;
        public frmDeduction()
        {
            InitializeComponent();
        }

        public frmDeduction(float? totAmount)
        {
            InitializeComponent();
            TotolAmount = totAmount;
        }

        private void frmDeduction_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                clsGlobalVar.DeductionAmount = float.Parse(textBox1.Text);
                this.Close();
                //if (clsGlobalVar.IsNewCard)
                //{
                //    double BasicCardAmount = Convert.ToDouble(clsGlobalVar.BasicCardAmount == null ? 0 : clsGlobalVar.BasicCardAmount);
                //    if (float.Parse(textBox1.Text) + BasicCardAmount < TotolAmount || (float.Parse(textBox1.Text) + BasicCardAmount <= TotolAmount && clsGlobalVar.FreeEntry == true))
                //    {
                //        clsGlobalVar.DeductionAmount = float.Parse(textBox1.Text);
                //        this.Close();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Deduction Amount can't be less than Entry Amount.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
                //else
                //{
                //    if (float.Parse(textBox1.Text) < TotolAmount || (float.Parse(textBox1.Text) <= TotolAmount && clsGlobalVar.FreeEntry == true))
                //    {
                //        clsGlobalVar.DeductionAmount = float.Parse(textBox1.Text);
                //        this.Close();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Deduction Amount Must be less than Total Amount.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }    
                //}
                
            }
            else
            {
                MessageBox.Show("Insert Deduction Amount.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text != string.Empty)
                {
                    clsGlobalVar.DeductionAmount = float.Parse(textBox1.Text);
                    this.Close();
                    //if (clsGlobalVar.IsNewCard)
                    //{
                    //    double BasicCardAmount = Convert.ToDouble(clsGlobalVar.BasicCardAmount == null ? 0 : clsGlobalVar.BasicCardAmount);
                    //    if (float.Parse(textBox1.Text) + BasicCardAmount < TotolAmount || (float.Parse(textBox1.Text) + BasicCardAmount <= TotolAmount && clsGlobalVar.FreeEntry == true))
                    //    {
                    //        clsGlobalVar.DeductionAmount = float.Parse(textBox1.Text);
                    //        this.Close();
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Deduction Amount can't be less than Entry Amount.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //}
                    //else
                    //{
                    //    if (float.Parse(textBox1.Text) < TotolAmount || (float.Parse(textBox1.Text) <= TotolAmount && clsGlobalVar.FreeEntry == true))
                    //    {
                    //        clsGlobalVar.DeductionAmount = float.Parse(textBox1.Text);
                    //        this.Close();
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Deduction Amount Must be less then Total Amount.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //}

                }
                else
                {
                    MessageBox.Show("Insert Deduction Amount.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
