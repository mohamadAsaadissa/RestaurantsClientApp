using RestaurantsClientApp.Models;
using RestaurantsClientApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantsClientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersListPage : ContentPage
    {
        TempOrderListViewModel _OrderViewModel;
        public OrdersListPage()
        {
            InitializeComponent();
            _OrderViewModel = new TempOrderListViewModel();
            this.BindingContext = _OrderViewModel;

        }
        protected  override void OnAppearing()
        {
            base.OnAppearing();
           
            _OrderViewModel.OnAppearing();
        }

      
        private async void BtnDeleteTempOrder_Clicked(object sender, EventArgs e)
        {
            TempDetailOrder tempOrder = new TempDetailOrder(); ;

            try

            {
                bool isOk = await DisplayAlert("Attention", "Vill du ta bort denna måltid fråm räkningen?", "OK", "Cancel");

                if (isOk)
                {
                    var temp = (Button)sender;

                    tempOrder = await App.TempDetailOrderDatabase.GetItemAsync(temp.ClassId);

                    if (tempOrder != null)
                    {
                        await App.TempDetailOrderDatabase.DeleteItemAsync(tempOrder);
                    }
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void ToolbarItemSaveTempDetailOrder_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool isOk = await DisplayAlert("Attention", "Vill DU SKICKA DIN BESTÄLLNIG?", "OK", "Cancel");


                if (isOk)
                {

                    var TempOrderItems= await App.tempDetailOrderdatabase.GetItemsAsync();

                    var Order = new Order();

                    await App.OrderDatabase.SaveItemAsync(Order);


                    foreach (var tempDetail in TempOrderItems)
                    {
                        var detailOrder = new DetailOrder();

                        detailOrder.OrderId = Order.OrderId;
                        detailOrder.Quantity = tempDetail.TempQuantity;
                        detailOrder.MealId = tempDetail.TempMealId;
                       
                        await App.DetailOrderdatabase.SaveItemAsync(detailOrder);

                    }

                    // REMOVE iTEMS FRÅN TABLE
                    foreach (var tempDetail in TempOrderItems)
                    {
                        await App.TempDetailOrderDatabase.DeleteItemAsync(tempDetail);
                    }
                    
                }

                await DisplayAlert("Attention","Din beställning har skickats till köket, tack", "OK");
                await App.TempDetailOrderDatabase.CreateTable();
               /* await Navigation.PushAsync(new MenuPage());*/
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void TempDetailOrdersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var temp= (TempDetailOrder)e.SelectedItem;
            Navigation.PushAsync(new OrderPage(temp));
        }
    }
}