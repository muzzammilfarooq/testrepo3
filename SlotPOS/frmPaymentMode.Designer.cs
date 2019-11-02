namespace SlotPOS
{
    partial class frmPaymentMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaymentMode));
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRecAmount = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBalanceAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbtnCash = new System.Windows.Forms.RadioButton();
            this.rbtnCreditCard = new System.Windows.Forms.RadioButton();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblPOSID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPaymentMode = new System.Windows.Forms.Label();
            this.GRBDiscount = new System.Windows.Forms.GroupBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblCompanyCode = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.lblDiscountPer = new System.Windows.Forms.Label();
            this.txtDiscountPer = new System.Windows.Forms.TextBox();
            this.chkDiscount = new System.Windows.Forms.CheckBox();
            this.lblDiscounted = new System.Windows.Forms.Label();
            this.lblNetAm = new System.Windows.Forms.Label();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.lblCardType = new System.Windows.Forms.Label();
            this.txtCardType = new System.Windows.Forms.TextBox();
            this.lblDiscountID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.GRBDiscount.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkRed;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(187, 510);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 38);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRecAmount
            // 
            this.txtRecAmount.Location = new System.Drawing.Point(102, 355);
            this.txtRecAmount.Name = "txtRecAmount";
            this.txtRecAmount.ReadOnly = true;
            this.txtRecAmount.Size = new System.Drawing.Size(100, 20);
            this.txtRecAmount.TabIndex = 2;
            this.txtRecAmount.TextChanged += new System.EventHandler(this.txtRecAmount_TextChanged);
            this.txtRecAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRecAmount_KeyDown);
            this.txtRecAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRecAmount_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(268, 510);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 38);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Received Amount";
            // 
            // txtBalanceAmount
            // 
            this.txtBalanceAmount.Location = new System.Drawing.Point(102, 384);
            this.txtBalanceAmount.Name = "txtBalanceAmount";
            this.txtBalanceAmount.ReadOnly = true;
            this.txtBalanceAmount.Size = new System.Drawing.Size(100, 20);
            this.txtBalanceAmount.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Balance Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(72, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "Total Amount :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(439, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // rbtnCash
            // 
            this.rbtnCash.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnCash.BackColor = System.Drawing.Color.DarkRed;
            this.rbtnCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.rbtnCash.ForeColor = System.Drawing.Color.White;
            this.rbtnCash.Location = new System.Drawing.Point(73, 47);
            this.rbtnCash.Name = "rbtnCash";
            this.rbtnCash.Size = new System.Drawing.Size(146, 143);
            this.rbtnCash.TabIndex = 16;
            this.rbtnCash.TabStop = true;
            this.rbtnCash.Text = "CASH";
            this.rbtnCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnCash.UseVisualStyleBackColor = false;
            this.rbtnCash.CheckedChanged += new System.EventHandler(this.rbtnCash_CheckedChanged);
            // 
            // rbtnCreditCard
            // 
            this.rbtnCreditCard.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnCreditCard.BackColor = System.Drawing.Color.DarkRed;
            this.rbtnCreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.rbtnCreditCard.ForeColor = System.Drawing.Color.White;
            this.rbtnCreditCard.Location = new System.Drawing.Point(276, 47);
            this.rbtnCreditCard.Name = "rbtnCreditCard";
            this.rbtnCreditCard.Size = new System.Drawing.Size(146, 143);
            this.rbtnCreditCard.TabIndex = 17;
            this.rbtnCreditCard.TabStop = true;
            this.rbtnCreditCard.Text = "CREDIT CARD";
            this.rbtnCreditCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnCreditCard.UseVisualStyleBackColor = false;
            this.rbtnCreditCard.CheckedChanged += new System.EventHandler(this.rbtnCreditCard_CheckedChanged);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.White;
            this.lblTotalAmount.Location = new System.Drawing.Point(268, 215);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(0, 31);
            this.lblTotalAmount.TabIndex = 18;
            // 
            // lblPOSID
            // 
            this.lblPOSID.AutoSize = true;
            this.lblPOSID.BackColor = System.Drawing.Color.Transparent;
            this.lblPOSID.ForeColor = System.Drawing.Color.White;
            this.lblPOSID.Location = new System.Drawing.Point(15, 388);
            this.lblPOSID.Name = "lblPOSID";
            this.lblPOSID.Size = new System.Drawing.Size(0, 13);
            this.lblPOSID.TabIndex = 19;
            this.lblPOSID.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 565);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 26);
            this.label4.TabIndex = 20;
            this.label4.Text = "Payment Mode : ";
            // 
            // lblPaymentMode
            // 
            this.lblPaymentMode.AutoSize = true;
            this.lblPaymentMode.BackColor = System.Drawing.Color.Transparent;
            this.lblPaymentMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMode.ForeColor = System.Drawing.Color.White;
            this.lblPaymentMode.Location = new System.Drawing.Point(182, 565);
            this.lblPaymentMode.Name = "lblPaymentMode";
            this.lblPaymentMode.Size = new System.Drawing.Size(18, 26);
            this.lblPaymentMode.TabIndex = 21;
            this.lblPaymentMode.Text = " ";
            // 
            // GRBDiscount
            // 
            this.GRBDiscount.BackColor = System.Drawing.Color.Transparent;
            this.GRBDiscount.Controls.Add(this.lblDiscountID);
            this.GRBDiscount.Controls.Add(this.lblCardType);
            this.GRBDiscount.Controls.Add(this.txtCardType);
            this.GRBDiscount.Controls.Add(this.lblDiscountPer);
            this.GRBDiscount.Controls.Add(this.txtDiscountPer);
            this.GRBDiscount.Controls.Add(this.lblCompanyName);
            this.GRBDiscount.Controls.Add(this.lblCompanyCode);
            this.GRBDiscount.Controls.Add(this.txtCompanyName);
            this.GRBDiscount.Controls.Add(this.txtCompanyCode);
            this.GRBDiscount.Enabled = false;
            this.GRBDiscount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.GRBDiscount.Location = new System.Drawing.Point(242, 355);
            this.GRBDiscount.Name = "GRBDiscount";
            this.GRBDiscount.Size = new System.Drawing.Size(223, 143);
            this.GRBDiscount.TabIndex = 22;
            this.GRBDiscount.TabStop = false;
            this.GRBDiscount.Text = "Discount";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.BackColor = System.Drawing.Color.Transparent;
            this.lblCompanyName.ForeColor = System.Drawing.Color.White;
            this.lblCompanyName.Location = new System.Drawing.Point(24, 48);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(82, 13);
            this.lblCompanyName.TabIndex = 6;
            this.lblCompanyName.Text = "Company Name";
            // 
            // lblCompanyCode
            // 
            this.lblCompanyCode.AutoSize = true;
            this.lblCompanyCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCompanyCode.ForeColor = System.Drawing.Color.White;
            this.lblCompanyCode.Location = new System.Drawing.Point(24, 22);
            this.lblCompanyCode.Name = "lblCompanyCode";
            this.lblCompanyCode.Size = new System.Drawing.Size(79, 13);
            this.lblCompanyCode.TabIndex = 7;
            this.lblCompanyCode.Text = "Company Code";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Enabled = false;
            this.txtCompanyName.Location = new System.Drawing.Point(113, 48);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(100, 20);
            this.txtCompanyName.TabIndex = 4;
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.Location = new System.Drawing.Point(113, 19);
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.Size = new System.Drawing.Size(100, 20);
            this.txtCompanyCode.TabIndex = 5;
            this.txtCompanyCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompanyCode_KeyDown);
            // 
            // lblDiscountPer
            // 
            this.lblDiscountPer.AutoSize = true;
            this.lblDiscountPer.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscountPer.ForeColor = System.Drawing.Color.White;
            this.lblDiscountPer.Location = new System.Drawing.Point(24, 104);
            this.lblDiscountPer.Name = "lblDiscountPer";
            this.lblDiscountPer.Size = new System.Drawing.Size(60, 13);
            this.lblDiscountPer.TabIndex = 9;
            this.lblDiscountPer.Text = "Discount %";
            // 
            // txtDiscountPer
            // 
            this.txtDiscountPer.Enabled = false;
            this.txtDiscountPer.Location = new System.Drawing.Point(113, 104);
            this.txtDiscountPer.Name = "txtDiscountPer";
            this.txtDiscountPer.ReadOnly = true;
            this.txtDiscountPer.Size = new System.Drawing.Size(100, 20);
            this.txtDiscountPer.TabIndex = 8;
            this.txtDiscountPer.TextChanged += new System.EventHandler(this.txtDiscountPer_TextChanged);
            // 
            // chkDiscount
            // 
            this.chkDiscount.AutoSize = true;
            this.chkDiscount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkDiscount.Location = new System.Drawing.Point(102, 410);
            this.chkDiscount.Name = "chkDiscount";
            this.chkDiscount.Size = new System.Drawing.Size(68, 17);
            this.chkDiscount.TabIndex = 23;
            this.chkDiscount.Text = "Discount";
            this.chkDiscount.UseVisualStyleBackColor = true;
            this.chkDiscount.CheckedChanged += new System.EventHandler(this.chkDiscount_CheckedChanged);
            // 
            // lblDiscounted
            // 
            this.lblDiscounted.AutoSize = true;
            this.lblDiscounted.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscounted.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscounted.ForeColor = System.Drawing.Color.White;
            this.lblDiscounted.Location = new System.Drawing.Point(266, 257);
            this.lblDiscounted.Name = "lblDiscounted";
            this.lblDiscounted.Size = new System.Drawing.Size(0, 31);
            this.lblDiscounted.TabIndex = 24;
            // 
            // lblNetAm
            // 
            this.lblNetAm.AutoSize = true;
            this.lblNetAm.BackColor = System.Drawing.Color.Transparent;
            this.lblNetAm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetAm.ForeColor = System.Drawing.Color.White;
            this.lblNetAm.Location = new System.Drawing.Point(90, 305);
            this.lblNetAm.Name = "lblNetAm";
            this.lblNetAm.Size = new System.Drawing.Size(172, 31);
            this.lblNetAm.TabIndex = 25;
            this.lblNetAm.Text = "Net Amount :";
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.AutoSize = true;
            this.lblNetAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblNetAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetAmount.ForeColor = System.Drawing.Color.White;
            this.lblNetAmount.Location = new System.Drawing.Point(270, 305);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Size = new System.Drawing.Size(0, 31);
            this.lblNetAmount.TabIndex = 26;
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.BackColor = System.Drawing.Color.Transparent;
            this.lblCardType.ForeColor = System.Drawing.Color.White;
            this.lblCardType.Location = new System.Drawing.Point(24, 76);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(56, 13);
            this.lblCardType.TabIndex = 11;
            this.lblCardType.Text = "Card Type";
            // 
            // txtCardType
            // 
            this.txtCardType.Enabled = false;
            this.txtCardType.Location = new System.Drawing.Point(113, 76);
            this.txtCardType.Name = "txtCardType";
            this.txtCardType.ReadOnly = true;
            this.txtCardType.Size = new System.Drawing.Size(100, 20);
            this.txtCardType.TabIndex = 10;
            // 
            // lblDiscountID
            // 
            this.lblDiscountID.AutoSize = true;
            this.lblDiscountID.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscountID.ForeColor = System.Drawing.Color.White;
            this.lblDiscountID.Location = new System.Drawing.Point(15, 117);
            this.lblDiscountID.Name = "lblDiscountID";
            this.lblDiscountID.Size = new System.Drawing.Size(0, 13);
            this.lblDiscountID.TabIndex = 12;
            this.lblDiscountID.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(124, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 31);
            this.label5.TabIndex = 27;
            this.label5.Text = "Discount :";
            // 
            // frmPaymentMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(494, 603);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblNetAmount);
            this.Controls.Add(this.lblNetAm);
            this.Controls.Add(this.lblDiscounted);
            this.Controls.Add(this.chkDiscount);
            this.Controls.Add(this.GRBDiscount);
            this.Controls.Add(this.lblPaymentMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPOSID);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.rbtnCreditCard);
            this.Controls.Add(this.rbtnCash);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBalanceAmount);
            this.Controls.Add(this.txtRecAmount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPaymentMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPaymentMode";
            this.Load += new System.EventHandler(this.frmPaymentMode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.GRBDiscount.ResumeLayout(false);
            this.GRBDiscount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtRecAmount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBalanceAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rbtnCash;
        private System.Windows.Forms.RadioButton rbtnCreditCard;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblPOSID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPaymentMode;
        private System.Windows.Forms.GroupBox GRBDiscount;
        private System.Windows.Forms.Label lblDiscountPer;
        private System.Windows.Forms.TextBox txtDiscountPer;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblCompanyCode;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtCompanyCode;
        private System.Windows.Forms.CheckBox chkDiscount;
        private System.Windows.Forms.Label lblDiscounted;
        private System.Windows.Forms.Label lblNetAm;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.TextBox txtCardType;
        private System.Windows.Forms.Label lblDiscountID;
        private System.Windows.Forms.Label label5;
    }
}