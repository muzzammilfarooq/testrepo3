namespace SlotPOS
{
    partial class frmBalChecker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBalChecker));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAVB = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCB = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblTdyConAmnt = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbltDayRchrgAmnt = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblCardType = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblMemberBal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblEntranceType = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(426, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Balance Checker";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(492, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(652, 229);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 39);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(316, 459);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(311, 39);
            this.label4.TabIndex = 2;
            this.label4.Text = "Available Balance :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblAVB
            // 
            this.lblAVB.AutoSize = true;
            this.lblAVB.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAVB.ForeColor = System.Drawing.Color.White;
            this.lblAVB.Location = new System.Drawing.Point(652, 457);
            this.lblAVB.Name = "lblAVB";
            this.lblAVB.Size = new System.Drawing.Size(0, 39);
            this.lblAVB.TabIndex = 2;
            this.lblAVB.Click += new System.EventHandler(this.lblAVB_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(289, 609);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(338, 39);
            this.label6.TabIndex = 2;
            this.label6.Text = "Consumed Balance :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // lblCB
            // 
            this.lblCB.AutoSize = true;
            this.lblCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCB.ForeColor = System.Drawing.Color.White;
            this.lblCB.Location = new System.Drawing.Point(652, 609);
            this.lblCB.Name = "lblCB";
            this.lblCB.Size = new System.Drawing.Size(0, 39);
            this.lblCB.TabIndex = 2;
            this.lblCB.Click += new System.EventHandler(this.lblCB_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(184, 684);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(443, 39);
            this.label3.TabIndex = 2;
            this.label3.Text = "Today Consumed Balance :";
            // 
            // lblTdyConAmnt
            // 
            this.lblTdyConAmnt.AutoSize = true;
            this.lblTdyConAmnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTdyConAmnt.ForeColor = System.Drawing.Color.White;
            this.lblTdyConAmnt.Location = new System.Drawing.Point(652, 685);
            this.lblTdyConAmnt.Name = "lblTdyConAmnt";
            this.lblTdyConAmnt.Size = new System.Drawing.Size(0, 39);
            this.lblTdyConAmnt.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(276, 761);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(351, 39);
            this.label7.TabIndex = 4;
            this.label7.Text = "Today Load Balance :";
            // 
            // lbltDayRchrgAmnt
            // 
            this.lbltDayRchrgAmnt.AutoSize = true;
            this.lbltDayRchrgAmnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltDayRchrgAmnt.ForeColor = System.Drawing.Color.White;
            this.lbltDayRchrgAmnt.Location = new System.Drawing.Point(652, 761);
            this.lbltDayRchrgAmnt.Name = "lbltDayRchrgAmnt";
            this.lbltDayRchrgAmnt.Size = new System.Drawing.Size(0, 39);
            this.lbltDayRchrgAmnt.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1205, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 49);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 66;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardType.ForeColor = System.Drawing.Color.White;
            this.lblCardType.Location = new System.Drawing.Point(652, 305);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(0, 39);
            this.lblCardType.TabIndex = 68;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(430, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(197, 39);
            this.label8.TabIndex = 67;
            this.label8.Text = "Card Type :";
            // 
            // lblMemberBal
            // 
            this.lblMemberBal.AutoSize = true;
            this.lblMemberBal.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberBal.ForeColor = System.Drawing.Color.White;
            this.lblMemberBal.Location = new System.Drawing.Point(653, 533);
            this.lblMemberBal.Name = "lblMemberBal";
            this.lblMemberBal.Size = new System.Drawing.Size(0, 39);
            this.lblMemberBal.TabIndex = 70;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(198, 534);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(429, 39);
            this.label9.TabIndex = 69;
            this.label9.Text = "Member Monthly Balance :";
            // 
            // lblEntranceType
            // 
            this.lblEntranceType.AutoSize = true;
            this.lblEntranceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntranceType.ForeColor = System.Drawing.Color.White;
            this.lblEntranceType.Location = new System.Drawing.Point(652, 381);
            this.lblEntranceType.Name = "lblEntranceType";
            this.lblEntranceType.Size = new System.Drawing.Size(0, 39);
            this.lblEntranceType.TabIndex = 72;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(366, 383);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(261, 39);
            this.label10.TabIndex = 71;
            this.label10.Text = "Entrance Type :";
            // 
            // frmBalChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1280, 1024);
            this.Controls.Add(this.lblEntranceType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblMemberBal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblCardType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbltDayRchrgAmnt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblCB);
            this.Controls.Add(this.lblAVB);
            this.Controls.Add(this.lblTdyConAmnt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBalChecker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmBalChecker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAVB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCB;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTdyConAmnt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbltDayRchrgAmnt;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblMemberBal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblEntranceType;
        private System.Windows.Forms.Label label10;
    }
}