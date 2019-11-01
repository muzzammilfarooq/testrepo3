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
    public partial class frmItemSetup : Form
    {
        SlotPOSEntities ctx = new SlotPOSEntities();

        public frmItemSetup()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //SSK
        private void FillCategory()
        {
            var getCategory = (from a in ctx.tblItemCategories
                               where a.IsActive == true
                               select a).ToList();
            getCategory.Insert(0, new tblItemCategory { ItemCategoryID = 0, ItemCategory = "-- Select Category --" });
            if (getCategory.ToList().Count > 0)
            {
                cmbCategory.DataSource = getCategory;
                cmbCategory.DisplayMember = "ItemCategory";
                cmbCategory.ValueMember = "ItemCategoryID";
            }
            var getCounters = (from a in ctx.tblCounters
                               where a.IsActive == true
                               select a).ToList();
          //  getCounters.Insert(0, new tblCounter { CounterID = 0, CounterName = "-- Select Category --" });
            //if (getCategory.ToList().Count > 0)
            //{
            //    listBox1.DataSource = getCounters;
            //    listBox1.DisplayMember = "CounterName";
            //    listBox1.ValueMember = "CounterID";
            //}
            
        }

        private void FillGrid()
        {
            var searchRecord = from a in ctx.tblItems
                               join b in ctx.tblItemCategories on a.ItemCategoryID equals b.ItemCategoryID
                               select new { a.ItemID, a.ItemCategoryID, b.ItemCategory, a.ItemName, a.Unit, a.Price, a.IsActive, a.InsertedDate,a.FromTime,a.ToTime,a.FromDate,a.Todate,a.IsMonday,a.IsTuesday,a.IsWednesday,a.IsThusday,a.IsFriday,a.IsSaturday,a.IsSunday,a.IsTimeBase,a.IsDayBase,a.IsDateBase,a.IsCriteria };
            if (searchRecord.ToList().Count > 0)
            {
                dgvItem.AutoGenerateColumns = false;
                dgvItem.DataSource = searchRecord;
            }
            else
            {
                dgvItem.DataSource = null;
                //MessageBox.Show("No Record Found!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearFields()
        {
            cmbCategory.SelectedIndex = 0;
            txtItem.Text = "";
            txtUnit.Text = "";
            txtPrice.Text = "";
        }

        private void getLatestItemID()
        {
            var getLastRecord = (from a in ctx.tblItems
                                 orderby a.ItemID descending
                                 select a).Take(1).SingleOrDefault();
            if (getLastRecord != null)
            {
                long last = getLastRecord.ItemID + 1;
                txtItemID.Text = last.ToString();
            }
            else
            {
                txtItemID.Text = "1";
            }

        }

        private bool ValidateForm()
        {
            ep.Clear();
            if (cmbCategory.SelectedIndex == 0)
            {
                ep.SetError(cmbCategory, "Please Select Item Category.");
                return false;
            }
            if (txtItem.Text == "")
            {
                ep.SetError(txtItem, "Please Enter Item Name.");
                return false;
            }
            if (txtUnit.Text == "")
            {
                ep.SetError(txtUnit, "Please Enter Unit Name.");
                return false;
            }
            if (txtPrice.Text == "")
            {
                ep.SetError(txtPrice, "Please Enter Price.");
                return false;
            }
            //if (listBox1.SelectedItems.Count == 0)
            //{
                
            //    MessageBox.Show("Please Select Counters or a Counter");
            //    return false;
            //}
            return true;
        }

        private bool CheckAlreadyExist()
        {
            long _categoryId = long.Parse(cmbCategory.SelectedValue.ToString());
            string _itemName = txtItem.Text.ToLower();

            var check = from a in ctx.tblItems
                        where a.ItemCategoryID == _categoryId && a.ItemName.ToLower() == _itemName
                        select a;
            if (check.ToList().Count == 0)
                return true;
            else
                return false;
        }

        private void frmItemSetup_Load(object sender, EventArgs e)
        {
            CriteriaGroupBoxes();
            FillCategory();
            FillGrid();
            getLatestItemID();
            cmbCategory.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm() == true)
                {

                    if (CheckAlreadyExist() == true)
                    {
                        tblItem item = new tblItem();
                        if (MessageBox.Show("Are you sure you want to Add New Record", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            item.ItemCategoryID = long.Parse(cmbCategory.SelectedValue.ToString());
                            item.ItemName = txtItem.Text;
                            item.Unit = txtUnit.Text;
                            item.Price = decimal.Parse(txtPrice.Text);

                            item.RfidWatch = chkRFIDWatch.Checked;
                            item.IsActive = true;
                            item.InsertedDate = DateTime.Now;
                            item.IsTimeBase = checkBoxTimeBase.Checked;
                            DateTime fromtime = TimePickerFrom.Value;
                            DateTime totime = TimePickerTo.Value;
                            TimeSpan ttime = new TimeSpan(totime.Hour, totime.Minute, totime.Second);
                            TimeSpan ftime = new TimeSpan(fromtime.Hour, fromtime.Minute, fromtime.Second);
                            if (checkBoxTimeBase.Checked)
                            {
                                item.FromTime = ftime;
                                item.ToTime = ttime;
                            }
                            else
                            {
                                item.FromTime = null;
                                item.ToTime = null;
                            }

                            item.IsCriteria = checkBoxCriteria.Checked;
                            item.IsDateBase = checkBoxDateBase.Checked;
                            if (checkBoxDateBase.Checked)
                            {
                                item.FromDate = Convert.ToDateTime(dateTimePickerFrom.Text);
                                item.Todate = Convert.ToDateTime(dateTimePickerTO.Text);
                            }
                            else
                            {
                                item.FromDate = null;
                                item.Todate = null;
                            }

                            item.IsDayBase = checkBoxDayBase.Checked;
                            item.IsMonday = checkBoxMonday.Checked;
                            item.IsTuesday = checkBoxTUE.Checked;
                            item.IsWednesday = checkBoxWed.Checked;
                            item.IsThusday = checkBoxThu.Checked;
                            item.IsFriday = checkBoxFRI.Checked;
                            item.IsSaturday = checkBoxSAT.Checked;
                            item.IsSunday = checkBoxSUND.Checked;

                            ctx.AddTotblItems(item);
                            ctx.SaveChanges();

                            MessageBox.Show("Record has been Saved Successfully!!!", "Record Saved", MessageBoxButtons.OK);
                            FillGrid();
                        }
                    }
                    else
                    {
                        if (lblItemID.Text != "0")
                        {
                            DateTime fromtime = TimePickerFrom.Value;
                            DateTime totime = TimePickerTo.Value;
                            TimeSpan ttime = new TimeSpan(totime.Hour, totime.Minute, totime.Second);
                            TimeSpan ftime = new TimeSpan(fromtime.Hour, fromtime.Minute, fromtime.Second);
                            long itemID = Convert.ToInt64(lblItemID.Text);
                            tblItem i = ctx.tblItems.Where(a => a.ItemID == itemID).FirstOrDefault();

                            i.ItemCategoryID = long.Parse(cmbCategory.SelectedValue.ToString());
                            i.ItemName = txtItem.Text;
                            i.Unit = txtUnit.Text;
                            i.Price = decimal.Parse(txtPrice.Text);
                            //i.FromTime = ftime;
                            //i.ToTime = ttime;
                            i.IsCriteria = checkBoxCriteria.Checked;
                            i.IsDayBase = checkBoxDayBase.Checked;
                            i.IsTimeBase = checkBoxTimeBase.Checked;
                            i.IsDateBase = checkBoxDateBase.Checked;

                            if (checkBoxDateBase.Checked)
                            {
                                i.FromDate = Convert.ToDateTime(dateTimePickerFrom.Text);
                                i.Todate = Convert.ToDateTime(dateTimePickerTO.Text);
                            }
                            else
                            {
                                i.FromDate = null;
                                i.Todate = null;
                            }

                            if (checkBoxTimeBase.Checked)
                            {
                                i.FromTime = ftime;
                                i.ToTime = ttime;
                            }

                            else
                            {
                                i.FromTime = null;
                                i.ToTime = null;
                            }
                            i.IsMonday = checkBoxMonday.Checked;
                            i.IsTuesday = checkBoxTUE.Checked;
                            i.IsWednesday = checkBoxWed.Checked;
                            i.IsThusday = checkBoxThu.Checked;
                            i.IsFriday = checkBoxFRI.Checked;
                            i.IsSaturday = checkBoxSAT.Checked;
                            i.IsSunday = checkBoxSUND.Checked;
                            ctx.SaveChanges();
                            lblItemID.Text = "0";
                            MessageBox.Show("Record has been Updated Successfully!!!", "Record Updated", MessageBoxButtons.OK);
                            FillGrid();
                            checkBoxCriteria.Checked = false;
                        }
                    }

                    getLatestItemID();
                    ClearFields();
                    cmbCategory.Focus();
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
            getLatestItemID();
            cmbCategory.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        //SSK Project Work here
        #region Criteria
        private void checkBoxCriteria_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxCriteria.Checked == true)
            {
                groupBoxCriteria.Enabled = true;
            }

            else
            {
                groupBoxCriteria.Enabled = false;
                ClearCriteria();
            }
        }


        private void checkBoxTimeBase_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxTimeBase.Checked == true)
            {
                groupBoxTimeBase.Enabled = true;
                TimePickerFrom.Enabled = true;
                TimePickerTo.Enabled = true;
            }
            else
            {
                groupBoxTimeBase.Enabled = false;
                TimePickerFrom.Enabled = false;
                TimePickerTo.Enabled = false;
                TimePickerFrom.Text = null;
                TimePickerTo.Text = null;
            }
        }

        private void checkBoxDateBase_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxDateBase.Checked == true)
            {
                groupBoxDateBase.Enabled = true;
                dateTimePickerFrom.Enabled = true;
                dateTimePickerTO.Enabled = true;

            }

            else
            {
                groupBoxDateBase.Enabled = false;

                dateTimePickerFrom.Enabled = false;
                dateTimePickerTO.Enabled = false;
                dateTimePickerFrom.Text = null;
                dateTimePickerTO.Text = null;

            }
        }

        private void checkBoxDayBase_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxDayBase.Checked == true)
            {
                groupBoxDayBase.Enabled = true;

            }

            else
            {
                groupBoxDayBase.Enabled = false;
                checkBoxMonday.Checked = false;
                checkBoxTUE.Checked = false;
                checkBoxWed.Checked = false;
                checkBoxThu.Checked = false;
                checkBoxFRI.Checked = false;
                checkBoxSAT.Checked = false;
                checkBoxSUND.Checked = false;

            }
        }

        private void ClearCriteria()
        {
            checkBoxDateBase.Checked = false;
            checkBoxDayBase.Checked = false;
            checkBoxTimeBase.Checked = false;
            TimePickerFrom.Text = null;
            TimePickerTo.Text = null;
            dateTimePickerFrom.Text = null;
            dateTimePickerTO.Text = null;
            checkBoxMonday.Checked = false;
            checkBoxTUE.Checked = false;
            checkBoxWed.Checked = false;
            checkBoxThu.Checked = false;
            checkBoxFRI.Checked = false;
            checkBoxSAT.Checked = false;
            checkBoxSUND.Checked = false;
        }

        private void CriteriaGroupBoxes()
        {
            groupBoxCriteria.Enabled = false;
            groupBoxTimeBase.Enabled = false;
            groupBoxDateBase.Enabled = false;
            groupBoxDayBase.Enabled = false;
            dateTimePickerFrom.Enabled = false;
            dateTimePickerTO.Enabled = false;
            TimePickerFrom.Enabled = false;
            TimePickerTo.Enabled = false;
        }
        #endregion

        private void dgvItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtItem.Text = dgvItem.CurrentRow.Cells["ItemName"].Value.ToString();
                txtPrice.Text = dgvItem.CurrentRow.Cells["Price"].Value.ToString();
                txtUnit.Text = dgvItem.CurrentRow.Cells["Unit"].Value.ToString();
                lblItemID.Text = dgvItem.CurrentRow.Cells["ItemID"].Value.ToString();
                cmbCategory.Text = dgvItem.CurrentRow.Cells["ItemCategory"].Value.ToString();
                if (dgvItem.CurrentRow.Cells["FromTime"].Value != null)
                {
                    TimePickerFrom.Value = Convert.ToDateTime(dgvItem.CurrentRow.Cells["FromTime"].Value.ToString());
                }
                if (dgvItem.CurrentRow.Cells["ToTime"].Value != null)
                {
                    TimePickerTo.Value = Convert.ToDateTime(dgvItem.CurrentRow.Cells["ToTime"].Value.ToString());
                }
                if (dgvItem.CurrentRow.Cells["FromDate"].Value != null)
                {
                    dateTimePickerFrom.Value = Convert.ToDateTime(dgvItem.CurrentRow.Cells["FromDate"].Value.ToString());
                }
                if (dgvItem.CurrentRow.Cells["Todate"].Value != null)
                {
                    dateTimePickerTO.Value = Convert.ToDateTime(dgvItem.CurrentRow.Cells["Todate"].Value.ToString());
                }
                if (dgvItem.CurrentRow.Cells["IsMonday"].Value != null)
                {
                    checkBoxMonday.Checked = Convert.ToBoolean(dgvItem.CurrentRow.Cells["IsMonday"].Value.ToString());
                }
                if (dgvItem.CurrentRow.Cells["IsTuesday"].Value != null)
                {
                    checkBoxTUE.Checked = Convert.ToBoolean(dgvItem.CurrentRow.Cells["IsTuesday"].Value.ToString());
                }
                if (dgvItem.CurrentRow.Cells["IsWednesday"].Value != null)
                {
                    checkBoxWed.Checked = Convert.ToBoolean(dgvItem.CurrentRow.Cells["IsWednesday"].Value.ToString());
                }
                if (dgvItem.CurrentRow.Cells["IsThursday"].Value != null)
                {
                    checkBoxThu.Checked = Convert.ToBoolean(dgvItem.CurrentRow.Cells["IsThursday"].Value.ToString());
                }
                if (dgvItem.CurrentRow.Cells["IsFriday"].Value != null)
                {
                    checkBoxFRI.Checked = Convert.ToBoolean(dgvItem.CurrentRow.Cells["IsFriday"].Value.ToString());
                }
                if (dgvItem.CurrentRow.Cells["IsSaturday"].Value != null)
                {
                    checkBoxSAT.Checked = Convert.ToBoolean(dgvItem.CurrentRow.Cells["IsSaturday"].Value.ToString());
                }
                if (dgvItem.CurrentRow.Cells["IsSunday"].Value != null)
                {
                    checkBoxSUND.Checked = Convert.ToBoolean(dgvItem.CurrentRow.Cells["IsSunday"].Value.ToString());
                }

                if (dgvItem.CurrentRow.Cells["IsTimeBase"].Value != null)
                {
                    checkBoxTimeBase.Checked = Convert.ToBoolean(dgvItem.CurrentRow.Cells["IsTimeBase"].Value.ToString());
                }
                if (dgvItem.CurrentRow.Cells["IsDayBase"].Value != null)
                {
                    checkBoxDayBase.Checked = Convert.ToBoolean(dgvItem.CurrentRow.Cells["IsDayBase"].Value.ToString());
                }

                if (dgvItem.CurrentRow.Cells["IsDateBase"].Value != null)
                {
                    checkBoxDateBase.Checked = Convert.ToBoolean(dgvItem.CurrentRow.Cells["IsDateBase"].Value.ToString());
                }

                if (dgvItem.CurrentRow.Cells["IsCriteria"].Value != null)
                {
                    checkBoxCriteria.Checked = Convert.ToBoolean(dgvItem.CurrentRow.Cells["IsCriteria"].Value.ToString());
                }
                else
                {
                    checkBoxCriteria.Checked = false;
                }
                txtItem.ReadOnly = true;
                txtUnit.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
