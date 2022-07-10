using RestaurantsClientApp.Models;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace RestaurantsClientApp.ViewModels
{
    [QueryProperty(nameof(TempOrder), nameof(TempOrder))]
    public  class TempOrderViewModel : INotifyPropertyChanged
    {
        public TempDetailOrder tempDetailOrder { get; private set; }
        public TempOrderViewModel()
        {
            tempDetailOrder = new TempDetailOrder();
        }

        TempOrderListViewModel lvm;      

        public TempOrderListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }


        private TempDetailOrder tempOrder;
        public TempDetailOrder TempOrder
        {
            get
            {
                return tempOrder;
            }
            set
            {
                tempOrder = value;
              //  LoadtempOrder(value);
            }
        }

        //private void LoadtempOrder(TempDetailOrder value)
        //{
        //    TempDetailOrderId = value.TempDetailOrderId;
        //    TempMealId = value.TempMealId;
        //    TempMealName = value.TempMealName;
        //    TempPath = value.TempPath;
        //    TempPrice = value.TempPrice;
        //    TempQuantity = value.TempQuantity;
        //    TempSumma = value.TempSumma;

        //}

        #region Properties for class TempOrder


        public int TempDetailOrderId
        {
            get => tempDetailOrder.TempDetailOrderId;
            set
            {
                if (tempDetailOrder.TempDetailOrderId != value)
                {
                    tempDetailOrder.TempDetailOrderId = value;
                    OnPropertyChanged("TempDetailOrderId");
                }
            }
        }
        public string TempPath
        {
            get => tempDetailOrder.TempPath;
            set
            {
                if (tempDetailOrder.TempPath != value)
                {
                    tempDetailOrder.TempPath = value;
                    OnPropertyChanged("TempPath");
                }
            }
        }
        public double TempSumma
        {
            get => tempDetailOrder.TempSumma;
            set
            {
                if (tempDetailOrder.TempSumma != value)
                {
                    tempDetailOrder.TempSumma = value;
                    OnPropertyChanged("TempSumma");
                }
            }
        }
        public int TempQuantity
        {
            get => tempDetailOrder.TempQuantity;
            set
            {
                if (tempDetailOrder.TempQuantity != value)
                {
                    tempDetailOrder.TempQuantity = value;
                    OnPropertyChanged("TempQuantity");
                }
            }
        }
        public string TempMealName
        {
            get => tempDetailOrder.TempMealName;
            set
            {
                if (tempDetailOrder.TempMealName != value)
                {
                    tempDetailOrder.TempMealName = value;
                    OnPropertyChanged("TempMealName");
                }
            }
        }
        public string TempMealId
        {
            get => tempDetailOrder.TempMealId;
            set
            {
                if (tempDetailOrder.TempMealId != value)
                {
                    tempDetailOrder.TempMealId = value;
                    OnPropertyChanged("TempMealId");
                }
            }
        }
      
        public int TempPrice
        {
            get => tempDetailOrder.TempPrice;
            set
            {
                if (tempDetailOrder.TempPrice != value)
                {
                    tempDetailOrder.TempPrice = value;
                    OnPropertyChanged("TempPrice");
                }
            }
        }

        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
