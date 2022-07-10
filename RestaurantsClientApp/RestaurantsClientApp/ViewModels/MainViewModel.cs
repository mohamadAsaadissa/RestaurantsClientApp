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

        //// show Relativelayout
        //private string labeltextDate;
        //public string LabeltextDate
        //{
        //    get => labeltextDate;
        //    set => SetProperty(ref labeltextDate, value);
        //}

        //// show Relativelayout
        //private string labeltextClock;
        //public string LabeltextClock
        //{
        //    get => labeltextClock;
        //    set => SetProperty(ref labeltextClock, value);
        //}

        //// stacklayout no event
        //private bool isNoEvent=true;

        //public bool IsNoEvent
        //{
        //    get => isNoEvent;
        //    set => SetProperty(ref isNoEvent, value);
        //}
        //private DateTime? _date;
        //public DateTime? Date
        //{
        //    get
        //    {
        //        return _date;
        //    }
        //    set
        //    {
        //        _date = value;
        //        OnPropertyChanged(nameof(Date));
        //    }
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

        

       // async void OnAddMyEventClicked()
       // {
       //     try
       //     {
       //         var myevent = new MyEventClass { StartTime = StartTime, EndTime = EndTime,
       //             MyLocation = MyLocation, MyEvent = MyEvent, Status = Status.Green, Description = Description, Path=Path, TodaysDate= dateTime
       //         .Date.ToString("dd/MM/yyyy") };

       //         var items = await DataStore.AddEventItemAsync(myevent);
       //     }
       //     catch (Exception)
       //     {
       //         Console.WriteLine("Failed to load animal.");
       //     }
       // }
          
       //// clock function
       // private bool OnTimerTick()
       // {
       //     LabeltextClock = DateTime.Now.ToString("T");
       //     return true;
       // }

      
       // private async void OnDetailClicked(object obj)
       // {
       //     // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
       //     await Shell.Current.GoToAsync($"//{nameof(ItemDetailPage)}");
       // }
       
       // public ICommand DetailsCommand { get; }

       // public ICommand AddNewItemCommand { get; }

       
    }
}