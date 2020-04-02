using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMonitor.Model
{
    internal class CaptainModel : PropertyChangedNotify
    {

        private string positionName;
        private string typeName;
        private string planePlace;
        private bool isSelect = false;
        private bool isOpenPop = false;

        public string PositionName
        {
            get
            {
                return positionName;
            }
            set
            {
                positionName = value;
                if (positionName != null)
                {
                    NotifyChanged("PositionName");
                }
            }
        }
        public string TypeName
        {
            get
            {
                return typeName;
            }
            set
            {
                typeName = value;
                if (typeName != null)
                {
                    NotifyChanged("TypeName");
                }
            }
        }
        public string PlanePlace
        {
            get
            {
                return planePlace;
            }
            set
            {
                planePlace = value;
                if (planePlace != null)
                {
                    NotifyChanged("PlanePlace");
                }
            }
        }
        public bool IsSelect
        {
            get
            {
                return isSelect;
            }
            set
            {
                isSelect = value;
                NotifyChanged("IsSelect");
            }
        }

        public bool IsOpenPop
        {
            set
            {
                isOpenPop = value;
                NotifyChanged("IsOpenPop");
            }
            get
            {
                return isOpenPop;
            }
        }
    }
}
