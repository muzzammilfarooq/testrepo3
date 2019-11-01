using SlotPOS.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SlotPOS
{
    public partial class frmCardActivation : Form
    {
       
        string stRFID = "";

        public frmCardActivation()
        {
            InitializeComponent();
        }

        public frmCardActivation(string RFID)
        {
            InitializeComponent();
            stRFID = RFID;
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            SlotPOSEntities ctxSlot = new SlotPOSEntities();
            tblRFID obj_rfid = ctxSlot.tblRFIDs.SingleOrDefault(x => x.RFIDCode == stRFID);
            obj_rfid.IsActive = true;
            obj_rfid.Amount = 0;
            obj_rfid.CardActiveDateTime = DateTime.Now;
            if (rdbRegular.Checked)
            {
                obj_rfid.CardType =rdbRegular.Text;
                obj_rfid.IsMaster = false;
                clsGlobalVar.IsMasterCard = false;
            }
            else if (rdbGuest.Checked)
            {
                obj_rfid.CardType = rdbGuest.Text;
                obj_rfid.IsMaster = false;
                clsGlobalVar.IsMasterCard = false;
            }
            else if (rdbEvent.Checked)
            {
                obj_rfid.CardType =rdbEvent.Text;
            } else if(rdbSSMember.Checked)
            {
                obj_rfid.CardType =rdbSSMember.Text;
                obj_rfid.IsMaster = false;
                clsGlobalVar.IsMasterCard = false;
            }
            else if (rdbMaster.Checked)
            {
                obj_rfid.CardType = rdbMaster.Text;
                obj_rfid.IsMaster = true;
                clsGlobalVar.IsMasterCard = true;
            }
            ctxSlot.SaveChanges();
            //tblTransaction tr = new tblTransaction();
            //tr.CardCode = stRFID;
            //tr.MachineCode = "000";
            //tr.Amount = 30;
            //tr.DateTime = DateTime.Now;
            //ctxSlot.tblTransactions.AddObject(tr);

            //========New work date feb/6/2018=================
            tblNewCard NewCard = new tblNewCard();
           
            NewCard.DateTime = DateTime.Now;
            NewCard.RfidCode = stRFID;
            NewCard.Status = "Pending";
            //==================================================
            //=================add master code code Feb-8-2018=============
            if (rdbMaster.Checked)
            {
                NewCard.IsMaster = true;
                NewCard.CardAmount = 0;
                NewCard.FirstBalance = 0;
            }
            else
            {
                //decimal? CardAmount = ctxSlot.tblCounters.Where(t => t.CounterID == clsGlobalVar.CounterID).Select(t => t.NewCardAmount).SingleOrDefault();
                
                NewCard.IsMaster = false;
                NewCard.CardAmount = clsGlobalVar.NewCardAmount;
                NewCard.FirstBalance = clsGlobalVar.BasicCardAmount;
            }
            
            NewCard.SaleDate = clsGlobalVar.SaleDate;
            //============================================================
            ctxSlot.AddTotblNewCards(NewCard);
            ctxSlot.SaveChanges();
          
            clsGlobalVar.IsCardActivated = true;
            clsGlobalVar.IsNewCard = true;
            this.Close();

            }


        private void frmCardActivation_Load(object sender, EventArgs e)
        {
            if (DashBoard.IsRegular == true)
            {
                rdbRegular.Visible = true;
                btnActivate.Enabled = true;
            }

            if (DashBoard.IsGuest == true)
            {
                rdbGuest.Visible = true;
                btnActivate.Enabled = true;
            }

            if (DashBoard.IsSSMember == true)
            {
                rdbSSMember.Visible = true;
                btnActivate.Enabled = true;
            }

            if (DashBoard.IsEvent == true)
            {
                rdbEvent.Visible = true;
                btnActivate.Enabled = true;
            }
            if (DashBoard.IsMaster == true)
            {
                rdbMaster.Visible = true;
                btnActivate.Enabled = true;
            }
            rdbRegular.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsGlobalVar.IsCardActivated = false;
            this.Close();
        }

        private void frmCardActivation_FormClosing(object sender, FormClosingEventArgs e)
        {
            clsGlobalVar.IsCardActivationFormOpen = false;
        }
    }
}
