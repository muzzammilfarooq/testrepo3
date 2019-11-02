namespace SlotPOS
{
    partial class frmCardActivation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCardActivation));
            this.rdbRegular = new System.Windows.Forms.RadioButton();
            this.rdbSSMember = new System.Windows.Forms.RadioButton();
            this.rdbGuest = new System.Windows.Forms.RadioButton();
            this.rdbEvent = new System.Windows.Forms.RadioButton();
            this.btnActivate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbMaster = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rdbRegular
            // 
            resources.ApplyResources(this.rdbRegular, "rdbRegular");
            this.rdbRegular.Checked = true;
            this.rdbRegular.ForeColor = System.Drawing.Color.Black;
            this.rdbRegular.Name = "rdbRegular";
            this.rdbRegular.TabStop = true;
            this.rdbRegular.UseVisualStyleBackColor = true;
            // 
            // rdbSSMember
            // 
            resources.ApplyResources(this.rdbSSMember, "rdbSSMember");
            this.rdbSSMember.ForeColor = System.Drawing.Color.Black;
            this.rdbSSMember.Name = "rdbSSMember";
            this.rdbSSMember.UseVisualStyleBackColor = true;
            // 
            // rdbGuest
            // 
            resources.ApplyResources(this.rdbGuest, "rdbGuest");
            this.rdbGuest.ForeColor = System.Drawing.Color.Black;
            this.rdbGuest.Name = "rdbGuest";
            this.rdbGuest.UseVisualStyleBackColor = true;
            // 
            // rdbEvent
            // 
            resources.ApplyResources(this.rdbEvent, "rdbEvent");
            this.rdbEvent.ForeColor = System.Drawing.Color.Black;
            this.rdbEvent.Name = "rdbEvent";
            this.rdbEvent.UseVisualStyleBackColor = true;
            // 
            // btnActivate
            // 
            resources.ApplyResources(this.btnActivate, "btnActivate");
            this.btnActivate.ForeColor = System.Drawing.Color.Black;
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabStop = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // rdbMaster
            // 
            resources.ApplyResources(this.rdbMaster, "rdbMaster");
            this.rdbMaster.ForeColor = System.Drawing.Color.Black;
            this.rdbMaster.Name = "rdbMaster";
            this.rdbMaster.UseVisualStyleBackColor = true;
            // 
            // frmCardActivation
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rdbMaster);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.rdbEvent);
            this.Controls.Add(this.rdbGuest);
            this.Controls.Add(this.rdbSSMember);
            this.Controls.Add(this.rdbRegular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCardActivation";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCardActivation_FormClosing);
            this.Load += new System.EventHandler(this.frmCardActivation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbRegular;
        private System.Windows.Forms.RadioButton rdbSSMember;
        private System.Windows.Forms.RadioButton rdbGuest;
        private System.Windows.Forms.RadioButton rdbEvent;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbMaster;
    }
}