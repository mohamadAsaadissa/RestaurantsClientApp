using RestaurantsClientApp.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantsClientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailMealPage : ContentPage
    {
       
        TempDetailOrder tempDetailOrder;
        Meal MealItem;
        public DetailMealPage(string MealId)
        {
            InitializeComponent();
           
            BindingContext =  ExecuteLoadItemsCommand(MealId);
            lblNumOfOrder.Text = Convert.ToString(NumOfOrder);
        }
        protected override async void OnDisappearing()
        {
            // go to root page
            await Navigation.PopToRootAsync();
            base.OnDisappearing();

        }
        private async Task<Meal> ExecuteLoadItemsCommand(string classid)
        {
            IsBusy = true;         

            try
            {
              
                 MealItem = await App.MealDatabase.GetItemAsync(classid);

                ImageData.Source = MealItem.Path;
                DescriptionData.Text= MealItem.Description;
                NameData.Text= MealItem.MealName;
                PriceData.Text =Convert.ToString(MealItem.SalePris);
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
            finally
            {
                IsBusy = false;
                
            }
            return MealItem;
        }

        byte num = 1;
        public byte NumOfOrder
        {
            get { return num; }
            set { num = value; }
        }
       
        void btnPlusClicked(object sender, EventArgs e)
        {
            if (NumOfOrder<20)
                lblNumOfOrder.Text=Convert.ToString(NumOfOrder++);
        }
        void btnMinusClicked(object sender, System.EventArgs e)
        {
            if(NumOfOrder >0)
                lblNumOfOrder.Text = Convert.ToString(NumOfOrder--);
        }
        async void btnAddOrderClicked(object sender, System.EventArgs e)
        {
          bool isOk =  await DisplayAlert("Attention", "Vill du lägga till denna måltid på räkningen?", "OK", "Cancel");

            if(isOk)
            { 
                tempDetailOrder = new TempDetailOrder();

                tempDetailOrder.TempQuantity = NumOfOrder;
                tempDetailOrder.TempMealId = MealItem.MealId;
                tempDetailOrder.TempMealName = MealItem.MealName;
                tempDetailOrder.TempPrice = MealItem.SalePris;
                tempDetailOrder.TempPath = MealItem.Path;
                tempDetailOrder.TempSumma = MealItem.SalePris * NumOfOrder;

                await App.TempDetailOrderDatabase.SaveItemAsync(tempDetailOrder);

                await Navigation.PopAsync(true);
            }

        }
    }
}