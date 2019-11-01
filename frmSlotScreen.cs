using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SlotPOS;

namespace SlotPOS
{
    public partial class frmSlotScreen : Form
    {
        private Timer timer1;
        //int Hours = 0;   // Hours.
        //int Minutes = 0; // Minutes.
        //int Seconds = 00; // Seconds.

        public frmSlotScreen()
        {
            InitializeComponent();
        }

        private void FillItemCateogry()
        {
            SlotPOSEntities ctx = new SlotPOSEntities();

            var getItem = (from a in ctx.tblItemCategories
                           where a.IsActive == true && a.IsSlotCategory == true
                           select a).ToList();
            getItem.Insert(0, new tblItemCategory { ItemCategoryID = 0, ItemCategory = "-- Select Category --" });
            if (getItem.ToList().Count > 0)
            {
                cmbItemCategory.DataSource = getItem;
                cmbItemCategory.DisplayMember = "ItemCategory";
                cmbItemCategory.ValueMember = "ItemCategoryID";
            }
        }

        private void GetSlotTimeByCategoryID(long _categoryId)
        {
            SlotPOSEntities ctx = new SlotPOSEntities();

            var getTime = from a in ctx.tblSlots
                          where a.ItemCategoryID == _categoryId
                          select a;
            if (getTime.ToList().Count > 0)
            {
                foreach (var b in getTime)
                {
                    DateTime CurrentTime = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss tt"));

                    if (b.SlotNo.ToLower() == "slot 1")
                    {
                        if (b.Status == "Full" || b.Status == "Done")
                        {
                            lblStatus1.Text = b.Status;
                            lblStatus1.ForeColor = Color.Red;
                        }
                        lblSlotTime1.Text = DateTime.Parse(b.FromTime.ToString()).ToString("hh:mmtt").ToLower() + " To " + DateTime.Parse(b.ToTime.ToString()).ToString("hh:mmtt").ToLower();
                    }
                    else if (b.SlotNo.ToLower() == "slot 2")
                    {
                        if (b.Status == "Full" || b.Status == "Done")
                        {
                            lblStatus2.Text = b.Status;
                            lblStatus2.ForeColor = Color.Red;
                        }
                        lblSlotTime2.Text = DateTime.Parse(b.FromTime.ToString()).ToString("hh:mmtt").ToLower() + " To " + DateTime.Parse(b.ToTime.ToString()).ToString("hh:mmtt").ToLower();
                    }
                    else if (b.SlotNo.ToLower() == "slot 3")
                    {
                        if (b.Status == "Full" || b.Status == "Done")
                        {
                            lblStatus3.Text = b.Status;
                            lblStatus3.ForeColor = Color.Red;
                        }
                        lblSlotTime3.Text = DateTime.Parse(b.FromTime.ToString()).ToString("hh:mmtt").ToLower() + " To " + DateTime.Parse(b.ToTime.ToString()).ToString("hh:mmtt").ToLower();
                    }
                    else if (b.SlotNo.ToLower() == "slot 4")
                    {
                        if (b.Status == "Full" || b.Status == "Done")
                        {
                            lblStatus4.Text = b.Status;
                            lblStatus4.ForeColor = Color.Red;
                        }
                        lblSlotTime4.Text = DateTime.Parse(b.FromTime.ToString()).ToString("hh:mmtt").ToLower() + " To " + DateTime.Parse(b.ToTime.ToString()).ToString("hh:mmtt").ToLower();
                    }
                    else if (b.SlotNo.ToLower() == "slot 5")
                    {
                        if (b.Status == "Full" || b.Status == "Done")
                        {
                            lblStatus5.Text = b.Status;
                            lblStatus5.ForeColor = Color.Red;
                        }
                        lblSlotTime5.Text = DateTime.Parse(b.FromTime.ToString()).ToString("hh:mmtt").ToLower() + " To " + DateTime.Parse(b.ToTime.ToString()).ToString("hh:mmtt").ToLower();
                    }
                    else if (b.SlotNo.ToLower() == "slot 6")
                    {
                        if (b.Status == "Full" || b.Status == "Done")
                        {
                            lblStatus6.Text = b.Status;
                            lblStatus6.ForeColor = Color.Red;
                        }
                        lblSlotTime6.Text = DateTime.Parse(b.FromTime.ToString()).ToString("hh:mmtt").ToLower() + " To " + DateTime.Parse(b.ToTime.ToString()).ToString("hh:mmtt").ToLower();
                    }
                    else if (b.SlotNo.ToLower() == "slot 7")
                    {
                        if (b.Status == "Full" || b.Status == "Done")
                        {
                            lblStatus7.Text = b.Status;
                            lblStatus7.ForeColor = Color.Red;
                        }
                        lblSlotTime7.Text = DateTime.Parse(b.FromTime.ToString()).ToString("hh:mmtt").ToLower() + " To " + DateTime.Parse(b.ToTime.ToString()).ToString("hh:mmtt").ToLower();
                    }
                    else if (b.SlotNo.ToLower() == "slot 8")
                    {
                        if (b.Status == "Full" || b.Status == "Done")
                        {
                            lblStatus8.Text = b.Status;
                            lblStatus8.ForeColor = Color.Red;
                        }
                        lblSlotTime8.Text = DateTime.Parse(b.FromTime.ToString()).ToString("hh:mmtt").ToLower() + " To " + DateTime.Parse(b.ToTime.ToString()).ToString("hh:mmtt").ToLower();
                    }
                    else if (b.SlotNo.ToLower() == "slot 9")
                    {
                        if (b.Status == "Full" || b.Status == "Done")
                        {
                            lblStatus9.Text = b.Status;
                            lblStatus9.ForeColor = Color.Red;
                        }
                        lblSlotTime9.Text = DateTime.Parse(b.FromTime.ToString()).ToString("hh:mmtt").ToLower() + " To " + DateTime.Parse(b.ToTime.ToString()).ToString("hh:mmtt").ToLower();
                    }
                    else if (b.SlotNo.ToLower() == "slot 10")
                    {
                        if (b.Status == "Full" || b.Status == "Done")
                        {
                            lblStatus10.Text = b.Status;
                            lblStatus10.ForeColor = Color.Red;
                        }
                        lblSlotTime10.Text = DateTime.Parse(b.FromTime.ToString()).ToString("hh:mmtt").ToLower() + " To " + DateTime.Parse(b.ToTime.ToString()).ToString("hh:mmtt").ToLower();
                    }
                    else if (b.SlotNo.ToLower() == "slot 11")
                    {
                        if (b.Status == "Full" || b.Status == "Done")
                        {
                            lblStatus11.Text = b.Status;
                            lblStatus11.ForeColor = Color.Red;
                        }
                        lblSlotTime11.Text = DateTime.Parse(b.FromTime.ToString()).ToString("hh:mmtt").ToLower() + " To " + DateTime.Parse(b.ToTime.ToString()).ToString("hh:mmtt").ToLower();
                    }
                    else if (b.SlotNo.ToLower() == "slot 12")
                    {
                        if (b.Status == "Full" || b.Status == "Done")
                        {
                            lblStatus12.Text = b.Status;
                            lblStatus12.ForeColor = Color.Red;
                        }
                        lblSlotTime12.Text = DateTime.Parse(b.FromTime.ToString()).ToString("hh:mmtt").ToLower() + " To " + DateTime.Parse(b.ToTime.ToString()).ToString("hh:mmtt").ToLower();
                    }
                    else if (b.SlotNo.ToLower() == "slot 13")
                    {
                        if (b.Status == "Full" || b.Status == "Done")
                        {
                            lblStatus13.Text = b.Status;
                            lblStatus13.ForeColor = Color.Red;
                        }
                        lblSlotTime13.Text = DateTime.Parse(b.FromTime.ToString()).ToString("hh:mmtt").ToLower() + " To " + DateTime.Parse(b.ToTime.ToString()).ToString("hh:mmtt").ToLower();
                    }
                    else if (b.SlotNo.ToLower() == "slot 14")
                    {
                        if (b.Status == "Full" || b.Status == "Done")
                        {
                            lblStatus14.Text = b.Status;
                            lblStatus14.ForeColor = Color.Red;
                        }
                        lblSlotTime14.Text = DateTime.Parse(b.FromTime.ToString()).ToString("hh:mmtt").ToLower() + " To " + DateTime.Parse(b.ToTime.ToString()).ToString("hh:mmtt").ToLower();
                    }
                    else if (b.SlotNo.ToLower() == "slot 15")
                    {
                        if (b.Status == "Full" || b.Status == "Done")
                        {
                            lblStatus15.Text = b.Status;
                            lblStatus15.ForeColor = Color.Red;
                        }
                        lblSlotTime15.Text = DateTime.Parse(b.FromTime.ToString()).ToString("hh:mmtt").ToLower() + " To " + DateTime.Parse(b.ToTime.ToString()).ToString("hh:mmtt").ToLower();
                    }

                }
            }
            else
            {
                Reset();
            }
        }

