using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeviceMonitor.ServiceReference1;
using DeviceMonitor;
namespace OperatorSystem
{
    public partial class authorityControl : UserControl
    {
        public bool isOpenAuthority=false;
        public string _authorityId = "";
        public AuthorityGroup _authorityGroup = null;
        public frmAuthorityGroup1 _frmAuthorityGroup_planeType = new frmAuthorityGroup1();
        public frmAuthorityGroup1 _frmAuthorityGroup_parksOrairLines = new frmAuthorityGroup1();

        //
        string role = "";
        string username = "";
        //

        public authorityControl(Control c)
        {
            InitializeComponent();

            _frmAuthorityGroup_planeType.TopLevel = false;
            _frmAuthorityGroup_planeType.Parent = c;

            _frmAuthorityGroup_parksOrairLines.TopLevel = false;
            _frmAuthorityGroup_parksOrairLines.Parent = c;
        }
        public void SetUserRole(string role1,string username1)
        {
            role = role1;
            username = username1;
        }
        public void GetAllAuthority(string authorityid)
        {
            Form_Main.service1Client.getAllAuthorityData(authorityid);
        }

        public void setAuthority(string authorityId)
        { 
            try
            {
                _authorityId = authorityId;
                if (Form_Main.allAuthorityData.TryGetValue(authorityId, out AuthorityGroup authorityGroup))
                {
                    btnAuthority.Text = authorityGroup.AuthorityName;
                    _authorityGroup = authorityGroup;
                    if(authorityGroup.AirLines.Count<=0)
                    {
                        button3.Text = "Park";
                    }
                    else
                    {
                        button3.Text = "Co.";
                    }
                    if(Form_Main.CurrentAuthorityData.TryGetValue(authorityId,out AuthorityGroup authorityGroup1))
                    {
                        isOpenAuthority = true;
                        btnAuthority.BackColor = Color.FromArgb(0, 0, 200);
                
                        if (authorityGroup1.FlightPlanType.Count!=0)
                        {
                            if(authorityGroup1.FlightPlanType.Count< authorityGroup.FlightPlanType.Count)
                            {
                                btnPlanType.BackColor = Color.FromArgb(200,200,0);
                            }else
                            {
                                btnPlanType.BackColor = Color.FromArgb(0, 0, 200);
                            }
                        }
                        if(authorityGroup1.AirLines.Count!=0)
                        {
                            if (authorityGroup1.AirLines.Count < authorityGroup.AirLines.Count)
                            {
                                button3.BackColor = Color.FromArgb(200, 200, 0);
                            }
                            else
                            {
                                button3.BackColor = Color.FromArgb(0, 0, 200);
                            }
                        }
                        if (authorityGroup1.Parking.Count != 0)
                        {
                            if (authorityGroup1.Parking.Count < authorityGroup.Parking.Count)
                            {
                                button3.BackColor = Color.FromArgb(200, 200, 0);
                            }
                            else
                            {
                                button3.BackColor = Color.FromArgb(0, 0, 200);
                            }
                        }
                    }
                   
                   
                }
            }
            catch (Exception ex)
            {

                
            }
          
        }
        private void btnAuthority_Click(object sender, EventArgs e)
        {
            try
            {
                isOpenAuthority = !isOpenAuthority;
                if (isOpenAuthority)
                {
                    ((Button)sender).BackColor = Color.FromArgb(0, 0, 200);
                    this.button3.BackColor = Color.FromArgb(0, 0, 200);
                    this.btnPlanType.BackColor = Color.FromArgb(0, 0, 200);
                    if (!Form_Main.CurrentAuthorityData.TryGetValue(_authorityId, out AuthorityGroup authorityGroup))
                    {
                        //authorityGroup = new AuthorityGroup();
                        //authorityGroup.AuthorityID = _authorityGroup.AuthorityID;
                        //authorityGroup.AuthorityName = _authorityGroup.AuthorityName;
                        //authorityGroup.AirPortId = _authorityGroup.AirPortId;
                        //authorityGroup.Parking = new Dictionary<string, string[]>();
                        //authorityGroup.FlightPlanType = new Dictionary<string, string>();
                        //authorityGroup.AirLines = new Dictionary<string, string[]>();

                        authorityGroup = _authorityGroup;
                        
                        Form_Main.CurrentAuthorityData.Add(_authorityId, authorityGroup);
                    }
                }
                else
                {
                    ((Button)sender).BackColor = Color.FromArgb(90, 90, 90);
                    this.button3.BackColor = Color.FromArgb(90, 90, 90);
                    this.btnPlanType.BackColor = Color.FromArgb(90, 90, 90);
                    if (Form_Main.CurrentAuthorityData.TryGetValue(_authorityId, out AuthorityGroup authorityGroup))
                    {
                        Form_Main.CurrentAuthorityData.Remove(_authorityId);
                    }
                }
                Form_Main.service.setUserAuthority(Form_Main.CurrentAuthorityData, role , username);
            }
            catch (Exception ex)
            {

                //FlyControl._FlyControl.logger.Error("btnAuthority_Click..."+ex.Message.ToString());
            }
           
        }
      
        private void btnPlanType_Click(object sender, EventArgs e)
        {
            try
            {
                if (isOpenAuthority)
                {
                    _frmAuthorityGroup_planeType.Init(_authorityGroup, 1, (Button)sender);
                    _frmAuthorityGroup_planeType.Show();
                }
            }
            catch (Exception ex)
            {

            }
           
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (isOpenAuthority)
                {
                    if (_authorityGroup.AirLines.Count <= 0)
                    {
                        _frmAuthorityGroup_parksOrairLines.Init(_authorityGroup, 3,(Button)sender);

                    }
                    else
                    {
                        _frmAuthorityGroup_parksOrairLines.Init(_authorityGroup, 2,(Button)sender);
                    }
                    _frmAuthorityGroup_parksOrairLines.Show();
                }

            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
