using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMonitor.Model
{
    class CheckItemModel:PropertyChangedNotify
    {
        private string itemName;
        private bool isChecked;

        public string ItemName
        {
            set
            {
                itemName = value;
                NotifyChanged("ItemName");
            }
            get
            {
                return itemName;
            }
        }

        public bool IsChecked
        {
            set
            {
                isChecked = value;
                NotifyChanged("IsChecked");
            }
            get
            {
                return isChecked;
            }
        }
    }
}
