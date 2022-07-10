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
    public class MenuPage : ContentPage
    {
    
        FlexLayout flexLayout;
        ObservableCollection<GMenu> Items { get; }
        public MenuPage()
        {           
            Items = new ObservableCollection<GMenu>();
             ExecuteLoadItemsCommand();
            
        }
        private async void ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();

                var menuItems = await App.MenuDatabase.GetItemsAsync();

                foreach (var item in menuItems)
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

            Title = "Vår Menu";

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
                    ClassId = item.GMenuId,

                    Children =
                    {
                        imgButton, new Label
                        {
                            Text = item.MenuName, HorizontalOptions = LayoutOptions.Center,FontAttributes= FontAttributes.Bold,

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
            Navigation.PushAsync(new MealPage(classid));
        }
    }
}