using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceMonitor
{
    public partial class CommunicationSetting : UserControl
    {
        //定义一个委托 用来通知外部控件即将发生的操作
        public delegate void ExternNotice();
        public event ExternNotice EN;

        public CommunicationSetting()
        {
            InitializeComponent();
        }
        private void label_Return_Click(object sender, EventArgs e)
        {
            EN.Invoke();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
