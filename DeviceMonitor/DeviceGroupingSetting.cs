using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceMonitor
{
    public partial class DeviceGroupingSetting : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        private DataTable dataTable_Grp;
        public delegate void GroupingRoomChanged(string room_no, bool isAdd); //通知主页面分组变化，isAdd=true 表示添加房间，isAdd=false表示删除房间
        public event GroupingRoomChanged OnGroupingRoomChanged;
        private List<ButtonExt> initialRoomList;
        private List<string> roomInfo = new List<string>();


        public DeviceGroupingSetting(List<ButtonExt> initList)
        {
            InitializeComponent();
            this.initialRoomList = initList;
            this.StartPosition = FormStartPosition.CenterParent;
            this.dataGridView1.Columns["No"].DataPropertyName = "No";
            this.dataGridView1.Columns["grouping"].DataPropertyName = "grouping";
            this.dataGridView1.Columns["operate"].DataPropertyName = "operate";
            dataTable_Grp = GetDeviceGroupingInfo();
            this.dataGridView1.DataSource = dataTable_Grp;
        }

        /// <summary>
        /// 通过Windows的API控制窗体的拖动
        /// </summary>
        /// <param name="hwnd"></param>
        public static void MouseDown(IntPtr hwnd)
        {
            ReleaseCapture();
            SendMessage(hwnd, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(42,42,42));
            e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.dataGridView1.Width - 1, this.dataGridView1.Height - 1));
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Close();
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\resource\\icon_closePopUp@2x.png");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\resource\\1x\\icon_closePopUp@2x.png");
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown(this.Handle);
        }

        //将image转换成byte[]数据
        private byte[] ImageToByte(System.Drawing.Image _image)
        {
            MemoryStream ms = new MemoryStream();
            _image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private DataTable GetDeviceGroupingInfo()
        {
            DataTable dt = new DataTable();
            DataColumn dclm_No = new DataColumn("No");
            DataColumn dclm_grouping = new DataColumn("grouping");
            DataColumn dclm_ope = new DataColumn("operate",Type.GetType("System.Byte[]"));
            dt.Columns.Add(dclm_No);
            dt.Columns.Add(dclm_grouping);
            dt.Columns.Add(dclm_ope);
            DataRow row = dt.NewRow();
            row[0] = 1;
            row[1] = "设置组";
            row[2] = ImageToByte(Image.FromFile(Application.StartupPath + "\\resource\\1x\\icon_minusbtn@1x.png"));
            dt.Rows.Add(row);
            roomInfo.Add("设置组");

            int count = initialRoomList.Count;
            if(count > 1)
            {
                for (int i = 1; i < count; i++)
                {
                    DataRow addrow = dt.NewRow();
                    addrow[0] = i + 1;
                    addrow[1] = initialRoomList[i].Text;
                    addrow[2] = ImageToByte(Image.FromFile(Application.StartupPath + "\\resource\\1x\\icon_minusbtn@1x.png"));
                    dt.Rows.Add(addrow);
                    roomInfo.Add(initialRoomList[i].Text);
                }

            }

            DataRow final = dt.NewRow();
            final[0] = dt.Rows.Count + 1;
            final[1] = "请输入分组名";
            final[2] = ImageToByte(Image.FromFile(Application.StartupPath + "\\resource\\1x\\icon_plusbtn@1x.png"));
            dt.Rows.Add(final);
            roomInfo.Add("请输入分组名");
            return dt;
        }

        private void btnConfirm_MouseLeave(object sender, EventArgs e)
        {
            this.btnConfirm.BackColor = Color.DimGray;
        }

        private void btnConfirm_MouseEnter(object sender, EventArgs e)
        {
            this.btnConfirm.BackColor = Color.FromArgb(42, 42, 42);
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            this.btnCancel.BackColor = Color.FromArgb(42, 42, 42);
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            this.btnCancel.BackColor = Color.DimGray;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(dataGridView1[1, dataGridView1.RowCount - 1].Value.ToString()) && dataGridView1[1, dataGridView1.RowCount - 1].Value.ToString() != "请输入分组名")
            {
                string room_Name = dataGridView1[1, dataGridView1.RowCount - 1].Value.ToString();
                if (!roomInfo.Contains(room_Name))
                {
                    roomInfo.Add(room_Name);
                    OnGroupingRoomChanged?.Invoke(room_Name, true);
                }
            }
            this.Dispose();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                string room_Name = dataGridView1[1, e.RowIndex].Value.ToString();
                if (e.RowIndex == dataGridView1.RowCount - 1)
                {
                    if (!string.IsNullOrWhiteSpace(dataGridView1[1, e.RowIndex].Value.ToString()) && dataGridView1[1, e.RowIndex].Value.ToString() != "请输入分组名")
                    {
                        if (!roomInfo.Contains(room_Name))
                        {
                            roomInfo.Add(room_Name);
                            DataRow row = dataTable_Grp.NewRow();
                            row[0] = dataTable_Grp.Rows.Count;
                            row[1] = room_Name;
                            row[2] = ImageToByte(Image.FromFile(Application.StartupPath + "\\resource\\1x\\icon_minusbtn@1x.png"));
                            dataGridView1[1, e.RowIndex].Value = "请输入分组名";
                            dataTable_Grp.Rows.InsertAt(row, dataTable_Grp.Rows.Count - 1);
                            dataTable_Grp.Rows[dataTable_Grp.Rows.Count - 1][0] = dataTable_Grp.Rows.Count;
                            OnGroupingRoomChanged?.Invoke(room_Name, true);
                        }
                        else
                        {
                            MessageBox.Show("该房间号已经存在", "错误提示", MessageBoxButtons.OK);
                            dataGridView1[1, e.RowIndex].Value = "请输入分组名";
                        }
                    }
                    else
                    {
                        MessageBox.Show("请输入分组名", "操作提示");
                    }
                }
                else
                {
                    if (room_Name != "设置组")
                    {
                        dataTable_Grp.Rows.RemoveAt(e.RowIndex);
                        for (int i = e.RowIndex; i < dataTable_Grp.Rows.Count - 1; i++)
                        {
                            dataTable_Grp.Rows[i][0] = i + 1;
                        }
                        dataTable_Grp.Rows[dataTable_Grp.Rows.Count - 1][0] = dataTable_Grp.Rows.Count;
                        roomInfo.Remove(room_Name);
                        OnGroupingRoomChanged?.Invoke(room_Name, false);
                    }
                }
            }
           
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == dataTable_Grp.Rows.Count - 1)
            {
                dataTable_Grp.Rows[e.RowIndex][1] = string.Empty;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataTable_Grp.Rows.Count - 1)
            {
                if (string.IsNullOrWhiteSpace(dataGridView1[1, e.RowIndex].Value.ToString()))
                {
                    dataTable_Grp.Rows[e.RowIndex][1] = "请输入分组名";
                }
            }
        }
    }
}
