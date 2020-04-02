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
    public partial class ButtonExt : Button
    {

        public delegate void ButtonClick(object obj);
        public event ButtonClick OnButtonClick;
        private bool isSelect;
        private int index;
        public ButtonExt()
        {
            InitializeComponent();
        }

        public int Index
        {
            set
            {
                index = value;
            }
            get
            {
                return index;
            }
        }

        public string BtnContent
        {
            set
            {
                this.Text = value;
            }
            get
            {
                return this.Text;
            }
        }

        public void UpdateRoomInfo(string content)
        {
            this.Text = content;
        }

        public bool IsSelect
        {
            set
            {
                isSelect = value;
                if (isSelect)
                {
                    this.BackColor = Color.DodgerBlue;
                }
                else
                {
                    this.BackColor = Color.DimGray;
                }

            }
            get
            {
                return isSelect;
            }
        }

        public void ExecuteButtonClick()
        {
            OnButtonClick?.Invoke(this);
            IsSelect = true;
        }

        private void ButtonExt_Click(object sender, EventArgs e)
        {
            OnButtonClick?.Invoke(this);
        }
    }
}
