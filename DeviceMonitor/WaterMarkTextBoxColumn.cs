using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DeviceMonitor
{
    public partial class WaterMarkTextBoxColumn : DataGridViewColumn
    {
        public WaterMarkTextBoxColumn()
        {
            this.CellTemplate = new WaterMarkTextBoxCell();
            this.HeaderText = "分组名";
        }

        public class WaterMarkTextBoxCell : DataGridViewTextBoxCell
        {
            //private const uint ECM_FIRST = 0x1500;
            //private const uint EM_SETCUEBANNER = ECM_FIRST + 1;

            //[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
            //static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

            //private string watermarkText;
            //public string WatermarkText
            //{
            //    get { return watermarkText; }
            //    set
            //    {
            //        watermarkText = value;
            //        SetWatermark(watermarkText);
            //    }
            //}

            //private void WaterMarkTextBox_TextChanged(object sender, System.EventArgs e)
            //{
            //    SendMessage(this.DataGridView.Handle, EM_SETCUEBANNER, 0, string.Empty);
            //}

            //private void SetWatermark(string watermarkText)
            //{
            //    SendMessage(this.DataGridView.Handle, EM_SETCUEBANNER, 0, watermarkText);
            //}
        }

       

    }
}
