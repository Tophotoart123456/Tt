using DeviceMonitor.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeviceMonitor;
namespace OperatorSystem
{
    public partial class frmAuthorityGroup1 : Form, IMessageFilter
    {
      
        public bool isFirstLoad { get; set; }
        public frmAuthorityGroup1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            isFirstLoad = true;
            Application.AddMessageFilter(this);
        }
     
        //static frmAuthorityGroup()
        //{
        //    if (_frmAuthorityGroup == null)
        //    {
        //        _frmAuthorityGroup = new frmAuthorityGroup();

        //    }
        //}
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg != 0x0201 || this.Visible == false)
                return false;
            var pt = this.PointToClient(MousePosition);
            this.Visible = this.ClientRectangle.Contains(pt);
            return false;
        }
        private void frmAuthorityGroup_Load(object sender, EventArgs e)
        {

            
        }
 
        AuthorityGroup tempAuthorityGroup ;
        int tempFlag;
        Button tempBtn;
        public void Init(AuthorityGroup authorityGroup,int flag,Button btn)
        {
            try
            {
                tempAuthorityGroup = authorityGroup;
                tempFlag = flag;
                tempBtn = btn;
                this.tableLayoutPanel1.Controls.Clear();
                switch (flag)
                {

                    case 1:
                        foreach (var item in authorityGroup.FlightPlanType)
                        {
                            addControls(item.Key);
                        }

                        break;
                    case 2:
                        foreach (var item in authorityGroup.AirLines)
                        {
                            addControls(item.Key);
                        }
                        break;
                    case 3:
                        foreach (var item in authorityGroup.Parking)
                        {
                            addControls(item.Key);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
            }
            this.Location =this.Parent.PointToClient(MousePosition);
         
        }
        public void addControls(string key)
        {
            try
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = key;
                checkBox.TextAlign = ContentAlignment.MiddleCenter;
                checkBox.ForeColor = Color.White;
                checkBox.BackColor = Color.FromArgb(90, 90, 90);
                checkBox.Margin = new Padding(6, 6, 6, 6);
                checkBox.Dock = DockStyle.Fill;
                checkBox.Tag = key;
                this.tableLayoutPanel1.Controls.Add(checkBox);
            }
            catch(Exception ex)
            {

            }
          
        }
    
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 528 || m.Msg == 129 || m.Msg == 70)
            {
                this.BringToFront();
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
          
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void gbFlightPlanType_Enter(object sender, EventArgs e)
        {

        }

        private void rbtAllSelect_CheckedChanged(object sender, EventArgs e)
        {
            changeCheckBoxIsCheck((RadioButton)sender, true);
        }
        public void changeCheckBoxIsCheck(RadioButton rbt,bool isAllSelect)
        {
            try
            {
                if (rbt.Checked)
                {
                    var controls = rbt.Parent.Parent.Controls;
                    foreach (var control in controls)
                    {
                        if (control is TableLayoutPanel)
                        {
                            foreach (var con in ((TableLayoutPanel)control).Controls)
                            {
                                ((CheckBox)con).Checked = isAllSelect;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
            
        }

        private void rbtUnSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                changeCheckBoxIsCheck((RadioButton)sender, false);
            }
            catch (Exception ex)
            {

               
            }
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            int CurrentCount = 0;
            int authorityCount = 0;
            
            if (Form_Main.CurrentAuthorityData.TryGetValue(tempAuthorityGroup.AuthorityID, out AuthorityGroup authorityGroup))
            {
                switch(tempFlag)
                {
                    case 1:
                        foreach (var Item in tableLayoutPanel1.Controls)
                        {
                            if (Item is CheckBox)
                            {
                                var tempChk = (CheckBox)Item;
                                if (tempChk.Checked)
                                {
                                    if (!authorityGroup.FlightPlanType.TryGetValue(tempChk.Text, out string stringArr))
                                    {
                                        authorityGroup.FlightPlanType.Add(tempChk.Text, tempChk.Text);
                                    }
                                }
                                else
                                {
                                    if (authorityGroup.FlightPlanType.TryGetValue(tempChk.Text, out string stringArr))
                                    {
                                        authorityGroup.FlightPlanType.Remove(tempChk.Text);
                                    }
                                }
                            }
                        }
                        CurrentCount = authorityGroup.FlightPlanType.Count;
                        authorityCount = tempAuthorityGroup.FlightPlanType.Count;
                        break;
                    case 2:
                        foreach (var Item in tableLayoutPanel1.Controls)
                        {
                            if (Item is CheckBox)
                            {
                                var tempChk = (CheckBox)Item;
                                if (tempChk.Checked)
                                {
                                    if (!authorityGroup.AirLines.TryGetValue(tempChk.Text, out string[] stringArr))
                                    {
                                        authorityGroup.AirLines.Add(tempChk.Text, tempAuthorityGroup.AirLines[tempChk.Text]);
                                    }
                                }
                                else
                                {
                                    if (authorityGroup.AirLines.TryGetValue(tempChk.Text, out string[] stringArr))
                                    {
                                        authorityGroup.AirLines.Remove(tempChk.Text);
                                    }
                                }
                            }
                        }
                        CurrentCount = authorityGroup.AirLines.Count;
                        authorityCount = tempAuthorityGroup.AirLines.Count;
                        break;
                    case 3:
                        foreach (var Item in tableLayoutPanel1.Controls)
                        {
                            if (Item is CheckBox)
                            {
                                var tempChk = (CheckBox)Item;
                                if (tempChk.Checked)
                                {
                                    if (!authorityGroup.Parking.TryGetValue(tempChk.Text, out string[] stringArr))
                                    {
                                        authorityGroup.Parking.Add(tempChk.Text, tempAuthorityGroup.Parking[tempChk.Text]);
                                    }
                                }
                                else
                                {
                                    if (authorityGroup.Parking.TryGetValue(tempChk.Text, out string[] stringArr))
                                    {
                                        authorityGroup.Parking.Remove(tempChk.Text);
                                    }
                                }
                            }
                        }
                        CurrentCount = authorityGroup.Parking.Count;
                        authorityCount = tempAuthorityGroup.Parking.Count;
                        break;
                }
                if (CurrentCount == authorityCount)
                {
                    tempBtn.BackColor = Color.FromArgb(0, 0, 200);
                }
                else if (CurrentCount < authorityCount)
                {
                    tempBtn.BackColor = Color.FromArgb(200, 200, 0);
                }
                else if (CurrentCount == 0)
                {
                    tempBtn.BackColor = Color.FromArgb(90, 90, 90);
                }


            }
            //else
            //{
            //    authorityGroup = new AuthorityGroup(); ;
            //    authorityGroup.AuthorityID = tempAuthorityGroup.AuthorityID;
            //    authorityGroup.AuthorityName = tempAuthorityGroup.AuthorityName;
            //    authorityGroup.Parking = new Dictionary<string, string[]>();
            //    authorityGroup.AirLines = new Dictionary<string, string[]>();
            //    authorityGroup.FlightPlanType = new Dictionary<string, string>();
            //    //authorityGroup.AuthorityName = tempAuthorityId;
            //    foreach (var Item in tlpParking.Controls)
            //    {
            //        if (Item is CheckBox)
            //        {
            //            var tempChk = (CheckBox)Item;
            //            if (tempChk.Checked)
            //            {
            //                authorityGroup.Parking.Add(tempChk.Text, tempAuthorityGroup.Parking[tempChk.Text]);
            //            }
            //        }
            //    }
            //    foreach (var Item in tlpAirlines.Controls)
            //    {
            //        if (Item is CheckBox)
            //        {
            //            var tempChk = (CheckBox)Item;
            //            if (tempChk.Checked)
            //            {
            //                authorityGroup.AirLines.Add(tempChk.Text, tempAuthorityGroup.AirLines[tempChk.Text]);
            //            }
            //        }
            //    }
            //    foreach (var Item in tlpFlightPlanType.Controls)
            //    {
            //        if (Item is CheckBox)
            //        {
            //            var tempChk = (CheckBox)Item;
            //            if (tempChk.Checked)
            //            {
            //                authorityGroup.FlightPlanType.Add(tempChk.Text, tempChk.Text);
            //            }
            //        }
            //    }
            //    Global.CurrentAuthorityData.Add(tempAuthorityId, authorityGroup);
            //}
            Form_Main.service1Client.setUserAuthority(Form_Main.CurrentAuthorityData, "Coach"/*FlyControl._FlyControl.role*/ , "计算机0"/*FlyControl._FlyControl.user*/);
            this.Hide();
        }
    }
}
