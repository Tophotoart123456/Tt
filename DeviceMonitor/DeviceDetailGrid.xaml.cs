using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeviceMonitor
{
    /// <summary>
    /// DeviceDetailGrid.xaml 的交互逻辑
    /// </summary>
    public partial class DeviceDetailGrid : UserControl
    {
        public DeviceDetailGrid()
        {
            InitializeComponent();
        }

        public void SetBinding(object obj)
        {
            this.DataContext = obj;
        }
    }
}
