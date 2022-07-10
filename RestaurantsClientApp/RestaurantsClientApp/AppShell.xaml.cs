using RestaurantsClientApp.Views;

using Xamarin.Forms;

namespace RestaurantsClientApp
{

    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
          
            Routing.RegisterRoute(nameof(OrdersListPage), typeof(OrdersListPage));
            Routing.RegisterRoute(nameof(OfferPage), typeof(OfferPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(OrderPage), typeof(OrderPage));
        }
    }
}