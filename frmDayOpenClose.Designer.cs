namespace SlotPOS
{
    partial class frmDayOpenClose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDayOpenClose));
            this.btnOpening = new System.Windows.Forms.Button();
            this.btnClosing = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSaleDate = new System.Windows.Forms.Label();
            this.lblSystemDate = new System.Windows.Forms.Label();
            this.lblOpeningClosingID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpening
            // 
            this.btnOpening.BackColor = System.Drawing.Color.DarkRed;
            this.btnOpening.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpening.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpening.ForeColor = System.Drawing.Color.White;
            this.btnOpening.Location = new System.Drawing.Point(52, 174);
            this.btnOpening.Name = "btnOpening";
            this.btnOpening.Size = new System.Drawing.Size(153, 70);
            this.btnOpening.TabIndex = 0;
            this.btnOpening.Text = "Day Open";
            this.btnOpening.UseVisualStyleBackColor = false;
            this.btnOpening.Click += new System.EventHandler(this.btnOpening_Click);
            // 
            // btnClosing
            // 
            this.btnClosing.BackColor = System.Drawing.Color.DarkRed;
            this.btnClosing.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClosing.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClosing.ForeColor = System.Drawing.Color.White;
            this.btnClosing.Location = new System.Drawing.Point(52, 277);
            this.btnClosing.Name = "btnClosing";
            this.btnClosing.Size = new System.Drawing.Size(153, 70);
            this.btnClosing.TabIndex = 0;
            this.btnClosing.Text = "Day Close";
            this.btnClosing.UseVisualStyleBackColor = false;
            this.btnClosing.Click += new System.EventHandler(this.btnClosing_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(32, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sale Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "System Date:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(233, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblSaleDate
            // 
            this.lblSaleDate.AutoSize = true;
            this.lblSaleDate.BackColor = System.Drawing.Color.Transparent;
            this.lblSaleDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaleDate.ForeColor = System.Drawing.Color.White;
            this.lblSaleDate.Location = new System.Drawing.Point(121, 72);
            this.lblSaleDate.Name = "lblSaleDate";
            this.lblSaleDate.Size = new System.Drawing.Size(0, 20);
            this.lblSaleDate.TabIndex = 11;
            // 
            // lblSystemDate
            // 
            this.lblSystemDate.AutoSize = true;
            this.lblSystemDate.BackColor = System.Drawing.Color.Transparent;
            this.lblSystemDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemDate.ForeColor = System.Drawing.Color.White;
            this.lblSystemDate.Location = new System.Drawing.Point(121, 110);
            this.lblSystemDate.Name = "lblSystemDate";
            this.lblSystemDate.Size = new System.Drawing.Size(0, 20);
            this.lblSystemDate.TabIndex = 12;
            // 
            // lblOpeningClosingID
            // 
            this.lblOpeningClosingID.AutoSize = true;
            this.lblOpeningClosingID.BackColor = System.Drawing.Color.Transparent;
            this.lblOpeningClosingID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpeningClosingID.ForeColor = System.Drawing.Color.White;
            this.lblOpeningClosingID.Location = new System.Drawing.Point(91, 367);
            this.lblOpeningClosingID.Name = "lblOpeningClosingID";
            this.lblOpeningClosingID.Size = new System.Drawing.Size(0, 20);
            this.lblOpeningClosingID.TabIndex = 13;
            this.lblOpeningClosingID.Visible = false;
            // 
            // frmDayOpenClose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(263, 421);
            this.Controls.Add(this.lblOpeningClosingID);
            this.Controls.Add(this.lblSystemDate);
            this.Controls.Add(this.lblSaleDate);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClosing);
            this.Controls.Add(this.btnOpening);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDayOpenClose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDayOpenClose";
            this.Load += new System.EventHandler(this.frmDayOpenClose_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpening;
        private System.Windows.Forms.Button btnClosing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSaleDate;
        private System.Windows.Forms.Label lblSystemDate;
        private System.Windows.Forms.Label lblOpeningClosingID;
    }
}