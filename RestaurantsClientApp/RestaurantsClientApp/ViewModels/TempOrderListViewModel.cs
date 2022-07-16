using RestaurantsClientApp.Models;
using RestaurantsClientApp.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RestaurantsClientApp.ViewModels
{
    public class TempOrderListViewModel : INotifyPropertyChanged
    {
        public ICommand LoadItemsCommand { protected set; get; }
      
        public ICommand BackCommand { protected set; get; }
        public ICommand SaveTempDetailOrderCommand { protected set; get; }
        public ICommand UpdateDetailOrderCommand { protected set; get; }
      
        public ObservableCollection<TempDetailOrder> TempOrderItems { get; set; }
        public INavigation Navigation { get; set; }

        public TempOrderListViewModel()
        {
            TempOrderItems = new ObservableCollection<TempDetailOrder>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
           
            UpdateDetailOrderCommand= new Command(UpdateTempDetailOrder);

       
            BackCommand = new Command(Back);
        }

        private void UpdateTempDetailOrder(object obj)
        {
            var temp = obj as TempDetailOrder;
            Back();
        }

        private  async void Back()
        {
            await Navigation.PopAsync();
        }
        
        #region faktura räkningar avaibles

        string sumMenuItem = "0";
        public string SumMenuItem
        {
            get { return sumMenuItem; }
            set
            {
                if (sumMenuItem != value)
                {
                    sumMenuItem = value;
                    OnPropertyChanged("SumMenuItem");
                }

            }
        }
        string totalMenuItem = "0";
        public string TotalMenuItem
        {
            get { return totalMenuItem; }
            set
            {
                if (totalMenuItem != value)
                {
                    totalMenuItem = value;
                    OnPropertyChanged("TotalMenuItem");
                }

            }
        }
        string momsMenuItem = "0";
        public string MomsMenuItem
        {
            get { return momsMenuItem; }
            set
            {
                if (momsMenuItem != value)
                {
                    momsMenuItem = value;
                    OnPropertyChanged("MomsMenuItem");
                }

            }
        }


        #endregion



        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    OnPropertyChanged("IsBusy");

                }
            }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged("Title");
                }
            }
        }
        async Task ExecuteLoadItemsCommand()
        {
            try 
            {
                var tempOrderItems = await App.TempDetailOrderDatabase.GetItemsAsync();

                    TempOrderItems.Clear();

            foreach (var temporder in tempOrderItems)
            {
                TempOrderItems.Add(temporder);
            }

            var Tuple = await App.TempDetailOrderDatabase.GetOrderTotalAsync();

                SumMenuItem = "Sum: " + Tuple.Item1.ToString();
                MomsMenuItem = "Moms: " + Tuple.Item2.ToString();
                TotalMenuItem = "Total: " + Tuple.Item3.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            //OnSelectedCammand ( null);
        }

        //TempDetailOrder selectedOrderViewModel=new TempDetailOrder();
        //public TempDetailOrder SelectedOrder
        //{
        //    get  { return selectedOrderViewModel; }
        //    set
        //    {
        //        if (selectedOrderViewModel != value)
        //        {
        //            TempDetailOrder TempOrderViewModel = value;
        //            selectedOrderViewModel = null;
        //            OnPropertyChanged("SelectedOrder");
        //           OnSelectedCammand(TempOrderViewModel);
              
        //        }
        //    }
        //}

        //private async void OnSelectedCammand(TempDetailOrder tempOrderViewModel)
        //{
        //     if (tempOrderViewModel != null) 
        // //  await  Navigation.PushAsync(new OrderPage(tempOrderViewModel));
        //       await Shell.Current.GoToAsync($"{nameof(OrderPage) }?{nameof(TempOrderViewModel.TempOrder)} = {tempOrderViewModel}");
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
