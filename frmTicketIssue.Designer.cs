namespace SlotPOS
{
    partial class frmTicketIssue
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
            this.dgvIssue = new System.Windows.Forms.DataGridView();
            this.LodID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LotName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFromTicket = new System.Windows.Forms.Label();
            this.lblToTicket = new System.Windows.Forms.Label();
            this.cmbItemCategory = new System.Windows.Forms.ComboBox();
            this.txtTotalTicket = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbLOT = new System.Windows.Forms.ComboBox();
            this.dtIssueDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTicketStock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtToTicket = new System.Windows.Forms.TextBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.txtFromTicket = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTicketIssueID = new System.Windows.Forms.TextBox();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssue)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIssue
            // 
            this.dgvIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIssue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LodID,
            this.LotName,
            this.colCategory,
            this.FromTicket,
            this.ToTicket,
            this.colBalance});
            this.dgvIssue.Location = new System.Drawing.Point(12, 265);
            this.dgvIssue.Name = "dgvIssue";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvIssue.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIssue.Size = new System.Drawing.Size(590, 334);
            this.dgvIssue.TabIndex = 14;
            this.dgvIssue.TabStop = false;
            // 
            // LodID
            // 
            this.LodID.DataPropertyName = "TicketIssueID";
            this.LodID.HeaderText = "Issue ID";
            this.LodID.Name = "LodID";
            this.LodID.Width = 75;
            // 
            // LotName
            // 
            this.LotName.DataPropertyName = "LOTName";
            this.LotName.HeaderText = "Lot Name";
            this.LotName.Name = "LotName";
            // 
            // colCategory
            // 
            this.colCategory.DataPropertyName = "ItemCategory";
            this.colCategory.HeaderText = "Category";
            this.colCategory.Name = "colCategory";
            // 
            // FromTicket
            // 
            this.FromTicket.DataPropertyName = "FromTicket";
            this.FromTicket.HeaderText = "From Ticket";
            this.FromTicket.Name = "FromTicket";
            this.FromTicket.Width = 90;
            // 
            // ToTicket
            // 
            this.ToTicket.DataPropertyName = "ToTicket";
            this.ToTicket.HeaderText = "To Ticket";
            this.ToTicket.Name = "ToTicket";
            // 
            // colBalance
            // 
            this.colBalance.DataPropertyName = "BalanceTicket";
            this.colBalance.HeaderText = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.Width = 80;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Maroon;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(527, 236);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Maroon;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(446, 236);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblFromTicket);
            this.groupBox1.Controls.Add(this.lblToTicket);
            this.groupBox1.Controls.Add(this.cmbItemCategory);
            this.groupBox1.Controls.Add(this.txtTotalTicket);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbLOT);
            this.groupBox1.Controls.Add(this.dtIssueDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTicketStock);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtToTicket);
            this.groupBox1.Controls.Add(this.txtBalance);
            this.groupBox1.Controls.Add(this.txtFromTicket);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTicketIssueID);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 222);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TICKET ISSUE";
            // 
            // lblFromTicket
            // 
            this.lblFromTicket.AutoSize = true;
            this.lblFromTicket.ForeColor = System.Drawing.Color.White;
            this.lblFromTicket.Location = new System.Drawing.Point(264, 159);
            this.lblFromTicket.Name = "lblFromTicket";
            this.lblFromTicket.Size = new System.Drawing.Size(0, 13);
            this.lblFromTicket.TabIndex = 12;
            // 
            // lblToTicket
            // 
            this.lblToTicket.AutoSize = true;
            this.lblToTicket.ForeColor = System.Drawing.Color.White;
            this.lblToTicket.Location = new System.Drawing.Point(292, 196);
            this.lblToTicket.Name = "lblToTicket";
            this.lblToTicket.Size = new System.Drawing.Size(0, 13);
            this.lblToTicket.TabIndex = 11;
            // 
            // cmbItemCategory
            // 
            this.cmbItemCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItemCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemCategory.FormattingEnabled = true;
            this.cmbItemCategory.Location = new System.Drawing.Point(108, 132);
            this.cmbItemCategory.Name = "cmbItemCategory";
            this.cmbItemCategory.Size = new System.Drawing.Size(200, 21);
            this.cmbItemCategory.TabIndex = 3;
            this.cmbItemCategory.SelectedIndexChanged += new System.EventHandler(this.cmbItemCategory_SelectedIndexChanged);
            // 
            // txtTotalTicket
            // 
            this.txtTotalTicket.Location = new System.Drawing.Point(456, 130);
            this.txtTotalTicket.Name = "txtTotalTicket";
            this.txtTotalTicket.ReadOnly = true;
            this.txtTotalTicket.Size = new System.Drawing.Size(103, 20);
            this.txtTotalTicket.TabIndex = 9;
            this.txtTotalTicket.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(27, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Slot Category";
            // 
            // cmbLOT
            // 
            this.cmbLOT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLOT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLOT.FormattingEnabled = true;
            this.cmbLOT.Location = new System.Drawing.Point(108, 97);
            this.cmbLOT.Name = "cmbLOT";
            this.cmbLOT.Size = new System.Drawing.Size(200, 21);
            this.cmbLOT.TabIndex = 2;
            this.cmbLOT.SelectedIndexChanged += new System.EventHandler(this.cmbLOT_SelectedIndexChanged);
            // 
            // dtIssueDate
            // 
            this.dtIssueDate.Location = new System.Drawing.Point(108, 63);
            this.dtIssueDate.Name = "dtIssueDate";
            this.dtIssueDate.Size = new System.Drawing.Size(200, 20);
            this.dtIssueDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ticket Issue ID";
            // 
            // txtTicketStock
            // 
            this.txtTicketStock.Location = new System.Drawing.Point(108, 173);
            this.txtTicketStock.Name = "txtTicketStock";
            this.txtTicketStock.ReadOnly = true;
            this.txtTicketStock.Size = new System.Drawing.Size(103, 20);
            this.txtTicketStock.TabIndex = 3;
            this.txtTicketStock.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(39, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Select Lot";
            // 
            // txtToTicket
            // 
            this.txtToTicket.Location = new System.Drawing.Point(456, 56);
            this.txtToTicket.Name = "txtToTicket";
            this.txtToTicket.Size = new System.Drawing.Size(103, 20);
            this.txtToTicket.TabIndex = 5;
            this.txtToTicket.TextChanged += new System.EventHandler(this.txtToTicket_TextChanged);
            this.txtToTicket.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToTicket_KeyPress);
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(456, 90);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(103, 20);
            this.txtBalance.TabIndex = 3;
            this.txtBalance.TabStop = false;
            // 
            // txtFromTicket
            // 
            this.txtFromTicket.Location = new System.Drawing.Point(456, 23);
            this.txtFromTicket.Name = "txtFromTicket";
            this.txtFromTicket.Size = new System.Drawing.Size(103, 20);
            this.txtFromTicket.TabIndex = 4;
            this.txtFromTicket.TextChanged += new System.EventHandler(this.txtFromTicket_TextChanged);
            this.txtFromTicket.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFromTicket_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(39, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Issue Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(380, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "To Ticket No";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(371, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Ticket Balance";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(350, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Total No Of Tickets";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(36, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ticket in Lot";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(370, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "From Ticket No";
            // 
            // txtTicketIssueID
            // 
            this.txtTicketIssueID.Location = new System.Drawing.Point(108, 27);
            this.txtTicketIssueID.Name = "txtTicketIssueID";
            this.txtTicketIssueID.ReadOnly = true;
            this.txtTicketIssueID.Size = new System.Drawing.Size(72, 20);
            this.txtTicketIssueID.TabIndex = 4;
            this.txtTicketIssueID.TabStop = false;
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // frmTicketIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(609, 611);
            this.Controls.Add(this.dgvIssue);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTicketIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTicketIssue";
            this.Load += new System.EventHandler(this.frmTicketIssue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssue)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIssue;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTicketStock;
        private System.Windows.Forms.TextBox txtFromTicket;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTicketIssueID;
        private System.Windows.Forms.DateTimePicker dtIssueDate;
        private System.Windows.Forms.ComboBox cmbLOT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtToTicket;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotalTicket;
        private System.Windows.Forms.ComboBox cmbItemCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn LodID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;
        private System.Windows.Forms.Label lblToTicket;
        private System.Windows.Forms.Label lblFromTicket;
    }
}