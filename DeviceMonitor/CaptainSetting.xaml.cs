using DeviceMonitor.Model;
using DeviceMonitor.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class CaptainSetting : UserControl
    {
        public CaptainSetting()
        {
            InitializeComponent();
            
        }

        public void SetDataBind()
        {
            // this.itemsControl.ItemsSource = Capture;
            CaptainVM vm = new CaptainVM();
           // ObservableCollection<CaptainModel> capture = vm.InitBindSource();
           // vm.Capture = capture;
            this.DataContext = vm;
        }


        private BitmapImage BitmapToBitmapImage(System.Drawing.Bitmap bitmap)
        {
            BitmapImage bitmapImage = new BitmapImage();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                bitmap.Save(ms, bitmap.RawFormat);
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
            }
            return bitmapImage;
        }


        /// <summary>
        /// 移除截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReMoveCaptrue_Click(object sender, MouseButtonEventArgs e)
        {
           // Capture.Remove((BitmapImage)((Image)sender).DataContext);
        }

        private void TextBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CaptainModel model = ((Label)sender).DataContext as CaptainModel;

            if (model != null)
            {
                if (model.IsSelect == false)
                {

                    model.IsSelect = true;
                }
                else
                {
                    model.IsSelect = false;
                }

            }
        }
      

      
    }
}
