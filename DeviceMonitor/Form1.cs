using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CaptainSetting captain = (CaptainSetting)elementHost1.Child;
            captain.SetDataBind();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                 DeviceControl.WakeUp("48-4D-7E-BA-A6-D1");
                //DeviceControl.Shutdown("172.16.0.82","Administrator","", false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
     
        }
    }
}
