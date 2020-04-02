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
    public partial class GroupSeting : Form
    {
        public static int numb_global = 3;
        public GroupSeting()
        {
            InitializeComponent();
            InitUi();
        }
        public void InitUi()
        {
            CenterToParent();
        }
        private void LabelClick(object sender,EventArgs e)
        {
            if(sender is Label)
            {
                Label l = sender as Label;
                int tag = Convert.ToInt32(l.Tag);
                switch(tag)
                {
                    case 2:
                        --numb_global;
                        SetGroupNum(numb_global);
                        break;
                    case 3:
                        ++numb_global;
                        SetGroupNum(numb_global);
                        break;
                    default:break;
                }
            }
            else if(sender is PictureBox)
            {
                this.Close();
            }
        }
        public void SetGroupNum(int numb)
        {
            label_Warning.Visible = false;
            if (numb < 1)
            {
                //update on 20200402
                MessageBox.Show("分组数不得小于1组");
                label_Warning.Text = "分组数不得小于1组";
                label_Warning.Visible = true;
                numb_global = 1;
                textBox1.Text = numb_global.ToString();
                return;
            }
            textBox1.Text = numb.ToString();
            numb_global = numb;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int g = 0;
                long lg = Convert.ToInt64(textBox1.Text);
                if (lg > int.MaxValue)
                    g = int.MaxValue;
                else
                    g = (int)lg; //Convert.ToInt32(textBox1.Text);
                    SetGroupNum(g);
                
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int g = Convert.ToInt32(textBox1.Text);
                if (g >= 3)
                    numb_global = g;
            }
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("只能输入数字!");
                label_Warning.Text = "只能输入数字";
                label_Warning.Visible = true;
                e.Handled = true;
            }
        }

    }
}