        private void Reset()
        {
            lblSlotTime1.Text = "N/A";
            lblSlotTime2.Text = "N/A";
            lblSlotTime3.Text = "N/A";
            lblSlotTime4.Text = "N/A";
            lblSlotTime5.Text = "N/A";
            lblSlotTime6.Text = "N/A";
            lblSlotTime7.Text = "N/A";
            lblSlotTime8.Text = "N/A";
            lblSlotTime9.Text = "N/A";
            lblSlotTime10.Text = "N/A";
            lblSlotTime11.Text = "N/A";
            lblSlotTime12.Text = "N/A";
            lblSlotTime13.Text = "N/A";
            lblSlotTime14.Text = "N/A";
            lblSlotTime15.Text = "N/A";

            lblStatus1.ForeColor = Color.FromArgb(0, 192, 0);
            lblStatus1.Text = "Available";
            lblStatus2.ForeColor = Color.FromArgb(0, 192, 0);
            lblStatus2.Text = "Available";
            lblStatus3.ForeColor = Color.FromArgb(0, 192, 0);
            lblStatus3.Text = "Available";
            lblStatus4.ForeColor = Color.FromArgb(0, 192, 0);
            lblStatus4.Text = "Available";
            lblStatus5.ForeColor = Color.FromArgb(0, 192, 0);
            lblStatus5.Text = "Available";
            lblStatus6.ForeColor = Color.FromArgb(0, 192, 0);
            lblStatus6.Text = "Available";
            lblStatus7.ForeColor = Color.FromArgb(0, 192, 0);
            lblStatus7.Text = "Available";
            lblStatus8.ForeColor = Color.FromArgb(0, 192, 0);
            lblStatus8.Text = "Available";
            lblStatus9.ForeColor = Color.FromArgb(0, 192, 0);
            lblStatus9.Text = "Available";
            lblStatus10.ForeColor = Color.FromArgb(0, 192, 0);
            lblStatus10.Text = "Available";
            lblStatus11.ForeColor = Color.FromArgb(0, 192, 0);
            lblStatus11.Text = "Available";
            lblStatus12.ForeColor = Color.FromArgb(0, 192, 0);
            lblStatus12.Text = "Available";
            lblStatus13.ForeColor = Color.FromArgb(0, 192, 0);
            lblStatus13.Text = "Available";
            lblStatus14.ForeColor = Color.FromArgb(0, 192, 0);
            lblStatus14.Text = "Available";
            lblStatus15.ForeColor = Color.FromArgb(0, 192, 0);
            lblStatus15.Text = "Available";
        }

