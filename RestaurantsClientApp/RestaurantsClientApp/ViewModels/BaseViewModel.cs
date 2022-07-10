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
        //#region Properties for class Menu
       // MenuViewModel lvm;
        //public MenuViewModel ListViewModel
        //{
        //    get { return lvm; }
        //    set
        //    {
        //        if (lvm != value)
        //        {
        //            lvm = value;
        //            OnPropertyChanged("ListViewModel");
        //        }
        //    }
        //}
        //public string GMenuId
        //{
        //    get => gMenu.GMenuId;
        //    set
        //    {
        //        if (gMenu.GMenuId != value)
        //        {
        //            gMenu.GMenuId = value;
        //            OnPropertyChanged("GMenuId");
        //        }
        //    }
        //}
        //public string Path
        //{
        //    get => gMenu.Path;
        //    set
        //    {
        //        if (gMenu.Path != value)
        //        {
        //            gMenu.Path = value;
        //            OnPropertyChanged("Path");
        //        }
        //    }
        //}
       
        //public string MenuName
        //{
        //    get => gMenu.MenuName;
        //    set
        //    {
        //        if (gMenu.MenuName != value)
        //        {
        //            gMenu.MenuName = value;
        //            OnPropertyChanged("MenuName");
        //        }
        //    }
        //}
        //public string Description
        //{
        //    get => gMenu.Description;
        //    set
        //    {
        //        if (gMenu.Description != value)
        //        {
        //            gMenu.Description = value;
        //            OnPropertyChanged("Description");
        //        }
        //    }
        //}
        //public bool IsVisible
        //{
        //    get => gMenu.IsVisible;
        //    set
        //    {
        //        if (gMenu.IsVisible != value)
        //        {
        //            gMenu.IsVisible = value;
        //            OnPropertyChanged("IsVisible");
        //        }
        //    }
        //}

        //#endregion

        //#region Properties for class Meal
        
        //public string MealId
        //{
        //    get => meal.MealId;
        //    set
        //    {
        //        if (meal.MealId != value)
        //        {
        //            meal.MealId = value;
        //            OnPropertyChanged("GMenuId");
        //        }
        //    }
        //}
        //public string iPath
        //{
        //    get => meal.Path;
        //    set
        //    {
        //        if (meal.Path != value)
        //        {
        //            meal.Path = value;
        //            OnPropertyChanged("iPath");
        //        }
        //    }
        //}

        //public string MealName
        //{
        //    get => meal.MealName;
        //    set
        //    {
        //        if (meal.MealName != value)
        //        {
        //            meal.MealName = value;
        //            OnPropertyChanged("MealName");
        //        }
        //    }
        //}
        //public string iDescription
        //{
        //    get => meal.Description;
        //    set
        //    {
        //        if (meal.Description != value)
        //        {
        //            meal.Description = value;
        //            OnPropertyChanged("iDescription");
        //        }
        //    }
        //}
        //public DateTime SDate
        //{
        //    get => meal.SDate;
        //    set
        //    {
        //        if (meal.SDate != value)
        //        {
        //            meal.SDate = value;
        //            OnPropertyChanged("SDate");
        //        }
        //    }
        //}
        //public MealStatus MealStatus
        //{
        //    get => meal.MealStatus;
        //    set
        //    {
        //        if (meal.MealStatus != value)
        //        {
        //            meal.MealStatus = value;
        //            OnPropertyChanged("MealStatus");
        //        }
        //    }
        //}
        //public int CostPris
        //{
        //    get => meal.CostPris;
        //    set
        //    {
        //        if (meal.CostPris != value)
        //        {
        //            meal.CostPris = value;
        //            OnPropertyChanged("CostPris");
        //        }
        //    }
        //}
        //public int SalePris
        //{
        //    get => meal.SalePris;
        //    set
        //    {
        //        if (meal.SalePris != value)
        //        {
        //            meal.SalePris = value;
        //            OnPropertyChanged("SalePris");
        //        }
        //    }
        //}
        //public bool iIsVisible
        //{
        //    get => meal.IsVisible;
        //    set
        //    {
        //        if (meal.IsVisible != value)
        //        {
        //            meal.IsVisible = value;
        //            OnPropertyChanged("iIsVisible");
        //        }
        //    }
        //}

        //#endregion
        //#region Properties for class DetailOrder


        //public int DisCount
        //{
        //    get => detailOrder.DisCount;
        //    set
        //    {
        //        if (detailOrder.DisCount != value)
        //        {
        //            detailOrder.DisCount = value;
        //            OnPropertyChanged("DisCount");
        //        }
        //    }
        //}
        //public int DetailOrderId
        //{
        //    get => detailOrder.DetailOrderId;
        //    set
        //    {
        //        if (detailOrder.DetailOrderId != value)
        //        {
        //            detailOrder.DetailOrderId = value;
        //            OnPropertyChanged("DetailOrderId");
        //        }
        //    }
        //}
        //public int Quantity
        //{
        //    get => detailOrder.Quantity;
        //    set
        //    {
        //        if (detailOrder.Quantity != value)
        //        {
        //            detailOrder.Quantity = value;
        //            OnPropertyChanged("Quantity");
        //        }
        //    }
        //}


        //public string FoodId
        //{
        //    get => detailOrder.FoodId;
        //    set
        //    {
        //        if (detailOrder.FoodId != value)
        //        {
        //            detailOrder.FoodId = value;
        //            OnPropertyChanged("FoodId");
        //        }
        //    }
        //}

        //#endregion

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

        //public PaymentMethod PaymentMethod
        //{
        //    get => order.PaymentMethod;
        //    set
        //    {
        //        if (order.PaymentMethod != value)
        //        {
        //            order.PaymentMethod = value;
        //            OnPropertyChanged("PaymentMethod");
        //        }
        //    }
        //}
        //public string ClientId
        //{
        //    get => order.ClientId;
        //    set
        //    {
        //        if (order.ClientId != value)
        //        {
        //            order.ClientId = value;
        //            OnPropertyChanged("ClientId");
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
