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
    public partial class frmCounterSetup : Form
    {
        SlotPOSEntities ctx = new SlotPOSEntities();

        public frmCounterSetup()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void FillCounter()
        {
            var getCategory = (from a in ctx.tblCounters
                               where a.IsActive == true
                               select a).ToList();
            getCategory.Insert(0, new tblCounter { CounterID = 0, CounterName = "-- Select Counter --" });
            if (getCategory.ToList().Count > 0)
            {
                cmbCounter.DataSource = getCategory;
                cmbCounter.DisplayMember = "CounterName";
                cmbCounter.ValueMember = "CounterID";
            }
        }

        private void FillGrid()
        {
            var searchRecord = from a in ctx.tblUsers
                               join b in ctx.tblCounters on a.CounterID equals b.CounterID
                               select new { a.UserID, a.CounterID, b.CounterName, a.Username, a.UserPassword, a.IsActive, a.InsertedDate };
            if (searchRecord.ToList().Count > 0)
            {
                dgvUser.AutoGenerateColumns = false;
                dgvUser.DataSource = searchRecord;
            }
            else
            {
                dgvUser.DataSource = null;
                //MessageBox.Show("No Record Found!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearFields()
        {
            cmbCounter.SelectedIndex = 0;
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void getLatestUserID()
        {
            var getLastRecord = (from a in ctx.tblUsers
                                 orderby a.UserID descending
                                 select a).Take(1).SingleOrDefault();
            if (getLastRecord != null)
            {
                long last = getLastRecord.UserID + 1;
                txtUserID.Text = last.ToString();
            }
            else
            {
                txtUserID.Text = "1";
            }

        }

        private bool ValidateForm()
        {
            ep.Clear();
            if (cmbCounter.SelectedIndex == 0)
            {
                ep.SetError(cmbCounter, "Please Select Counter.");
                return false;
            }
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

        private void frmCounterSetup_Load(object sender, EventArgs e)
        {
            FillCounter();
            FillGrid();
            getLatestUserID();
            cmbCounter.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm() == true)
                {

                    //if (CheckAlreadyExist() == true)
                    //{
                    tblUser user = new tblUser();
                    if (MessageBox.Show("Are you sure you want to Add New Record", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        user.CounterID = long.Parse(cmbCounter.SelectedValue.ToString());
                        user.Username = txtUsername.Text;
                        user.UserPassword = txtPassword.Text;
                        user.IsActive = true;
                        user.InsertedDate = DateTime.Now;
                        ctx.AddTotblUsers(user);
                        ctx.SaveChanges();

                        MessageBox.Show("Record has been Saved Successfully!!!", "Record Saved", MessageBoxButtons.OK);
                        FillGrid();
                    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Record Already Exists!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}

                    getLatestUserID();
                    ClearFields();
                    cmbCounter.Focus();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
            getLatestUserID();
            cmbCounter.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