        private void getCurrentSlot(string _slotNo)
        {
            if (_slotNo.ToLower() == "slot 1" && lblStatus1.Text != "Reserved")
            {
                lblStatus1.ForeColor = Color.FromArgb(0, 192, 0);
                lblStatus1.Text = "IN";
            }
            else if (_slotNo.ToLower() == "slot 2" && lblStatus2.Text != "Reserved")
            {
                lblStatus2.ForeColor = Color.FromArgb(0, 192, 0);
                lblStatus2.Text = "IN";
            }
            else if (_slotNo.ToLower() == "slot 3" && lblStatus3.Text != "Reserved")
            {
                lblStatus3.ForeColor = Color.FromArgb(0, 192, 0);
                lblStatus3.Text = "IN";
            }
            else if (_slotNo.ToLower() == "slot 4" && lblStatus4.Text != "Reserved")
            {
                lblStatus4.ForeColor = Color.FromArgb(0, 192, 0);
                lblStatus4.Text = "IN";
            }
            else if (_slotNo.ToLower() == "slot 5" && lblStatus5.Text != "Reserved")
            {
                lblStatus5.ForeColor = Color.FromArgb(0, 192, 0);
                lblStatus5.Text = "IN";
            }
            else if (_slotNo.ToLower() == "slot 6" && lblStatus6.Text != "Reserved")
            {
                lblStatus6.ForeColor = Color.FromArgb(0, 192, 0);
                lblStatus6.Text = "IN";
            }
            else if (_slotNo.ToLower() == "slot 7" && lblStatus7.Text != "Reserved")
            {
                lblStatus7.ForeColor = Color.FromArgb(0, 192, 0);
                lblStatus7.Text = "IN";
            }
            else if (_slotNo.ToLower() == "slot 8" && lblStatus8.Text != "Reserved")
            {
                lblStatus8.ForeColor = Color.FromArgb(0, 192, 0);
                lblStatus8.Text = "IN";
            }
            else if (_slotNo.ToLower() == "slot 9" && lblStatus9.Text != "Reserved")
            {
                lblStatus9.ForeColor = Color.FromArgb(0, 192, 0);
                lblStatus9.Text = "IN";
            }
            else if (_slotNo.ToLower() == "slot 10" && lblStatus10.Text != "Reserved")
            {
                lblStatus10.ForeColor = Color.FromArgb(0, 192, 0);
                lblStatus10.Text = "IN";
            }
            else if (_slotNo.ToLower() == "slot 11" && lblStatus11.Text != "Reserved")
            {
                lblStatus11.ForeColor = Color.FromArgb(0, 192, 0);
                lblStatus11.Text = "IN";
            }
            else if (_slotNo.ToLower() == "slot 12" && lblStatus12.Text != "Reserved")
            {
                lblStatus12.ForeColor = Color.FromArgb(0, 192, 0);
                lblStatus12.Text = "IN";
            }
            else if (_slotNo.ToLower() == "slot 13" && lblStatus13.Text != "Reserved")
            {
                lblStatus13.ForeColor = Color.FromArgb(0, 192, 0);
                lblStatus13.Text = "IN";
            }
            else if (_slotNo.ToLower() == "slot 14" && lblStatus14.Text != "Reserved")
            {
                lblStatus14.ForeColor = Color.FromArgb(0, 192, 0);
                lblStatus14.Text = "IN";
            }
            else if (_slotNo.ToLower() == "slot 15" && lblStatus15.Text != "Reserved")
            {
                lblStatus15.ForeColor = Color.FromArgb(0, 192, 0);
                lblStatus15.Text = "IN";
            }
        }

