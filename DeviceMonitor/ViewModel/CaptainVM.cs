using DeviceMonitor.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeviceMonitor.ViewModel
{
   internal class CaptainVM:PropertyChangedNotify
    {
        public CaptainVM()
        {
            InitBindSource();
        }

        public void InitBindSource()

        { 
            CaptainModel model = new CaptainModel() { PositionName = "东塔", TypeName = "类型", PlanePlace = "机位", IsSelect = false };
            CaptainModel model2 = new CaptainModel() { PositionName = "西塔", TypeName = "类型", PlanePlace = "机位", IsSelect = true };
            CaptainModel model3 = new CaptainModel() { PositionName = "东地", TypeName = "类型", PlanePlace = "航司", IsSelect = false };
            CaptainModel model4 = new CaptainModel() { PositionName = "西塔", TypeName = "类型", PlanePlace = "机位", IsSelect = true };
            Capture.Add(model);
            Capture.Add(model2);
            Capture.Add(model3);
            Capture.Add(model4);
        }

        private void InitTowerData()
        {
            CheckItems.Clear();
            CheckItemModel mdl = new CheckItemModel() { ItemName = "进港", IsChecked = false };
            CheckItemModel mdl2 = new CheckItemModel() { ItemName = "离港", IsChecked = false };
            CheckItemModel mdl3 = new CheckItemModel() { ItemName = "训练", IsChecked = false };
            CheckItemModel mdl4 = new CheckItemModel() { ItemName = "飞跃", IsChecked = false };
            CheckItems.Add(mdl);
            CheckItems.Add(mdl2);
            CheckItems.Add(mdl3);
            CheckItems.Add(mdl4);
        }

        private void InitPositionData()
        {
            CheckItems.Clear();
            CheckItemModel mdl = new CheckItemModel() { ItemName = "P01", IsChecked = false };
            CheckItemModel mdl2 = new CheckItemModel() { ItemName = "P02", IsChecked = false };
            CheckItemModel mdl3 = new CheckItemModel() { ItemName = "P03", IsChecked = false };
            CheckItemModel mdl4 = new CheckItemModel() { ItemName = "P04", IsChecked = false };
            CheckItems.Add(mdl);
            CheckItems.Add(mdl2);
            CheckItems.Add(mdl3);
            CheckItems.Add(mdl4);

        }

        private ObservableCollection<CheckItemModel> checkItems = new ObservableCollection<CheckItemModel>();

        public ObservableCollection<CheckItemModel> CheckItems
        {
            get
            {
                return checkItems;
            }
            set
            {
                if (checkItems != value)
                {
                    checkItems = value;
                    NotifyChanged("CheckItems");
                }
            }
        }

        private ICommand mouseLeftClickItem;

        public ICommand MouseLeftClickItem
        {
            get
            {
                return mouseLeftClickItem ?? (mouseLeftClickItem = new RelayCommand(OnLableItemClick));
            }
        }

        private void OnLableItemClick(object obj)
        {
            CaptainModel mdl= (CaptainModel) obj;
            if (mdl.IsOpenPop)
            {
                mdl.IsOpenPop = false;
            }
            else
            {
                InitTowerData();
                mdl.IsOpenPop = true;
            }
        }

        private ICommand positionClick;

        public ICommand PositionClick
        {
            get
            {
                return positionClick ?? (positionClick = new RelayCommand(OnPositionClick));
            }
        }

        private void OnPositionClick(object obj)
        {
            CaptainModel mdl = (CaptainModel)obj;
            if (mdl.IsOpenPop)
            {
                mdl.IsOpenPop = false;
            }
            else
            {
                InitPositionData();
                mdl.IsOpenPop = true;
            }
        }


        private ObservableCollection<CaptainModel> capture = new ObservableCollection<CaptainModel>();

        public ObservableCollection<CaptainModel> Capture
        {
            get
            {
                return this.capture;
            }
            set
            {
                if (this.capture != value)
                {
                    this.capture = value;
                    NotifyChanged("Capture");
                }
            }
        }
    }
}
