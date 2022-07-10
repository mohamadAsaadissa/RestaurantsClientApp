using RestaurantsClientApp.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantsClientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        public TempDetailOrder tempdetailorder { get; private set; }
        public OrderPage( TempDetailOrder vm)
        {
            InitializeComponent();
          
            tempdetailorder=new TempDetailOrder();

            this.BindingContext = tempdetailorder = vm;

            startNum = byte.Parse(tempdetailorder.TempQuantity.ToString());
            lblNumOfOrder.Text = startNum.ToString();
        }
        protected override void OnAppearing()
        {
           
            base.OnAppearing();
          
        }
        private async void UpdateDetailOrderCommand_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            tempdetailorder.TempQuantity = NumOfOrder-1;
            tempdetailorder.TempSumma = (NumOfOrder - 1)* tempdetailorder.TempPrice;

            await App.TempDetailOrderDatabase.UpdateItemAsync(tempdetailorder);
            await Navigation.PopAsync();
        }

        private void BackCommand_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        byte startNum; 
        public byte NumOfOrder
        {
            get { return startNum; }
            set { startNum = value; }
        }
        private void ButtonPlus_Clicked(object sender, EventArgs e)
        {
            if (NumOfOrder <= 20)
                lblNumOfOrder.Text = Convert.ToString(NumOfOrder++);
        }

        private void ButtonMinus_Clicked(object sender, EventArgs e)
        {
            if (NumOfOrder >= 1)
                lblNumOfOrder.Text = Convert.ToString(NumOfOrder--);
        }
    }
 
   
}