        private void updatePreviousStatus()
        {
            SlotPOSEntities ctx = new SlotPOSEntities();

            DateTime CurrentTime = DateTime.Parse(DateTime.Now.ToString("HH:mm"));
            TimeSpan Time = CurrentTime.TimeOfDay;

            var checkRecord = from a in ctx.tblSlots
                               where a.ToTime.Value < Time
                               select a;
            if (checkRecord != null)
            {
                foreach (var b in checkRecord)
                {
                    SlotPOSEntities ctx1 = new SlotPOSEntities();

                    var updateRecord = (from c in ctx1.tblSlots
                                        where c.SlotSetupID == b.SlotSetupID
                                        select c).SingleOrDefault();
                    if (updateRecord != null)
                    {
                        updateRecord.Status = "Done";
                        ctx1.SaveChanges();
                    }
                }
            }
        }

        private long getItemId(long _categoryId, string _slotNo)
        {
            SlotPOSEntities ctx = new SlotPOSEntities();

            long ItemId = 0;
            var getItemID = (from a in ctx.tblSlots
                            where a.ItemCategoryID == _categoryId && a.SlotNo == _slotNo
                            select a).SingleOrDefault();
            if (getItemID != null)
            {
                ItemId = long.Parse(getItemID.ItemID.ToString());
            }
            return ItemId;
        }

        private int getSoldItems(long _categoryId, string _slotNo)
        {
            long ItemID = getItemId(_categoryId, _slotNo);

            SlotPOSEntities ctx1 = new SlotPOSEntities();

            int Qty = 0;
            if (lblSaleDate.Text != "")
            {
                DateTime saleDate = DateTime.Parse(lblSaleDate.Text).Date;
                var checkData = (from pos in ctx1.tblPOSDetails
                                 join c in ctx1.tblSlots on pos.ItemID equals c.ItemID
                                 join b in ctx1.tblPOS on pos.POSID equals b.POSID
                                 where pos.ItemID == ItemID && b.SaleDate == saleDate
                                 select new { pos.Quantity, pos.Price });
                if (checkData.ToList().Count > 0)
                {
                    var totalQty = checkData.Sum(d => d.Quantity);
                    Qty = int.Parse(totalQty.ToString());
                }
            }
            return Qty;
                
        }

        private void SetTimer1(long _categoryId)
        {
            SlotPOSEntities ctx = new SlotPOSEntities();

            DateTime CurrentTime = DateTime.Parse(DateTime.Now.ToString("HH:mm"));
            TimeSpan Time = CurrentTime.TimeOfDay;
            var getTime = (from a in ctx.tblSlots
                           where a.FromTime.Value <= Time && a.ToTime.Value > Time
                           select a).Take(1).SingleOrDefault();
            if (getTime != null)
            {
                lblCurrentSlot.Text = getTime.SlotNo.ToString();
                getCurrentSlot(lblCurrentSlot.Text);
                TimeSpan diff = getTime.ToTime.Value.Subtract(Time);

                string[] AllTime = diff.ToString().Split(':');
                int Hours = int.Parse(AllTime[0].ToString());
                int Minutes = int.Parse(AllTime[1].ToString());
                int Seconds = 0;//int.Parse(AllTime[2].ToString());

                timerTick(Hours, Minutes, Seconds);
            }
        }

