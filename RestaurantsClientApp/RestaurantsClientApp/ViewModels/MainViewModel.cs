using RestaurantsClientApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;



namespace RestaurantsClientApp.ViewModels
{

    public class MainViewModel : BaseViewModel
    {
       
        public ObservableCollection<Meal> FoodItems { get; }
        public ObservableCollection<GMenu> MenuItems { get; }

        //public Command DateSelectionCommand { get; }   
        //public DateTime dateTime=DateTime.Now;

        //private bool isAddEvent = false;
        //public bool IsAddEvent
        //{
        //    get => isAddEvent;
        //    set => SetProperty(ref isAddEvent, value);
        //}

        


        public MainViewModel()
        {
            Title = "Main";
          
            ////START CLOCK
            //Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);

            //Items = new ObservableCollection<Order>();


            //DetailsCommand = new Command(OnDetailClicked);

            //AddNewItemCommand = new Command(OnAddMyEventClicked);
            //IsBusy = true;
        }

       
       // public void OnAppearing()
       // {
       //     IsBusy = true;

       // }
       // // controll calendar 
       // public Command DateChosen
       // {
       //     get
       //     {
       //         return new Command(async (obj) =>
       //         {
       //             //DateTime temp;
       //             //Validate date
       //             //if (!DateTime.TryParse(Date.Value.ToString("dd/MM/yyyy"), out temp))
       //             //{
       //                  string todaysDate = Date.Value.ToString("dd/MM/yyyy");
                  
       //                 await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.Tdate)}={todaysDate}");
       //             //}
                    
                  
       //         });
       //     }
       // }

        

       
    }
}