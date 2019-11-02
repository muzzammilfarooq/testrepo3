namespace SlotPOS
{
    partial class frmItemSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemSetup));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblItemID = new System.Windows.Forms.Label();
            this.checkBoxCriteria = new System.Windows.Forms.CheckBox();
            this.chkRFIDWatch = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxCriteria = new System.Windows.Forms.GroupBox();
            this.checkBoxDayBase = new System.Windows.Forms.CheckBox();
            this.groupBoxDayBase = new System.Windows.Forms.GroupBox();
            this.checkBoxSUND = new System.Windows.Forms.CheckBox();
            this.checkBoxWed = new System.Windows.Forms.CheckBox();
            this.checkBoxSAT = new System.Windows.Forms.CheckBox();
            this.checkBoxFRI = new System.Windows.Forms.CheckBox();
            this.checkBoxThu = new System.Windows.Forms.CheckBox();
            this.checkBoxTUE = new System.Windows.Forms.CheckBox();
            this.checkBoxMonday = new System.Windows.Forms.CheckBox();
            this.dateTimePickerTO = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.checkBoxDateBase = new System.Windows.Forms.CheckBox();
            this.groupBoxDateBase = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.TimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.checkBoxTimeBase = new System.Windows.Forms.CheckBox();
            this.groupBoxTimeBase = new System.Windows.Forms.GroupBox();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Todate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsMonday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsTuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsWednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsThursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsFriday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSaturday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSunday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDayBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsTimeBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDateBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCriteria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.groupBoxCriteria.SuspendLayout();
            this.groupBoxDayBase.SuspendLayout();
            this.groupBoxDateBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(532, 547);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Red;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(370, 547);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(83, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item ID";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Red;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(451, 547);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblItemID);
            this.groupBox1.Controls.Add(this.checkBoxCriteria);
            this.groupBox1.Controls.Add(this.chkRFIDWatch);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUnit);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtItem);
            this.groupBox1.Controls.Add(this.txtItemID);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ITEM";
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.ForeColor = System.Drawing.Color.White;
            this.lblItemID.Location = new System.Drawing.Point(280, 24);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(13, 13);
            this.lblItemID.TabIndex = 20;
            this.lblItemID.Text = "0";
            // 
            // checkBoxCriteria
            // 
            this.checkBoxCriteria.AutoSize = true;
            this.checkBoxCriteria.Location = new System.Drawing.Point(130, 116);
            this.checkBoxCriteria.Name = "checkBoxCriteria";
            this.checkBoxCriteria.Size = new System.Drawing.Size(58, 17);
            this.checkBoxCriteria.TabIndex = 19;
            this.checkBoxCriteria.Text = "Criteria";
            this.checkBoxCriteria.UseVisualStyleBackColor = true;
            this.checkBoxCriteria.CheckedChanged += new System.EventHandler(this.checkBoxCriteria_CheckedChanged_1);
            // 
            // chkRFIDWatch
            // 
            this.chkRFIDWatch.AutoSize = true;
            this.chkRFIDWatch.Location = new System.Drawing.Point(416, 93);
            this.chkRFIDWatch.Name = "chkRFIDWatch";
            this.chkRFIDWatch.Size = new System.Drawing.Size(86, 17);
            this.chkRFIDWatch.TabIndex = 18;
            this.chkRFIDWatch.Text = "RFID Watch";
            this.chkRFIDWatch.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(19, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Select Item Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(130, 62);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(154, 21);
            this.cmbCategory.TabIndex = 1;
            this.cmbCategory.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(66, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Item Name";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(416, 62);
            this.txtPrice.MaxLength = 6;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(154, 20);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(384, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Unit";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(416, 36);
            this.txtUnit.MaxLength = 10;
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(154, 20);
            this.txtUnit.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(379, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Price";
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(130, 90);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(154, 20);
            this.txtItem.TabIndex = 1;
            // 
            // txtItemID
            // 
            this.txtItemID.Location = new System.Drawing.Point(130, 36);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.ReadOnly = true;
            this.txtItemID.Size = new System.Drawing.Size(72, 20);
            this.txtItemID.TabIndex = 4;
            this.txtItemID.TabStop = false;
            // 
            // dgvItem
            // 
            this.dgvItem.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.ItemCategory,
            this.ItemName,
            this.Unit,
            this.Price,
            this.FromTime,
            this.ToTime,
            this.FromDate,
            this.Todate,
            this.IsMonday,
            this.IsTuesday,
            this.IsWednesday,
            this.IsThursday,
            this.IsFriday,
            this.IsSaturday,
            this.IsSunday,
            this.IsDayBase,
            this.IsTimeBase,
            this.IsDateBase,
            this.IsCriteria});
            this.dgvItem.Location = new System.Drawing.Point(612, 48);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.Size = new System.Drawing.Size(593, 493);
            this.dgvItem.TabIndex = 13;
            this.dgvItem.TabStop = false;
            this.dgvItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItem_CellDoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(583, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(14, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Item Setup";
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // groupBoxCriteria
            // 
            this.groupBoxCriteria.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxCriteria.Controls.Add(this.checkBoxDayBase);
            this.groupBoxCriteria.Controls.Add(this.groupBoxDayBase);
            this.groupBoxCriteria.Controls.Add(this.dateTimePickerTO);
            this.groupBoxCriteria.Controls.Add(this.label10);
            this.groupBoxCriteria.Controls.Add(this.dateTimePickerFrom);
            this.groupBoxCriteria.Controls.Add(this.checkBoxDateBase);
            this.groupBoxCriteria.Controls.Add(this.groupBoxDateBase);
            this.groupBoxCriteria.Controls.Add(this.label8);
            this.groupBoxCriteria.Controls.Add(this.TimePickerTo);
            this.groupBoxCriteria.Controls.Add(this.label7);
            this.groupBoxCriteria.Controls.Add(this.TimePickerFrom);
            this.groupBoxCriteria.Controls.Add(this.checkBoxTimeBase);
            this.groupBoxCriteria.Controls.Add(this.groupBoxTimeBase);
            this.groupBoxCriteria.ForeColor = System.Drawing.Color.White;
            this.groupBoxCriteria.Location = new System.Drawing.Point(12, 204);
            this.groupBoxCriteria.Name = "groupBoxCriteria";
            this.groupBoxCriteria.Size = new System.Drawing.Size(593, 337);
            this.groupBoxCriteria.TabIndex = 17;
            this.groupBoxCriteria.TabStop = false;
            this.groupBoxCriteria.Text = "Criteria";
            // 
            // checkBoxDayBase
            // 
            this.checkBoxDayBase.AutoSize = true;
            this.checkBoxDayBase.Location = new System.Drawing.Point(35, 193);
            this.checkBoxDayBase.Name = "checkBoxDayBase";
            this.checkBoxDayBase.Size = new System.Drawing.Size(72, 17);
            this.checkBoxDayBase.TabIndex = 12;
            this.checkBoxDayBase.Text = "Day Base";
            this.checkBoxDayBase.UseVisualStyleBackColor = true;
            this.checkBoxDayBase.CheckedChanged += new System.EventHandler(this.checkBoxDayBase_CheckedChanged_1);
            // 
            // groupBoxDayBase
            // 
            this.groupBoxDayBase.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxDayBase.Controls.Add(this.checkBoxSUND);
            this.groupBoxDayBase.Controls.Add(this.checkBoxWed);
            this.groupBoxDayBase.Controls.Add(this.checkBoxSAT);
            this.groupBoxDayBase.Controls.Add(this.checkBoxFRI);
            this.groupBoxDayBase.Controls.Add(this.checkBoxThu);
            this.groupBoxDayBase.Controls.Add(this.checkBoxTUE);
            this.groupBoxDayBase.Controls.Add(this.checkBoxMonday);
            this.groupBoxDayBase.ForeColor = System.Drawing.Color.White;
            this.groupBoxDayBase.Location = new System.Drawing.Point(27, 217);
            this.groupBoxDayBase.Name = "groupBoxDayBase";
            this.groupBoxDayBase.Size = new System.Drawing.Size(485, 112);
            this.groupBoxDayBase.TabIndex = 17;
            this.groupBoxDayBase.TabStop = false;
            this.groupBoxDayBase.Text = "Day";
            // 
            // checkBoxSUND
            // 
            this.checkBoxSUND.AutoSize = true;
            this.checkBoxSUND.Location = new System.Drawing.Point(10, 89);
            this.checkBoxSUND.Name = "checkBoxSUND";
            this.checkBoxSUND.Size = new System.Drawing.Size(62, 17);
            this.checkBoxSUND.TabIndex = 24;
            this.checkBoxSUND.Text = "Sunday";
            this.checkBoxSUND.UseVisualStyleBackColor = true;
            // 
            // checkBoxWed
            // 
            this.checkBoxWed.AutoSize = true;
            this.checkBoxWed.Location = new System.Drawing.Point(150, 28);
            this.checkBoxWed.Name = "checkBoxWed";
            this.checkBoxWed.Size = new System.Drawing.Size(83, 17);
            this.checkBoxWed.TabIndex = 23;
            this.checkBoxWed.Text = "Wednesday";
            this.checkBoxWed.UseVisualStyleBackColor = true;
            // 
            // checkBoxSAT
            // 
            this.checkBoxSAT.AutoSize = true;
            this.checkBoxSAT.Location = new System.Drawing.Point(150, 60);
            this.checkBoxSAT.Name = "checkBoxSAT";
            this.checkBoxSAT.Size = new System.Drawing.Size(68, 17);
            this.checkBoxSAT.TabIndex = 22;
            this.checkBoxSAT.Text = "Saturday";
            this.checkBoxSAT.UseVisualStyleBackColor = true;
            // 
            // checkBoxFRI
            // 
            this.checkBoxFRI.AutoSize = true;
            this.checkBoxFRI.Location = new System.Drawing.Point(80, 60);
            this.checkBoxFRI.Name = "checkBoxFRI";
            this.checkBoxFRI.Size = new System.Drawing.Size(54, 17);
            this.checkBoxFRI.TabIndex = 21;
            this.checkBoxFRI.Text = "Friday";
            this.checkBoxFRI.UseVisualStyleBackColor = true;
            // 
            // checkBoxThu
            // 
            this.checkBoxThu.AutoSize = true;
            this.checkBoxThu.Location = new System.Drawing.Point(10, 60);
            this.checkBoxThu.Name = "checkBoxThu";
            this.checkBoxThu.Size = new System.Drawing.Size(70, 17);
            this.checkBoxThu.TabIndex = 20;
            this.checkBoxThu.Text = "Thursday";
            this.checkBoxThu.UseVisualStyleBackColor = true;
            // 
            // checkBoxTUE
            // 
            this.checkBoxTUE.AutoSize = true;
            this.checkBoxTUE.Location = new System.Drawing.Point(80, 28);
            this.checkBoxTUE.Name = "checkBoxTUE";
            this.checkBoxTUE.Size = new System.Drawing.Size(67, 17);
            this.checkBoxTUE.TabIndex = 19;
            this.checkBoxTUE.Text = "Tuesday";
            this.checkBoxTUE.UseVisualStyleBackColor = true;
            // 
            // checkBoxMonday
            // 
            this.checkBoxMonday.AutoSize = true;
            this.checkBoxMonday.Location = new System.Drawing.Point(10, 28);
            this.checkBoxMonday.Name = "checkBoxMonday";
            this.checkBoxMonday.Size = new System.Drawing.Size(64, 17);
            this.checkBoxMonday.TabIndex = 18;
            this.checkBoxMonday.Text = "Monday";
            this.checkBoxMonday.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerTO
            // 
            this.dateTimePickerTO.Location = new System.Drawing.Point(328, 153);
            this.dateTimePickerTO.Name = "dateTimePickerTO";
            this.dateTimePickerTO.Size = new System.Drawing.Size(181, 20);
            this.dateTimePickerTO.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(34, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "From Time";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(91, 153);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(185, 20);
            this.dateTimePickerFrom.TabIndex = 7;
            // 
            // checkBoxDateBase
            // 
            this.checkBoxDateBase.AutoSize = true;
            this.checkBoxDateBase.Location = new System.Drawing.Point(33, 104);
            this.checkBoxDateBase.Name = "checkBoxDateBase";
            this.checkBoxDateBase.Size = new System.Drawing.Size(76, 17);
            this.checkBoxDateBase.TabIndex = 6;
            this.checkBoxDateBase.Text = "Date Base";
            this.checkBoxDateBase.UseVisualStyleBackColor = true;
            this.checkBoxDateBase.CheckedChanged += new System.EventHandler(this.checkBoxDateBase_CheckedChanged_1);
            // 
            // groupBoxDateBase
            // 
            this.groupBoxDateBase.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxDateBase.Controls.Add(this.label9);
            this.groupBoxDateBase.ForeColor = System.Drawing.Color.White;
            this.groupBoxDateBase.Location = new System.Drawing.Point(27, 128);
            this.groupBoxDateBase.Name = "groupBoxDateBase";
            this.groupBoxDateBase.Size = new System.Drawing.Size(485, 55);
            this.groupBoxDateBase.TabIndex = 11;
            this.groupBoxDateBase.TabStop = false;
            this.groupBoxDateBase.Text = "Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(255, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "To Time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(282, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "To Time";
            // 
            // TimePickerTo
            // 
            this.TimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimePickerTo.Location = new System.Drawing.Point(345, 68);
            this.TimePickerTo.Name = "TimePickerTo";
            this.TimePickerTo.ShowUpDown = true;
            this.TimePickerTo.Size = new System.Drawing.Size(158, 20);
            this.TimePickerTo.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(36, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "From Time";
            // 
            // TimePickerFrom
            // 
            this.TimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimePickerFrom.Location = new System.Drawing.Point(100, 68);
            this.TimePickerFrom.Name = "TimePickerFrom";
            this.TimePickerFrom.ShowUpDown = true;
            this.TimePickerFrom.Size = new System.Drawing.Size(158, 20);
            this.TimePickerFrom.TabIndex = 1;
            // 
            // checkBoxTimeBase
            // 
            this.checkBoxTimeBase.AutoSize = true;
            this.checkBoxTimeBase.Location = new System.Drawing.Point(37, 19);
            this.checkBoxTimeBase.Name = "checkBoxTimeBase";
            this.checkBoxTimeBase.Size = new System.Drawing.Size(76, 17);
            this.checkBoxTimeBase.TabIndex = 0;
            this.checkBoxTimeBase.Text = "Time Base";
            this.checkBoxTimeBase.UseVisualStyleBackColor = true;
            this.checkBoxTimeBase.CheckedChanged += new System.EventHandler(this.checkBoxTimeBase_CheckedChanged_1);
            // 
            // groupBoxTimeBase
            // 
            this.groupBoxTimeBase.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxTimeBase.ForeColor = System.Drawing.Color.White;
            this.groupBoxTimeBase.Location = new System.Drawing.Point(29, 43);
            this.groupBoxTimeBase.Name = "groupBoxTimeBase";
            this.groupBoxTimeBase.Size = new System.Drawing.Size(485, 55);
            this.groupBoxTimeBase.TabIndex = 5;
            this.groupBoxTimeBase.TabStop = false;
            this.groupBoxTimeBase.Text = "Time";
            // 
            // ItemID
            // 
            this.ItemID.DataPropertyName = "ItemID";
            this.ItemID.HeaderText = "ID";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            this.ItemID.Width = 50;
            // 
            // ItemCategory
            // 
            this.ItemCategory.DataPropertyName = "ItemCategory";
            this.ItemCategory.HeaderText = "Item Category Name";
            this.ItemCategory.Name = "ItemCategory";
            this.ItemCategory.ReadOnly = true;
            this.ItemCategory.Width = 180;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 160;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Width = 80;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 80;
            // 
            // FromTime
            // 
            this.FromTime.DataPropertyName = "FromTime";
            this.FromTime.HeaderText = "From Time";
            this.FromTime.Name = "FromTime";
            this.FromTime.ReadOnly = true;
            // 
            // ToTime
            // 
            this.ToTime.DataPropertyName = "ToTime";
            this.ToTime.HeaderText = "To Time";
            this.ToTime.Name = "ToTime";
            this.ToTime.ReadOnly = true;
            // 
            // FromDate
            // 
            this.FromDate.DataPropertyName = "FromDate";
            this.FromDate.HeaderText = "From Date";
            this.FromDate.Name = "FromDate";
            this.FromDate.ReadOnly = true;
            // 
            // Todate
            // 
            this.Todate.DataPropertyName = "Todate";
            this.Todate.HeaderText = "To Date";
            this.Todate.Name = "Todate";
            this.Todate.ReadOnly = true;
            // 
            // IsMonday
            // 
            this.IsMonday.DataPropertyName = "IsMonday";
            this.IsMonday.HeaderText = "Monday";
            this.IsMonday.Name = "IsMonday";
            this.IsMonday.ReadOnly = true;
            this.IsMonday.Visible = false;
            // 
            // IsTuesday
            // 
            this.IsTuesday.DataPropertyName = "IsTuesday";
            this.IsTuesday.HeaderText = "Tuesday";
            this.IsTuesday.Name = "IsTuesday";
            this.IsTuesday.ReadOnly = true;
            this.IsTuesday.Visible = false;
            // 
            // IsWednesday
            // 
            this.IsWednesday.DataPropertyName = "IsWednesday";
            this.IsWednesday.HeaderText = "Wednesday";
            this.IsWednesday.Name = "IsWednesday";
            this.IsWednesday.ReadOnly = true;
            this.IsWednesday.Visible = false;
            // 
            // IsThursday
            // 
            this.IsThursday.DataPropertyName = "IsThusday";
            this.IsThursday.HeaderText = "Thursday";
            this.IsThursday.Name = "IsThursday";
            this.IsThursday.ReadOnly = true;
            this.IsThursday.Visible = false;
            // 
            // IsFriday
            // 
            this.IsFriday.DataPropertyName = "IsFriday";
            this.IsFriday.HeaderText = "Friday";
            this.IsFriday.Name = "IsFriday";
            this.IsFriday.ReadOnly = true;
            this.IsFriday.Visible = false;
            // 
            // IsSaturday
            // 
            this.IsSaturday.DataPropertyName = "IsSaturday";
            this.IsSaturday.HeaderText = "Saturday";
            this.IsSaturday.Name = "IsSaturday";
            this.IsSaturday.ReadOnly = true;
            this.IsSaturday.Visible = false;
            // 
            // IsSunday
            // 
            this.IsSunday.DataPropertyName = "IsSunday";
            this.IsSunday.HeaderText = "Sunday";
            this.IsSunday.Name = "IsSunday";
            this.IsSunday.ReadOnly = true;
            this.IsSunday.Visible = false;
            // 
            // IsDayBase
            // 
            this.IsDayBase.DataPropertyName = "IsDayBase";
            this.IsDayBase.HeaderText = "Day Base";
            this.IsDayBase.Name = "IsDayBase";
            this.IsDayBase.ReadOnly = true;
            this.IsDayBase.Visible = false;
            // 
            // IsTimeBase
            // 
            this.IsTimeBase.DataPropertyName = "IsTimeBase";
            this.IsTimeBase.HeaderText = "Time Base";
            this.IsTimeBase.Name = "IsTimeBase";
            this.IsTimeBase.ReadOnly = true;
            this.IsTimeBase.Visible = false;
            // 
            // IsDateBase
            // 
            this.IsDateBase.DataPropertyName = "IsDateBase";
            this.IsDateBase.HeaderText = "Date Base";
            this.IsDateBase.Name = "IsDateBase";
            this.IsDateBase.ReadOnly = true;
            this.IsDateBase.Visible = false;
            // 
            // IsCriteria
            // 
            this.IsCriteria.DataPropertyName = "IsCriteria";
            this.IsCriteria.HeaderText = "Criteria";
            this.IsCriteria.Name = "IsCriteria";
            this.IsCriteria.ReadOnly = true;
            this.IsCriteria.Visible = false;
            // 
            // frmItemSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1209, 595);
            this.Controls.Add(this.groupBoxCriteria);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvItem);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItemSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmItemSetup";
            this.Load += new System.EventHandler(this.frmItemSetup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.groupBoxCriteria.ResumeLayout(false);
            this.groupBoxCriteria.PerformLayout();
            this.groupBoxDayBase.ResumeLayout(false);
            this.groupBoxDayBase.PerformLayout();
            this.groupBoxDateBase.ResumeLayout(false);
            this.groupBoxDateBase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.CheckBox chkRFIDWatch;
        private System.Windows.Forms.CheckBox checkBoxCriteria;
        private System.Windows.Forms.GroupBox groupBoxCriteria;
        private System.Windows.Forms.CheckBox checkBoxDayBase;
        private System.Windows.Forms.GroupBox groupBoxDayBase;
        private System.Windows.Forms.CheckBox checkBoxSUND;
        private System.Windows.Forms.CheckBox checkBoxWed;
        private System.Windows.Forms.CheckBox checkBoxSAT;
        private System.Windows.Forms.CheckBox checkBoxFRI;
        private System.Windows.Forms.CheckBox checkBoxThu;
        private System.Windows.Forms.CheckBox checkBoxTUE;
        private System.Windows.Forms.CheckBox checkBoxMonday;
        private System.Windows.Forms.DateTimePicker dateTimePickerTO;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.CheckBox checkBoxDateBase;
        private System.Windows.Forms.GroupBox groupBoxDateBase;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker TimePickerTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker TimePickerFrom;
        private System.Windows.Forms.CheckBox checkBoxTimeBase;
        private System.Windows.Forms.GroupBox groupBoxTimeBase;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Todate;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsMonday;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsTuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsWednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsThursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsFriday;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsSaturday;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsSunday;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDayBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsTimeBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDateBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsCriteria;
    }
}