        private void timerTick(int Hours, int Minutes, int Seconds)
        {
            if (Seconds < 1 && Minutes != 0)
            {
                int TotalSecond = 59;
                Seconds = TotalSecond - DateTime.Now.Second;
                //MessageBox.Show(Seconds.ToString());
                if (Minutes == 0)
                {
                    //Minutes = 59;
                    if (Hours != 0) Hours -= 1;
                }
                else
                {
                    Minutes -= 1;
                }
            }
            else Seconds -= 1;

            if (Hours == 0 && Minutes == 0 && Seconds == 0)
            {
                SlotPOSEntities ctx = new SlotPOSEntities();

                long CategoryId = long.Parse(cmbItemCategory.SelectedValue.ToString());
                var updateData = (from a in ctx.tblSlots
                                  where a.SlotNo == lblCurrentSlot.Text && a.ItemCategoryID == CategoryId
                                  select a).SingleOrDefault();
                if (updateData != null)
                {
                    updateData.Status = "Done";
                    ctx.SaveChanges();
                    GetSlotTimeByCategoryID(CategoryId);
                   // timer1.Stop();
                }
            }

            lblCountDown.Text = Hours.ToString() + " : " + Minutes.ToString() + " : " + Seconds.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            long CategoryId = long.Parse(cmbItemCategory.SelectedValue.ToString());

            SetTimer1(CategoryId);
            lblSaleCount1.Text = getSoldItems(CategoryId, "Slot 1").ToString();
            if (lblSaleCount1.Text == "50")
            {
                SlotPOSEntities ctx5 = new SlotPOSEntities();
                var updateData = (from a in ctx5.tblSlots
                                  where a.SlotNo == "Slot 1" && a.ItemCategoryID == CategoryId
                                  select a).SingleOrDefault();
                if (updateData != null)
                {
                    updateData.Status = "Full";
                    ctx5.SaveChanges();
                    GetSlotTimeByCategoryID(CategoryId);
                }
            }
            lblSaleCount2.Text = getSoldItems(CategoryId, "Slot 2").ToString();
            if (lblSaleCount2.Text == "50")
            {
                SlotPOSEntities ctx5 = new SlotPOSEntities();
                var updateData = (from a in ctx5.tblSlots
                                  where a.SlotNo == "Slot 2" && a.ItemCategoryID == CategoryId
                                  select a).SingleOrDefault();
                if (updateData != null)
                {
                    updateData.Status = "Full";
                    ctx5.SaveChanges();
                    GetSlotTimeByCategoryID(CategoryId);
                }
            }
            lblSaleCount3.Text = getSoldItems(CategoryId, "Slot 3").ToString();
            if (lblSaleCount3.Text == "50")
            {
                SlotPOSEntities ctx5 = new SlotPOSEntities();
                var updateData = (from a in ctx5.tblSlots
                                  where a.SlotNo == "Slot 3" && a.ItemCategoryID == CategoryId
                                  select a).SingleOrDefault();
                if (updateData != null)
                {
                    updateData.Status = "Full";
                    ctx5.SaveChanges();
                    GetSlotTimeByCategoryID(CategoryId);
                }
            }
            lblSaleCount4.Text = getSoldItems(CategoryId, "Slot 4").ToString();
            if (lblSaleCount4.Text == "50")
            {
                SlotPOSEntities ctx5 = new SlotPOSEntities();
                var updateData = (from a in ctx5.tblSlots
                                  where a.SlotNo == "Slot 4" && a.ItemCategoryID == CategoryId
                                  select a).SingleOrDefault();
                if (updateData != null)
                {
                    updateData.Status = "Full";
                    ctx5.SaveChanges();
                    GetSlotTimeByCategoryID(CategoryId);
                }
            }
            lblSaleCount5.Text = getSoldItems(CategoryId, "Slot 5").ToString();
            if (lblSaleCount5.Text == "50")
            {
                SlotPOSEntities ctx5 = new SlotPOSEntities();
                var updateData = (from a in ctx5.tblSlots
                                  where a.SlotNo == "Slot 5" && a.ItemCategoryID == CategoryId
                                  select a).SingleOrDefault();
                if (updateData != null)
                {
                    updateData.Status = "Full";
                    ctx5.SaveChanges();
                    GetSlotTimeByCategoryID(CategoryId);
                }
            }
            lblSaleCount6.Text = getSoldItems(CategoryId, "Slot 6").ToString();
            if (lblSaleCount6.Text == "50")
            {
                SlotPOSEntities ctx5 = new SlotPOSEntities();
                var updateData = (from a in ctx5.tblSlots
                                  where a.SlotNo == "Slot 6" && a.ItemCategoryID == CategoryId
                                  select a).SingleOrDefault();
                if (updateData != null)
                {
                    updateData.Status = "Full";
                    ctx5.SaveChanges();
                    GetSlotTimeByCategoryID(CategoryId);
                }
            }
            lblSaleCount7.Text = getSoldItems(CategoryId, "Slot 7").ToString();
            if (lblSaleCount7.Text == "50")
            {
                SlotPOSEntities ctx5 = new SlotPOSEntities();
                var updateData = (from a in ctx5.tblSlots
                                  where a.SlotNo == "Slot 7" && a.ItemCategoryID == CategoryId
                                  select a).SingleOrDefault();
                if (updateData != null)
                {
                    updateData.Status = "Full";
                    ctx5.SaveChanges();
                    GetSlotTimeByCategoryID(CategoryId);
                }
            }
            lblSaleCount8.Text = getSoldItems(CategoryId, "Slot 8").ToString();
            if (lblSaleCount8.Text == "50")
            {
                SlotPOSEntities ctx5 = new SlotPOSEntities();
                var updateData = (from a in ctx5.tblSlots
                                  where a.SlotNo == "Slot 8" && a.ItemCategoryID == CategoryId
                                  select a).SingleOrDefault();
                if (updateData != null)
                {
                    updateData.Status = "Full";
                    ctx5.SaveChanges();
                    GetSlotTimeByCategoryID(CategoryId);
                }
            }
            lblSaleCount9.Text = getSoldItems(CategoryId, "Slot 9").ToString();
            if (lblSaleCount9.Text == "50")
            {
                SlotPOSEntities ctx5 = new SlotPOSEntities();
                var updateData = (from a in ctx5.tblSlots
                                  where a.SlotNo == "Slot 9" && a.ItemCategoryID == CategoryId
                                  select a).SingleOrDefault();
                if (updateData != null)
                {
                    updateData.Status = "Full";
                    ctx5.SaveChanges();
                    GetSlotTimeByCategoryID(CategoryId);
                }
            }
            lblSaleCount10.Text = getSoldItems(CategoryId, "Slot 10").ToString();
            if (lblSaleCount10.Text == "50")
            {
                SlotPOSEntities ctx5 = new SlotPOSEntities();
                var updateData = (from a in ctx5.tblSlots
                                  where a.SlotNo == "Slot 10" && a.ItemCategoryID == CategoryId
                                  select a).SingleOrDefault();
                if (updateData != null)
                {
                    updateData.Status = "Full";
                    ctx5.SaveChanges();
                    GetSlotTimeByCategoryID(CategoryId);
                }
            }
            lblSaleCount11.Text = getSoldItems(CategoryId, "Slot 11").ToString();
            if (lblSaleCount11.Text == "50")
            {
                SlotPOSEntities ctx5 = new SlotPOSEntities();
                var updateData = (from a in ctx5.tblSlots
                                  where a.SlotNo == "Slot 11" && a.ItemCategoryID == CategoryId
                                  select a).SingleOrDefault();
                if (updateData != null)
                {
                    updateData.Status = "Full";
                    ctx5.SaveChanges();
                    GetSlotTimeByCategoryID(CategoryId);
                }
            }
            lblSaleCount12.Text = getSoldItems(CategoryId, "Slot 12").ToString();
            if (lblSaleCount12.Text == "50")
            {
                SlotPOSEntities ctx5 = new SlotPOSEntities();
                var updateData = (from a in ctx5.tblSlots
                                  where a.SlotNo == "Slot 12" && a.ItemCategoryID == CategoryId
                                  select a).SingleOrDefault();
                if (updateData != null)
                {
                    updateData.Status = "Full";
                    ctx5.SaveChanges();
                    GetSlotTimeByCategoryID(CategoryId);
                }
            }
            lblSaleCount13.Text = getSoldItems(CategoryId, "Slot 13").ToString();
            if (lblSaleCount13.Text == "50")
            {
                SlotPOSEntities ctx5 = new SlotPOSEntities();
                var updateData = (from a in ctx5.tblSlots
                                  where a.SlotNo == "Slot 13" && a.ItemCategoryID == CategoryId
                                  select a).SingleOrDefault();
                if (updateData != null)
                {
                    updateData.Status = "Full";
                    ctx5.SaveChanges();
                    GetSlotTimeByCategoryID(CategoryId);
                }
            }
            lblSaleCount14.Text = getSoldItems(CategoryId, "Slot 14").ToString();
            if (lblSaleCount14.Text == "50")
            {
                SlotPOSEntities ctx5 = new SlotPOSEntities();
                var updateData = (from a in ctx5.tblSlots
                                  where a.SlotNo == "Slot 14" && a.ItemCategoryID == CategoryId
                                  select a).SingleOrDefault();
                if (updateData != null)
                {
                    updateData.Status = "Full";
                    ctx5.SaveChanges();
                    GetSlotTimeByCategoryID(CategoryId);
                }
            }
            lblSaleCount15.Text = getSoldItems(CategoryId, "Slot 15").ToString();
            if (lblSaleCount15.Text == "50")
            {
                SlotPOSEntities ctx5 = new SlotPOSEntities();
                var updateData = (from a in ctx5.tblSlots
                                  where a.SlotNo == "Slot 15" && a.ItemCategoryID == CategoryId
                                  select a).SingleOrDefault();
                if (updateData != null)
                {
                    updateData.Status = "Full";
                    ctx5.SaveChanges();
                    GetSlotTimeByCategoryID(CategoryId);
                }
            }
            //if (Seconds < 1 && Minutes != 0)
            //{
            //    int TotalSecond = 59;
            //    Seconds = TotalSecond - DateTime.Now.Second;
            //    //MessageBox.Show(Seconds.ToString());
            //    if (Minutes == 0)
            //    {
            //        //Minutes = 59;
            //        if (Hours != 0) Hours -= 1;
            //    }
            //    else
            //    {
            //        Minutes -= 1;
            //    }
            //}
            //else Seconds -= 1;

            //if (Hours == 0 && Minutes == 0 && Seconds == 0)
            //{
            //    SlotPOSEntities ctx = new SlotPOSEntities();

            //    var updateData = (from a in ctx.tblSlots
            //                      where a.SlotNo == lblCurrentSlot.Text && a.ItemCategoryID == 1
            //                      select a).SingleOrDefault();
            //    if (updateData != null)
            //    {
            //        updateData.Status = "Done";
            //        ctx.SaveChanges();
            //        GetSlotTimeByCategoryID(1);
            //        SetTimer(1);

            //        timer1.Stop();
            //    }
            //}

            //lblCountDown.Text = Hours.ToString() + " : " + Minutes.ToString() + " : " + Seconds.ToString();
        }

