namespace SlotPOS
{
    partial class frmSlotPOS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSlotPOS));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvPOS = new System.Windows.Forms.DataGridView();
            this.colItemCatID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsSlotCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTicketIssueID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnCloseOrder = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTransID = new System.Windows.Forms.TextBox();
            this.lnkLabelClose = new System.Windows.Forms.LinkLabel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblCounter = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblSaleDate = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLOT = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemainingTickets = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSoldOut = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInHand = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTicketIssueID = new System.Windows.Forms.Label();
            this.lblCategoryID = new System.Windows.Forms.Label();
            this.lblSlotItemCount = new System.Windows.Forms.Label();
            this.txtItemCount = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMobileNumber = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panelHide = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTopUpAmount = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.lblMemberAmount = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblCardType = new System.Windows.Forms.Label();
            this.btnRemoveWatch = new System.Windows.Forms.Button();
            this.btnAddWatch = new System.Windows.Forms.Button();
            this.lblWristBandItem = new System.Windows.Forms.Label();
            this.lblWatchItem = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPromotionAmount = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panelHide.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(638, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 243);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CATEGORY";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(30, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 218);
            this.panel1.TabIndex = 0;
            // 
            // dgvPOS
            // 
            this.dgvPOS.AllowUserToDeleteRows = false;
            this.dgvPOS.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvPOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPOS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemCatID,
            this.colItemID,
            this.ItemName,
            this.Quantity,
            this.Price,
            this.Amount,
            this.colIsSlotCat,
            this.colTicketIssueID,
            this.RFID});
            this.dgvPOS.Location = new System.Drawing.Point(25, 469);
            this.dgvPOS.MultiSelect = false;
            this.dgvPOS.Name = "dgvPOS";
            this.dgvPOS.ReadOnly = true;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPOS.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPOS.Size = new System.Drawing.Size(492, 309);
            this.dgvPOS.TabIndex = 60;
            this.dgvPOS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPOS_KeyDown);
            // 
            // colItemCatID
            // 
            this.colItemCatID.HeaderText = "CategoryID";
            this.colItemCatID.Name = "colItemCatID";
            this.colItemCatID.ReadOnly = true;
            this.colItemCatID.Visible = false;
            // 
            // colItemID
            // 
            this.colItemID.HeaderText = "ItemID";
            this.colItemID.Name = "colItemID";
            this.colItemID.ReadOnly = true;
            this.colItemID.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 200;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 50;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // colIsSlotCat
            // 
            this.colIsSlotCat.HeaderText = "SlotCategory";
            this.colIsSlotCat.Name = "colIsSlotCat";
            this.colIsSlotCat.ReadOnly = true;
            this.colIsSlotCat.Visible = false;
            this.colIsSlotCat.Width = 50;
            // 
            // colTicketIssueID
            // 
            this.colTicketIssueID.HeaderText = "TicketIssueID";
            this.colTicketIssueID.Name = "colTicketIssueID";
            this.colTicketIssueID.ReadOnly = true;
            // 
            // RFID
            // 
            this.RFID.HeaderText = "RFID";
            this.RFID.Name = "RFID";
            this.RFID.ReadOnly = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.White;
            this.label35.Location = new System.Drawing.Point(734, 15);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(129, 25);
            this.label35.TabIndex = 59;
            this.label35.Text = "SALE DATE:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.ForeColor = System.Drawing.Color.White;
            this.label34.Location = new System.Drawing.Point(453, 22);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(101, 13);
            this.label34.TabIndex = 58;
            this.label34.Text = "TRANSACTION ID:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.ForeColor = System.Drawing.Color.White;
            this.label33.Location = new System.Drawing.Point(22, 24);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(63, 13);
            this.label33.TabIndex = 57;
            this.label33.Text = "COUNTER:";
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.BackColor = System.Drawing.Color.DarkRed;
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveItem.ForeColor = System.Drawing.Color.White;
            this.btnRemoveItem.Location = new System.Drawing.Point(518, 469);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(112, 57);
            this.btnRemoveItem.TabIndex = 61;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = false;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            this.btnRemoveItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnRemoveItem_KeyDown);
            // 
            // btnCloseOrder
            // 
            this.btnCloseOrder.BackColor = System.Drawing.Color.DarkRed;
            this.btnCloseOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCloseOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseOrder.ForeColor = System.Drawing.Color.White;
            this.btnCloseOrder.Location = new System.Drawing.Point(25, 812);
            this.btnCloseOrder.Name = "btnCloseOrder";
            this.btnCloseOrder.Size = new System.Drawing.Size(338, 128);
            this.btnCloseOrder.TabIndex = 63;
            this.btnCloseOrder.Text = "CLOSE ORDER (F3)";
            this.btnCloseOrder.UseVisualStyleBackColor = false;
            this.btnCloseOrder.Click += new System.EventHandler(this.button24_Click);
            this.btnCloseOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCloseOrder_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(636, 321);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(632, 512);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ITEM";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(21, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(595, 493);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 81);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 100);
            this.panel4.TabIndex = 460;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 81);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 460;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1220, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 49);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 65;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(243, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "USER NAME:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(7, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(498, 55);
            this.label2.TabIndex = 67;
            this.label2.Text = "Super Space Karachi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(349, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 55);
            this.label3.TabIndex = 67;
            // 
            // txtTransID
            // 
            this.txtTransID.Location = new System.Drawing.Point(560, 19);
            this.txtTransID.Name = "txtTransID";
            this.txtTransID.ReadOnly = true;
            this.txtTransID.Size = new System.Drawing.Size(70, 20);
            this.txtTransID.TabIndex = 68;
            this.txtTransID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransID_KeyDown);
            this.txtTransID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransID_KeyPress);
            // 
            // lnkLabelClose
            // 
            this.lnkLabelClose.AutoSize = true;
            this.lnkLabelClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLabelClose.Location = new System.Drawing.Point(1129, 30);
            this.lnkLabelClose.Name = "lnkLabelClose";
            this.lnkLabelClose.Size = new System.Drawing.Size(81, 20);
            this.lnkLabelClose.TabIndex = 439;
            this.lnkLabelClose.TabStop = true;
            this.lnkLabelClose.Text = "Day Close";
            this.lnkLabelClose.Visible = false;
            this.lnkLabelClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLabelClose_LinkClicked);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.White;
            this.lblTotalAmount.Location = new System.Drawing.Point(369, 960);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(0, 46);
            this.lblTotalAmount.TabIndex = 440;
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.BackColor = System.Drawing.Color.Transparent;
            this.lblCounter.ForeColor = System.Drawing.Color.White;
            this.lblCounter.Location = new System.Drawing.Point(87, 23);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(0, 13);
            this.lblCounter.TabIndex = 441;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(323, 22);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 13);
            this.lblUsername.TabIndex = 442;
            // 
            // lblSaleDate
            // 
            this.lblSaleDate.AutoSize = true;
            this.lblSaleDate.BackColor = System.Drawing.Color.Transparent;
            this.lblSaleDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaleDate.ForeColor = System.Drawing.Color.White;
            this.lblSaleDate.Location = new System.Drawing.Point(873, 9);
            this.lblSaleDate.Name = "lblSaleDate";
            this.lblSaleDate.Size = new System.Drawing.Size(0, 46);
            this.lblSaleDate.TabIndex = 443;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtLOT);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtRemainingTickets);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtSoldOut);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtInHand);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(24, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(493, 83);
            this.groupBox3.TabIndex = 444;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TICKET SLOT";
            // 
            // txtLOT
            // 
            this.txtLOT.Location = new System.Drawing.Point(68, 19);
            this.txtLOT.Name = "txtLOT";
            this.txtLOT.ReadOnly = true;
            this.txtLOT.Size = new System.Drawing.Size(239, 20);
            this.txtLOT.TabIndex = 452;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(20, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 451;
            this.label8.Text = "LOT";
            // 
            // txtRemainingTickets
            // 
            this.txtRemainingTickets.Location = new System.Drawing.Point(381, 45);
            this.txtRemainingTickets.Name = "txtRemainingTickets";
            this.txtRemainingTickets.ReadOnly = true;
            this.txtRemainingTickets.Size = new System.Drawing.Size(88, 20);
            this.txtRemainingTickets.TabIndex = 450;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(318, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 449;
            this.label6.Text = "Remaining";
            // 
            // txtSoldOut
            // 
            this.txtSoldOut.Location = new System.Drawing.Point(219, 45);
            this.txtSoldOut.Name = "txtSoldOut";
            this.txtSoldOut.ReadOnly = true;
            this.txtSoldOut.Size = new System.Drawing.Size(88, 20);
            this.txtSoldOut.TabIndex = 448;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(165, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 447;
            this.label4.Text = "Sold Out";
            // 
            // txtInHand
            // 
            this.txtInHand.Location = new System.Drawing.Point(68, 45);
            this.txtInHand.Name = "txtInHand";
            this.txtInHand.ReadOnly = true;
            this.txtInHand.Size = new System.Drawing.Size(88, 20);
            this.txtInHand.TabIndex = 446;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(17, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 445;
            this.label5.Text = "In Hand";
            // 
            // lblTicketIssueID
            // 
            this.lblTicketIssueID.AutoSize = true;
            this.lblTicketIssueID.ForeColor = System.Drawing.Color.White;
            this.lblTicketIssueID.Location = new System.Drawing.Point(240, 40);
            this.lblTicketIssueID.Name = "lblTicketIssueID";
            this.lblTicketIssueID.Size = new System.Drawing.Size(0, 13);
            this.lblTicketIssueID.TabIndex = 451;
            this.lblTicketIssueID.Visible = false;
            // 
            // lblCategoryID
            // 
            this.lblCategoryID.AutoSize = true;
            this.lblCategoryID.ForeColor = System.Drawing.Color.White;
            this.lblCategoryID.Location = new System.Drawing.Point(364, 40);
            this.lblCategoryID.Name = "lblCategoryID";
            this.lblCategoryID.Size = new System.Drawing.Size(0, 13);
            this.lblCategoryID.TabIndex = 451;
            this.lblCategoryID.Visible = false;
            // 
            // lblSlotItemCount
            // 
            this.lblSlotItemCount.AutoSize = true;
            this.lblSlotItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.lblSlotItemCount.ForeColor = System.Drawing.Color.Crimson;
            this.lblSlotItemCount.Location = new System.Drawing.Point(252, 105);
            this.lblSlotItemCount.Name = "lblSlotItemCount";
            this.lblSlotItemCount.Size = new System.Drawing.Size(0, 46);
            this.lblSlotItemCount.TabIndex = 451;
            this.lblSlotItemCount.Visible = false;
            // 
            // txtItemCount
            // 
            this.txtItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCount.Location = new System.Drawing.Point(249, 102);
            this.txtItemCount.Name = "txtItemCount";
            this.txtItemCount.ReadOnly = true;
            this.txtItemCount.Size = new System.Drawing.Size(82, 38);
            this.txtItemCount.TabIndex = 451;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.White;
            this.lblItemName.Location = new System.Drawing.Point(28, 108);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(0, 25);
            this.lblItemName.TabIndex = 451;
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.DarkRed;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(636, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(27, 20);
            this.btnRefresh.TabIndex = 452;
            this.btnRefresh.Text = "R";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryName.ForeColor = System.Drawing.Color.White;
            this.lblCategoryName.Location = new System.Drawing.Point(340, 105);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(0, 31);
            this.lblCategoryName.TabIndex = 453;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(18, 960);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(354, 46);
            this.label7.TabIndex = 455;
            this.label7.Text = "TOTAL AMOUNT :";
            // 
            // txtMobileNumber
            // 
            this.txtMobileNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNumber.Location = new System.Drawing.Point(29, 180);
            this.txtMobileNumber.Name = "txtMobileNumber";
            this.txtMobileNumber.ReadOnly = true;
            this.txtMobileNumber.Size = new System.Drawing.Size(200, 38);
            this.txtMobileNumber.TabIndex = 459;
            this.txtMobileNumber.TextChanged += new System.EventHandler(this.txtMobileNumber_TextChanged);
            this.txtMobileNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobileNumber_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label10.Location = new System.Drawing.Point(25, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(184, 31);
            this.label10.TabIndex = 458;
            this.label10.Text = "RFID Code #";
            // 
            // panelHide
            // 
            this.panelHide.Controls.Add(this.groupBox3);
            this.panelHide.Controls.Add(this.lblTicketIssueID);
            this.panelHide.Controls.Add(this.lblCategoryName);
            this.panelHide.Controls.Add(this.lblCategoryID);
            this.panelHide.Controls.Add(this.txtItemCount);
            this.panelHide.Controls.Add(this.lblItemName);
            this.panelHide.Location = new System.Drawing.Point(181, 157);
            this.panelHide.Name = "panelHide";
            this.panelHide.Size = new System.Drawing.Size(10, 10);
            this.panelHide.TabIndex = 460;
            this.panelHide.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label9.Location = new System.Drawing.Point(25, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(270, 31);
            this.label9.TabIndex = 462;
            this.label9.Text = "TOP UP AMOUNT :";
            // 
            // lblTopUpAmount
            // 
            this.lblTopUpAmount.AutoSize = true;
            this.lblTopUpAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTopUpAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopUpAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTopUpAmount.Location = new System.Drawing.Point(250, 262);
            this.lblTopUpAmount.Name = "lblTopUpAmount";
            this.lblTopUpAmount.Size = new System.Drawing.Size(99, 108);
            this.lblTopUpAmount.TabIndex = 461;
            this.lblTopUpAmount.Text = "0";
            this.lblTopUpAmount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(237, 188);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 29);
            this.lblError.TabIndex = 463;
            this.lblError.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(638, 960);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(457, 46);
            this.label11.TabIndex = 464;
            this.label11.Text = "AVAILABLE BALANCE :";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.BackColor = System.Drawing.Color.Transparent;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.White;
            this.lblBalance.Location = new System.Drawing.Point(1098, 960);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(42, 46);
            this.lblBalance.TabIndex = 465;
            this.lblBalance.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(8, 262);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(242, 108);
            this.label12.TabIndex = 461;
            this.label12.Text = "PKR";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label13.Location = new System.Drawing.Point(638, 840);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(312, 25);
            this.label13.TabIndex = 466;
            this.label13.Text = "Press F5 To Decrease Amount ";
            // 
            // lblMemberAmount
            // 
            this.lblMemberAmount.AutoSize = true;
            this.lblMemberAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblMemberAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberAmount.ForeColor = System.Drawing.Color.White;
            this.lblMemberAmount.Location = new System.Drawing.Point(1098, 904);
            this.lblMemberAmount.Name = "lblMemberAmount";
            this.lblMemberAmount.Size = new System.Drawing.Size(0, 46);
            this.lblMemberAmount.TabIndex = 470;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(638, 904);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(413, 46);
            this.label17.TabIndex = 469;
            this.label17.Text = "MEMBER  AMOUNT :";
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.BackColor = System.Drawing.Color.Transparent;
            this.lblCardType.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblCardType.Location = new System.Drawing.Point(237, 188);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(0, 29);
            this.lblCardType.TabIndex = 471;
            // 
            // btnRemoveWatch
            // 
            this.btnRemoveWatch.BackColor = System.Drawing.Color.DarkRed;
            this.btnRemoveWatch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveWatch.ForeColor = System.Drawing.Color.White;
            this.btnRemoveWatch.Location = new System.Drawing.Point(520, 723);
            this.btnRemoveWatch.Name = "btnRemoveWatch";
            this.btnRemoveWatch.Size = new System.Drawing.Size(112, 57);
            this.btnRemoveWatch.TabIndex = 473;
            this.btnRemoveWatch.Text = "Remove Watch";
            this.btnRemoveWatch.UseVisualStyleBackColor = false;
            this.btnRemoveWatch.Click += new System.EventHandler(this.btnRemoveWatch_Click);
            // 
            // btnAddWatch
            // 
            this.btnAddWatch.BackColor = System.Drawing.Color.DarkRed;
            this.btnAddWatch.Enabled = false;
            this.btnAddWatch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddWatch.ForeColor = System.Drawing.Color.White;
            this.btnAddWatch.Location = new System.Drawing.Point(520, 660);
            this.btnAddWatch.Name = "btnAddWatch";
            this.btnAddWatch.Size = new System.Drawing.Size(112, 57);
            this.btnAddWatch.TabIndex = 472;
            this.btnAddWatch.Text = "Add Watch";
            this.btnAddWatch.UseVisualStyleBackColor = false;
            this.btnAddWatch.Click += new System.EventHandler(this.btnAddWatch_Click);
            // 
            // lblWristBandItem
            // 
            this.lblWristBandItem.AutoSize = true;
            this.lblWristBandItem.BackColor = System.Drawing.Color.Transparent;
            this.lblWristBandItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWristBandItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblWristBandItem.Location = new System.Drawing.Point(183, 437);
            this.lblWristBandItem.Name = "lblWristBandItem";
            this.lblWristBandItem.Size = new System.Drawing.Size(165, 29);
            this.lblWristBandItem.TabIndex = 474;
            this.lblWristBandItem.Text = "Not Selected";
            // 
            // lblWatchItem
            // 
            this.lblWatchItem.AutoSize = true;
            this.lblWatchItem.BackColor = System.Drawing.Color.Transparent;
            this.lblWatchItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWatchItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblWatchItem.Location = new System.Drawing.Point(26, 437);
            this.lblWatchItem.Name = "lblWatchItem";
            this.lblWatchItem.Size = new System.Drawing.Size(162, 29);
            this.lblWatchItem.TabIndex = 475;
            this.lblWatchItem.Text = "Watch Item : ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label14.Location = new System.Drawing.Point(25, 389);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(285, 31);
            this.label14.TabIndex = 476;
            this.label14.Text = "Promotions Amount :";
            // 
            // lblPromotionAmount
            // 
            this.lblPromotionAmount.AutoSize = true;
            this.lblPromotionAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblPromotionAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromotionAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblPromotionAmount.Location = new System.Drawing.Point(316, 392);
            this.lblPromotionAmount.Name = "lblPromotionAmount";
            this.lblPromotionAmount.Size = new System.Drawing.Size(27, 29);
            this.lblPromotionAmount.TabIndex = 477;
            this.lblPromotionAmount.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label15.Location = new System.Drawing.Point(641, 867);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(415, 25);
            this.label15.TabIndex = 478;
            this.label15.Text = "Press F6 To Decrease Promotion Amount ";
            // 
            // frmSlotPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 1024);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblPromotionAmount);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblWatchItem);
            this.Controls.Add(this.lblWristBandItem);
            this.Controls.Add(this.btnRemoveWatch);
            this.Controls.Add(this.btnAddWatch);
            this.Controls.Add(this.lblCardType);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.lblMemberAmount);
            this.Controls.Add(this.dgvPOS);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblTopUpAmount);
            this.Controls.Add(this.panelHide);
            this.Controls.Add(this.txtMobileNumber);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblSlotItemCount);
            this.Controls.Add(this.lblSaleDate);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lnkLabelClose);
            this.Controls.Add(this.txtTransID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.btnCloseOrder);
            this.Controls.Add(this.groupBox2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSlotPOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSlotPOS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSlotPOS_FormClosing);
            this.Load += new System.EventHandler(this.frmSlotPOS_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSlotPOS_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelHide.ResumeLayout(false);
            this.panelHide.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPOS;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnCloseOrder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTransID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel lnkLabelClose;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblSaleDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemainingTickets;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSoldOut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInHand;
        private System.Windows.Forms.Label lblTicketIssueID;
        private System.Windows.Forms.Label lblCategoryID;
        private System.Windows.Forms.Label lblSlotItemCount;
        private System.Windows.Forms.TextBox txtItemCount;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TextBox txtLOT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMobileNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelHide;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTopUpAmount;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label12;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblMemberAmount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.Button btnRemoveWatch;
        private System.Windows.Forms.Button btnAddWatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCatID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsSlotCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTicketIssueID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFID;
        private System.Windows.Forms.Label lblWristBandItem;
        private System.Windows.Forms.Label lblWatchItem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblPromotionAmount;
        private System.Windows.Forms.Label label15;
    }
}