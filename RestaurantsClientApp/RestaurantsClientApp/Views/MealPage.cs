using RestaurantsClientApp.Models;
using RestaurantsClientApp.Styles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace RestaurantsClientApp.Views
{
    public class MealPage : ContentPage
    {
        FlexLayout flexLayout;
        ObservableCollection<Meal> Items { get; }
        public MealPage(string classid)
        {
            Items = new ObservableCollection<Meal>();
            ExecuteLoadItemsCommand(classid);
        }
      
        private async void ExecuteLoadItemsCommand(string classid)
        {
            IsBusy = true;

            try
            {
                Items.Clear();

                var MealItems = await App.MealDatabase.GetItemsAsync(classid);

                foreach (var item in MealItems)
                {
                    Items.Add(item);
                }

                DrawGridAndContents();

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
        private void DrawGridAndContents()
        {

            Title = "Vår måltider";
            Padding = new Thickness(0, 10, 0, 10);


            flexLayout = new FlexLayout();

            flexLayout.JustifyContent = FlexJustify.SpaceAround;
            flexLayout.Wrap = FlexWrap.Wrap;
            flexLayout.Direction = FlexDirection.Row;
            flexLayout.Style = StylesControls.buttonStyle;


            flexLayout.Padding = new Thickness(5);

            foreach (var item in Items)
            {

                var imgButton = new ImageButton
                {

                    Style = StylesControls.buttonStyle,
                    Source = item.Path,


                };

                var stack = new StackLayout
                {
                    HeightRequest = 100,
                    WidthRequest = 100,
                    ClassId = item.MealId,

                    Children =
                    {
                        imgButton, new Label
                        {
                            Text = item.MealName, HorizontalOptions = LayoutOptions.Center,FontAttributes= FontAttributes.Bold,

                        }
                    }

                };

                var tapImage = new TapGestureRecognizer();
                tapImage.NumberOfTapsRequired = 1;
                //tapImage.BindingContext = _viewModel;
                //tapImage.SetBinding(TapGestureRecognizer.CommandProperty, new Binding("TapImage", 0));
                //Binding events  
                tapImage.Tapped += TapImage_Tapped;
                //Associating tap events to the image buttons   
                stack.GestureRecognizers.Add(tapImage);

                flexLayout.Children.Add(stack);

            }
            Content = flexLayout;
        }
        private void TapImage_Tapped(object sender, EventArgs e)
        {
            string classid = (string)((BindableObject)sender).GetValue(StackLayout.ClassIdProperty);
            Navigation.PushAsync(new DetailMealPage(classid));
        }
    }
}