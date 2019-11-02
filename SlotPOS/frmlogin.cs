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
    public partial class frmlogin : Form
    {
        SlotPOSEntities ctx = new SlotPOSEntities();

        public frmlogin()
        {
            InitializeComponent();
        }

        private bool Validate()
        {
            ep.Clear();
            if (txtUsername.Text == "")
            {
                ep.SetError(txtUsername, "Please Enter Username.");
                return false;
            }
            if (txtPassword.Text == "")
            {
                ep.SetError(txtPassword, "Please Enter Password.");
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Username = txtUsername.Text.Trim();
            string Password = txtPassword.Text.Trim();
           
            if (Validate())
            {
                var getLogin = (from a in ctx.tblUsers
                                where a.Username == Username && a.UserPassword == Password && a.IsActive == true
                                select a).SingleOrDefault();
                if (getLogin != null)
                {
                    clsGlobalVar.UserID = getLogin.UserID;
                    clsGlobalVar.closeDate = getLogin.DayOpenClose;
                    clsGlobalVar.CounterID = long.Parse(getLogin.CounterID.ToString());
                    DashBoard dashboard = new DashBoard(Username);

                    var newCardAmount = ctx.tblCounters.Where(t => t.CounterID == clsGlobalVar.CounterID).ToList();
                    clsGlobalVar.BasicCardAmount = newCardAmount[0].CardBasicAmount;
                    clsGlobalVar.NewCardAmount =  newCardAmount[0].NewCardAmount;
                    clsGlobalVar.FreeEntry = newCardAmount[0].CardFreeEntry;

                    this.Hide();
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password, Please try again later or Call your Software Administrator.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
