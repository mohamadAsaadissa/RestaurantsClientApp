using RestaurantsClientApp.Models;
using RestaurantsClientApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace RestaurantsClientApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        //public Order order { get; private set; }
        //public DetailOrder detailOrder { get; private set; }
        //public GMenu gMenu { get; private set; }
        //public Meal meal { get; private set; }
     
        
        public BaseViewModel()
        {

            //order = new Order();
            //detailOrder = new DetailOrder();
            //gMenu = new GMenu();
            //meal = new Meal();
          
        }
       

        //#region Properties for class Order

        //public string OrderId
        //{
        //    get => order.OrderId;
        //    set
        //    {
        //        if (order.OrderId != value)
        //        {
        //            order.OrderId = value;
        //            OnPropertyChanged("OrderId");
        //        }
        //    }
        //}

        //public DateTime ODate
        //{
        //    get => order.ODate;
        //    set
        //    {
        //        if (order.ODate != value)
        //        {
        //            order.ODate = value;
        //            OnPropertyChanged("ODate");
        //        }
        //    }
        //}

     
        //#endregion
       
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
       
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

      
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


    }

}
