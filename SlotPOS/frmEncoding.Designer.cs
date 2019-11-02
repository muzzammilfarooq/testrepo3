namespace SlotPOS
{
    partial class frmEncoding
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
            this.label1 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.rbtnAladinEntrance = new System.Windows.Forms.RadioButton();
            this.rbtnClubEntrance = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnEmpty = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbtnRC = new System.Windows.Forms.RadioButton();
            this.rbtnRWB = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(-2, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 25);
            this.label1.TabIndex = 1;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // rbtnAladinEntrance
            // 
            this.rbtnAladinEntrance.AutoSize = true;
            this.rbtnAladinEntrance.Location = new System.Drawing.Point(6, 9);
            this.rbtnAladinEntrance.Name = "rbtnAladinEntrance";
            this.rbtnAladinEntrance.Size = new System.Drawing.Size(100, 17);
            this.rbtnAladinEntrance.TabIndex = 2;
            this.rbtnAladinEntrance.Text = "Aladin Entrance";
            this.rbtnAladinEntrance.UseVisualStyleBackColor = true;
            this.rbtnAladinEntrance.CheckedChanged += new System.EventHandler(this.rbtnAladinEntrance_CheckedChanged);
            // 
            // rbtnClubEntrance
            // 
            this.rbtnClubEntrance.AutoSize = true;
            this.rbtnClubEntrance.Location = new System.Drawing.Point(112, 9);
            this.rbtnClubEntrance.Name = "rbtnClubEntrance";
            this.rbtnClubEntrance.Size = new System.Drawing.Size(92, 17);
            this.rbtnClubEntrance.TabIndex = 3;
            this.rbtnClubEntrance.Text = "Club Entrance";
            this.rbtnClubEntrance.UseVisualStyleBackColor = true;
            this.rbtnClubEntrance.CheckedChanged += new System.EventHandler(this.rbtnClubEntrance_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnEmpty);
            this.groupBox1.Controls.Add(this.rbtnClubEntrance);
            this.groupBox1.Controls.Add(this.rbtnAladinEntrance);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(62, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 34);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // rbtnEmpty
            // 
            this.rbtnEmpty.AutoSize = true;
            this.rbtnEmpty.Checked = true;
            this.rbtnEmpty.Location = new System.Drawing.Point(6, 39);
            this.rbtnEmpty.Name = "rbtnEmpty";
            this.rbtnEmpty.Size = new System.Drawing.Size(14, 13);
            this.rbtnEmpty.TabIndex = 5;
            this.rbtnEmpty.TabStop = true;
            this.rbtnEmpty.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.rbtnRC);
            this.groupBox2.Controls.Add(this.rbtnRWB);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(62, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 34);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 39);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbtnRC
            // 
            this.rbtnRC.AutoSize = true;
            this.rbtnRC.Location = new System.Drawing.Point(112, 9);
            this.rbtnRC.Name = "rbtnRC";
            this.rbtnRC.Size = new System.Drawing.Size(75, 17);
            this.rbtnRC.TabIndex = 3;
            this.rbtnRC.Text = "RFID Card";
            this.rbtnRC.UseVisualStyleBackColor = true;
            // 
            // rbtnRWB
            // 
            this.rbtnRWB.AutoSize = true;
            this.rbtnRWB.Location = new System.Drawing.Point(6, 9);
            this.rbtnRWB.Name = "rbtnRWB";
            this.rbtnRWB.Size = new System.Drawing.Size(104, 17);
            this.rbtnRWB.TabIndex = 2;
            this.rbtnRWB.Text = "RFID Wrist band";
            this.rbtnRWB.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(59, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select Card Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(61, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Select Card Entrance";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(95, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Card Encoding";
            // 
            // frmEncoding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(336, 385);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEncoding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEncoding";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEncoding_FormClosing);
            this.Load += new System.EventHandler(this.frmEncoding_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.RadioButton rbtnAladinEntrance;
        private System.Windows.Forms.RadioButton rbtnClubEntrance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnEmpty;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rbtnRC;
        private System.Windows.Forms.RadioButton rbtnRWB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}