        private void GetOpeningDate()
        {
            SlotPOSEntities ctx = new SlotPOSEntities();

            var getOpeningQuery = (from a in ctx.tblOpeningClosings
                                   where a.ClosingDate == null
                                   orderby a.OpeningClosingID descending
                                   select a).Take(1).SingleOrDefault();
            if (getOpeningQuery != null)
            {
                if (getOpeningQuery.ClosingDate.ToString() == "" && getOpeningQuery.OpeningDate.ToString() != "")
                {
                    lblSaleDate.Text = getOpeningQuery.OpeningDate.ToString("dd-MMM-yy");
                    lblSaleTime.Text = DateTime.Now.ToString("HH:mm:ss tt");
                }
            }
        }

        private void frmSlotScreen_Load(object sender, EventArgs e)
        {
            FillItemCateogry();

            GetOpeningDate();
            updatePreviousStatus();
        }



        private void SetTimer(long _categoryId)
        {
            SlotPOSEntities ctx = new SlotPOSEntities();

            DateTime CurrentTime = DateTime.Parse(DateTime.Now.ToString("HH:mm"));
            TimeSpan Time = CurrentTime.TimeOfDay;
            var getTime = (from a in ctx.tblSlots
                           where a.FromTime.Value <= Time && a.ToTime.Value > Time
                           select a).Take(1).SingleOrDefault();
            if (getTime != null)
            {
                lblCurrentSlot.Text = getTime.SlotNo.ToString();
                TimeSpan diff = getTime.ToTime.Value.Subtract(Time);

                string[] AllTime = diff.ToString().Split(':');
                //Hours = int.Parse(AllTime[0].ToString());
                //Minutes = int.Parse(AllTime[1].ToString());
                //Seconds = 0;//int.Parse(AllTime[2].ToString());
                timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 1000; // 1 second
                timer1.Start();
            }
            else
            {
                var checkTime = (from a in ctx.tblSlots
                                 where a.ItemCategoryID == _categoryId && a.FromTime.Value > Time
                                 select a).Take(1).SingleOrDefault();
                if (checkTime != null)
                {
                    TimeSpan diff = checkTime.FromTime.Value.Subtract(Time);
                    System.Threading.Thread.Sleep(diff);
                    SetTimer(1);
                }
            }
        }

