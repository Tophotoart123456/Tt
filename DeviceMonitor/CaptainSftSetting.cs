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
    public partial class CaptainSftSetting : UserControl
    {

        public delegate void GoBack();
        public event GoBack OnGoBack;
        private bool isLocked;

        public CaptainSftSetting()
        {
            InitializeComponent();
            CaptainSetting captain = (CaptainSetting)elementHost1.Child;
            captain.SetDataBind();
        }

        public bool IsLocked
        {
            set
            {
                isLocked = value;
            }
            get
            {
                return isLocked;
            }
        }

        private void pictb_Lock_Click(object sender, EventArgs e)
        {
            if (!IsLocked)
            {
                pictb_Lock.Image = Properties.Resources.icon_lock_on_1x;
                IsLocked = true;
            }
            else
            {
                pictb_Lock.Image = Properties.Resources.icon_lock_off_1x;
                IsLocked = false;
            }
        }

        private void pictb_Return_Click(object sender, EventArgs e)
        {
            OnGoBack?.Invoke();
        }
    }
}
