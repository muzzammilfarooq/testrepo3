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
    public partial class frmItemCategorySetup : Form
    {
        SlotPOSEntities ctx = new SlotPOSEntities();
        List<long> CounterID = new List<long>();

        public frmItemCategorySetup()
        {
            InitializeComponent();
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillGrid()
        {
        ;
            var searchRecord = from a in ctx.tblItemCategories
                               select a;
            //if (cmbSearchType.SelectedIndex > 0)
            //{
            //    string _type = cmbSearchType.Text;
            //    searchRecord = searchRecord.Where(r => r.CategoryType == _type);
            //}
            //if (txtSearchCategoryName.Text != "")
            //{
            //    string _categoryName = txtSearchCategoryName.Text;
            //    searchRecord = searchRecord.Where(r => r.ItemCategoryName.Contains(_categoryName));
            //}
            if (searchRecord.ToList().Count > 0)
            {
                dgvItemCategory.AutoGenerateColumns = false;
                dgvItemCategory.DataSource = searchRecord;
            }
            else
            {
                dgvItemCategory.DataSource = null;
                //MessageBox.Show("No Record Found!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void getLatestCategoryID()
        {
            var getLastRecord = (from a in ctx.tblItemCategories
                                 orderby a.ItemCategoryID descending
                                 select a).Take(1).SingleOrDefault();
            if (getLastRecord != null)
            {
                long last = getLastRecord.ItemCategoryID + 1;
                txtCategoryID.Text = last.ToString();
            }
            else
            {
                txtCategoryID.Text = "1";
            }

        }

        private bool ValidateForm()
        {
            ep.Clear();
            if (txtCategoryName.Text == "")
            {
                ep.SetError(txtCategoryName, "Please Enter Item Category Name.");
                return false;
            }
            return true;
        }

        private bool CheckAlreadyExist()
        {
            string _categoryName = txtCategoryName.Text.ToLower();

            var check = from a in ctx.tblItemCategories
                        where a.ItemCategory.ToLower() == _categoryName
                        select a;
            if (check.ToList().Count == 0)
                return true;
            else
                return false;
        }

        private void frmItemCategorySetup_Load(object sender, EventArgs e)
        {
            FillGrid();
            getLatestCategoryID();
            txtCategoryName.Focus();

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
            //var getCounters = (from a in ctx.tblCounters
            //                   where a.IsActive == true
            //                   select a).ToList();
            //if (getCategory.ToList().Count > 0)
            //{
            //    cmbCounter.DataSource = getCounters;
            //    cmbCounter.DisplayMember = "CounterName";
            //    cmbCounter.ValueMember = "CounterID";
            //}
            //  getCounters.Insert(0, new tblCounter { CounterID = 0, CounterName = "-- Select Category --" });
            //if (getCategory.ToList().Count > 0)
            //{
            //    listBox1.DataSource = getCounters;
            //    listBox1.DisplayMember = "CounterName";
            //    listBox1.ValueMember = "CounterID";
            //}
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm() == true)
                {

                    if (CheckAlreadyExist() == true)
                    {
                        if (MessageBox.Show("Are you sure you want to Add New Record", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            tblItemCategory category = new tblItemCategory();
                            category.ItemCategory = txtCategoryName.Text;
                            category.IsActive = true;
                            category.DiscreateItem = !rbtnCurrency.Checked;
                            category.IsSlotCategory = rbtnSlotCat.Checked;
                            category.Promotions = rbtnPromotions.Checked;
                            if (category.Promotions==true)
                            {
                                category.DiscreateItem = false;
                            }
                            category.InsertedDate = DateTime.Now;
                            ctx.AddTotblItemCategories(category);
                            ctx.SaveChanges();
                            MessageBox.Show("Record has been Saved Successfully!!!", "Record Saved", MessageBoxButtons.OK);

                            cmbCategory.DataSource = null;
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

                        }
                    }
                    else
                    {
                        MessageBox.Show("Record Already Exists!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    getLatestCategoryID();
                    FillGrid();
                    txtCategoryName.Text = "";
                    rbtnCurrency.Checked = false;
                    rbtnSlotCat.Checked = false;
                    rbtnPromotions.Checked = false;
                    txtCategoryName.Focus();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCategoryName.Text = "";
            cmbCategory.SelectedIndex = 0;
            listBox1.Items.Clear();
            rbtnCurrency.Checked = false;
            rbtnSlotCat.Checked = false;
            rbtnPromotions.Checked = false;
            getLatestCategoryID();
            txtCategoryName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex >0)
            {
                long CategoryID = long.Parse(cmbCategory.SelectedValue.ToString());
                var getCategoryCounters = (from a in ctx.tblItemCategories
                                   join b in ctx.tblUserItemCategories on a.ItemCategoryID equals b.categoryID
                                   join c in ctx.tblUsers on b.UserID equals c.UserID
                                   where a.IsActive == true && b.IsActive == true 
                                   && b.categoryID == CategoryID
                                   select b).OrderBy(t=> t.UserID).ToList();

                var getCounters = (from a in ctx.tblUsers
                                   where a.IsActive == true
                                   select a).OrderBy(t => t.UserID).ToList();

                listBox1.DataSource = null;
                if (getCounters.ToList().Count > 0)
                {
                    listBox1.DataSource = getCounters;
                    listBox1.DisplayMember = "userName";
                    listBox1.ValueMember = "UserID";
                }

                listBox1.SetSelected(0, false);
               
                CounterID.Clear();
                CounterID.AddRange(getCounters.Select(t=> t.UserID).ToList());
          
                for (int i = 0,j=0; i < getCounters.Count() && getCategoryCounters.Count > 0; i++)
                {
                   string s =  listBox1.ValueMember;
                    
                        if (getCounters[i].UserID == getCategoryCounters[j].UserID)
                        {
                            listBox1.SetSelected(i, true);
                           
                            if (j < getCategoryCounters.Count()-1)
                            j++;
                        }
                   
                }


                
            }
            else
            {
                listBox1.DataSource = null;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex != 0)
            {
                if (MessageBox.Show("Are you sure you want to Add New Record", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    long CategoryID = long.Parse(cmbCategory.SelectedValue.ToString());
                    int UserID;
                    for (int i = 0, j = 0; i < listBox1.Items.Count; i++)
                    {
                        if (listBox1.SelectedItems.Count > 0)
                        {
                            if (listBox1.Items.IndexOf(listBox1.SelectedItems[j]) == i)
                            {
                                UserID = Convert.ToInt16(CounterID[i]);
                                var getData = ctx.tblUserItemCategories.FirstOrDefault(x => x.categoryID == CategoryID && x.UserID == UserID);
                                if (getData == null)
                                {
                                    tblUserItemCategory tblCIC = new tblUserItemCategory();
                                    tblCIC.categoryID = CategoryID;
                                    tblCIC.UserID = UserID;
                                    tblCIC.Date = DateTime.Now;
                                    tblCIC.IsActive = true;
                                    ctx.AddTotblUserItemCategories(tblCIC);
                                    ctx.SaveChanges();
                                }
                                else if (getData.IsActive == false)
                                {
                                    getData.IsActive = true;
                                    ctx.SaveChanges();
                                }
                                if (j < listBox1.SelectedItems.Count - 1)
                                    j++;
                            }
                            else
                            {
                                UserID = Convert.ToInt16(CounterID[i]);
                                var getData = ctx.tblUserItemCategories.FirstOrDefault(x => x.categoryID == CategoryID && x.UserID == UserID);
                                if (getData != null)
                                {
                                    if (getData.IsActive == true)
                                    {
                                        getData.IsActive = false;
                                        ctx.SaveChanges();
                                    }

                                }
                            }
                        }
                        else
                        {
                            UserID = Convert.ToInt16(CounterID[i]);
                            var getData = ctx.tblUserItemCategories.FirstOrDefault(x => x.categoryID == CategoryID && x.UserID == UserID);
                            if (getData != null)
                            {
                                if (getData.IsActive == true)
                                {
                                    getData.IsActive = false;
                                    ctx.SaveChanges();
                                }

                            }
                        }
                    }
                    ep.Clear();
                    MessageBox.Show("Successfully Update Item Category on Counters");
                    btnReset_Click(null, null);
                }
            }
            else
            {
              ep.SetError(cmbCategory,"Please Select Category");
            }

        }
    }
}