        private void frmSlotScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer1 != null)
                timer1.Stop();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblStatus1.ForeColor = Color.Yellow;
            lblStatus1.Text = "Reserved";

            SlotPOSEntities ctx = new SlotPOSEntities();
            long CategoryId = long.Parse(cmbItemCategory.SelectedValue.ToString());
            var updateData = (from a in ctx.tblSlots
                              where a.SlotNo == "Slot 1" && a.ItemCategoryID == CategoryId
                              select a).SingleOrDefault();
            if (updateData != null)
            {
                updateData.Status = "Reserved";
                ctx.SaveChanges();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblStatus2.ForeColor = Color.Yellow;
            lblStatus2.Text = "Reserved";

            SlotPOSEntities ctx = new SlotPOSEntities();
            long CategoryId = long.Parse(cmbItemCategory.SelectedValue.ToString());
            var updateData = (from a in ctx.tblSlots
                              where a.SlotNo == "Slot 2" && a.ItemCategoryID == CategoryId
                              select a).SingleOrDefault();
            if (updateData != null)
            {
                updateData.Status = "Reserved";
                ctx.SaveChanges();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblStatus3.ForeColor = Color.Yellow;
            lblStatus3.Text = "Reserved";

            SlotPOSEntities ctx = new SlotPOSEntities();
            long CategoryId = long.Parse(cmbItemCategory.SelectedValue.ToString());
            var updateData = (from a in ctx.tblSlots
                              where a.SlotNo == "Slot 3" && a.ItemCategoryID == CategoryId
                              select a).SingleOrDefault();
            if (updateData != null)
            {
                updateData.Status = "Reserved";
                ctx.SaveChanges();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lblStatus4.ForeColor = Color.Yellow;
            lblStatus4.Text = "Reserved";

            SlotPOSEntities ctx = new SlotPOSEntities();
            long CategoryId = long.Parse(cmbItemCategory.SelectedValue.ToString());
            var updateData = (from a in ctx.tblSlots
                              where a.SlotNo == "Slot 4" && a.ItemCategoryID == CategoryId
                              select a).SingleOrDefault();
            if (updateData != null)
            {
                updateData.Status = "Reserved";
                ctx.SaveChanges();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lblStatus5.ForeColor = Color.Yellow;
            lblStatus5.Text = "Reserved";

            SlotPOSEntities ctx = new SlotPOSEntities();
            long CategoryId = long.Parse(cmbItemCategory.SelectedValue.ToString());
            var updateData = (from a in ctx.tblSlots
                              where a.SlotNo == "Slot 5" && a.ItemCategoryID == CategoryId
                              select a).SingleOrDefault();
            if (updateData != null)
            {
                updateData.Status = "Reserved";
                ctx.SaveChanges();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lblStatus6.ForeColor = Color.Yellow;
            lblStatus6.Text = "Reserved";

            SlotPOSEntities ctx = new SlotPOSEntities();
            long CategoryId = long.Parse(cmbItemCategory.SelectedValue.ToString());
            var updateData = (from a in ctx.tblSlots
                              where a.SlotNo == "Slot 6" && a.ItemCategoryID == CategoryId
                              select a).SingleOrDefault();
            if (updateData != null)
            {
                updateData.Status = "Reserved";
                ctx.SaveChanges();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            lblStatus7.ForeColor = Color.Yellow;
            lblStatus7.Text = "Reserved";

            SlotPOSEntities ctx = new SlotPOSEntities();
            long CategoryId = long.Parse(cmbItemCategory.SelectedValue.ToString());
            var updateData = (from a in ctx.tblSlots
                              where a.SlotNo == "Slot 7" && a.ItemCategoryID == CategoryId
                              select a).SingleOrDefault();
            if (updateData != null)
            {
                updateData.Status = "Reserved";
                ctx.SaveChanges();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            lblStatus8.ForeColor = Color.Yellow;
            lblStatus8.Text = "Reserved";

            SlotPOSEntities ctx = new SlotPOSEntities();
            long CategoryId = long.Parse(cmbItemCategory.SelectedValue.ToString());
            var updateData = (from a in ctx.tblSlots
                              where a.SlotNo == "Slot 8" && a.ItemCategoryID == CategoryId
                              select a).SingleOrDefault();
            if (updateData != null)
            {
                updateData.Status = "Reserved";
                ctx.SaveChanges();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            lblStatus9.ForeColor = Color.Yellow;
            lblStatus9.Text = "Reserved";

            SlotPOSEntities ctx = new SlotPOSEntities();
            long CategoryId = long.Parse(cmbItemCategory.SelectedValue.ToString());
            var updateData = (from a in ctx.tblSlots
                              where a.SlotNo == "Slot 9" && a.ItemCategoryID == CategoryId
                              select a).SingleOrDefault();
            if (updateData != null)
            {
                updateData.Status = "Reserved";
                ctx.SaveChanges();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            lblStatus10.ForeColor = Color.Yellow;
            lblStatus10.Text = "Reserved";

            SlotPOSEntities ctx = new SlotPOSEntities();
            long CategoryId = long.Parse(cmbItemCategory.SelectedValue.ToString());
            var updateData = (from a in ctx.tblSlots
                              where a.SlotNo == "Slot 10" && a.ItemCategoryID == CategoryId
                              select a).SingleOrDefault();
            if (updateData != null)
            {
                updateData.Status = "Reserved";
                ctx.SaveChanges();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            lblStatus11.ForeColor = Color.Yellow;
            lblStatus11.Text = "Reserved";

            SlotPOSEntities ctx = new SlotPOSEntities();
            long CategoryId = long.Parse(cmbItemCategory.SelectedValue.ToString());
            var updateData = (from a in ctx.tblSlots
                              where a.SlotNo == "Slot 11" && a.ItemCategoryID == CategoryId
                              select a).SingleOrDefault();
            if (updateData != null)
            {
                updateData.Status = "Reserved";
                ctx.SaveChanges();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            lblStatus12.ForeColor = Color.Yellow;
            lblStatus12.Text = "Reserved";

            SlotPOSEntities ctx = new SlotPOSEntities();
            long CategoryId = long.Parse(cmbItemCategory.SelectedValue.ToString());
            var updateData = (from a in ctx.tblSlots
                              where a.SlotNo == "Slot 12" && a.ItemCategoryID == CategoryId
                              select a).SingleOrDefault();
            if (updateData != null)
            {
                updateData.Status = "Reserved";
                ctx.SaveChanges();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            lblStatus13.ForeColor = Color.Yellow;
            lblStatus13.Text = "Reserved";

            SlotPOSEntities ctx = new SlotPOSEntities();
            long CategoryId = long.Parse(cmbItemCategory.SelectedValue.ToString());
            var updateData = (from a in ctx.tblSlots
                              where a.SlotNo == "Slot 13" && a.ItemCategoryID == CategoryId
                              select a).SingleOrDefault();
            if (updateData != null)
            {
                updateData.Status = "Reserved";
                ctx.SaveChanges();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            lblStatus14.ForeColor = Color.Yellow;
            lblStatus14.Text = "Reserved";

            SlotPOSEntities ctx = new SlotPOSEntities();
            long CategoryId = long.Parse(cmbItemCategory.SelectedValue.ToString());
            var updateData = (from a in ctx.tblSlots
                              where a.SlotNo == "Slot 14" && a.ItemCategoryID == CategoryId
                              select a).SingleOrDefault();
            if (updateData != null)
            {
                updateData.Status = "Reserved";
                ctx.SaveChanges();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            lblStatus15.ForeColor = Color.Yellow;
            lblStatus15.Text = "Reserved";

            SlotPOSEntities ctx = new SlotPOSEntities();
            long CategoryId = long.Parse(cmbItemCategory.SelectedValue.ToString());
            var updateData = (from a in ctx.tblSlots
                              where a.SlotNo == "Slot 15" && a.ItemCategoryID == CategoryId
                              select a).SingleOrDefault();
            if (updateData != null)
            {
                updateData.Status = "Reserved";
                ctx.SaveChanges();
            }
        }

        private void cmbItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItemCategory.SelectedIndex > 0)
            {
                long CateogryID = long.Parse(cmbItemCategory.SelectedValue.ToString());
                GetSlotTimeByCategoryID(CateogryID);
                //SetTimer(1);

                timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Enabled = true;
                timer1.Interval = 1000; // 1 second
                timer1.Start();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cmbItemCategory.SelectedIndex > 0)
            {
                long CategoryID = long.Parse(cmbItemCategory.SelectedValue.ToString());

                GetSlotTimeByCategoryID(CategoryID);
                SetTimer1(CategoryID);
            }
        }
    }
}
