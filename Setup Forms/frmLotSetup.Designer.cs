namespace SlotPOS.Setup_Forms
{
    partial class frmLotSetup
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtToTicket = new System.Windows.Forms.TextBox();
            this.txtFromTicket = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLOTName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLOTID = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvLOT = new System.Windows.Forms.DataGridView();
            this.LodID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LotName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLOT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtToTicket);
            this.groupBox1.Controls.Add(this.txtFromTicket);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtLOTName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtLOTID);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 149);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LOT SETUP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(40, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lot ID";
            // 
            // txtToTicket
            // 
            this.txtToTicket.Location = new System.Drawing.Point(245, 95);
            this.txtToTicket.MaxLength = 10;
            this.txtToTicket.Name = "txtToTicket";
            this.txtToTicket.Size = new System.Drawing.Size(103, 20);
            this.txtToTicket.TabIndex = 3;
            this.txtToTicket.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToTicket_KeyPress);
            // 
            // txtFromTicket
            // 
            this.txtFromTicket.Location = new System.Drawing.Point(83, 95);
            this.txtFromTicket.MaxLength = 5;
            this.txtFromTicket.Name = "txtFromTicket";
            this.txtFromTicket.Size = new System.Drawing.Size(103, 20);
            this.txtFromTicket.TabIndex = 2;
            this.txtFromTicket.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFromTicket_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(23, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lot Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(188, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Ticket";
            // 
            // txtLOTName
            // 
            this.txtLOTName.Location = new System.Drawing.Point(83, 62);
            this.txtLOTName.Name = "txtLOTName";
            this.txtLOTName.Size = new System.Drawing.Size(265, 20);
            this.txtLOTName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(14, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "From Ticket";
            // 
            // txtLOTID
            // 
            this.txtLOTID.Location = new System.Drawing.Point(83, 30);
            this.txtLOTID.Name = "txtLOTID";
            this.txtLOTID.ReadOnly = true;
            this.txtLOTID.Size = new System.Drawing.Size(72, 20);
            this.txtLOTID.TabIndex = 4;
            this.txtLOTID.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Maroon;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(399, 167);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Maroon;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(480, 167);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dgvLOT
            // 
            this.dgvLOT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLOT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LodID,
            this.LotName,
            this.FromTicket,
            this.ToTicket});
            this.dgvLOT.Location = new System.Drawing.Point(12, 196);
            this.dgvLOT.Name = "dgvLOT";
            this.dgvLOT.ReadOnly = true;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvLOT.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLOT.Size = new System.Drawing.Size(543, 308);
            this.dgvLOT.TabIndex = 10;
            this.dgvLOT.TabStop = false;
            // 
            // LodID
            // 
            this.LodID.DataPropertyName = "LOTID";
            this.LodID.HeaderText = "Lot ID";
            this.LodID.Name = "LodID";
            this.LodID.ReadOnly = true;
            // 
            // LotName
            // 
            this.LotName.DataPropertyName = "LOTName";
            this.LotName.HeaderText = "Lot Name";
            this.LotName.Name = "LotName";
            this.LotName.ReadOnly = true;
            this.LotName.Width = 200;
            // 
            // FromTicket
            // 
            this.FromTicket.DataPropertyName = "FromTicket";
            this.FromTicket.HeaderText = "From Ticket";
            this.FromTicket.Name = "FromTicket";
            this.FromTicket.ReadOnly = true;
            // 
            // ToTicket
            // 
            this.ToTicket.DataPropertyName = "ToTicket";
            this.ToTicket.HeaderText = "To Ticket";
            this.ToTicket.Name = "ToTicket";
            this.ToTicket.ReadOnly = true;
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // frmLotSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(567, 516);
            this.Controls.Add(this.dgvLOT);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLotSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLotSetup";
            this.Load += new System.EventHandler(this.frmLotSetup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLOT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtToTicket;
        private System.Windows.Forms.TextBox txtFromTicket;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLOTName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLOTID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvLOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn LodID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToTicket;
        private System.Windows.Forms.ErrorProvider ep;
    }
}