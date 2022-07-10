using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantsClientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
      
        public MainPage()
        {
            InitializeComponent();
            this.IncidentImageData.Source = ImageSource.FromResource("RestaurantsClientApp.ProImgs.Grill.jpg");
           
        }
        private byte[] ReadAnImage(string fileName)
        {

            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            var folder = Path.Combine(path, "ProImgs");

            Directory.CreateDirectory(folder);

            var file = Path.Combine(folder, fileName);
           
         //   File.WriteAllBytes(file, data);

            return File.ReadAllBytes(file);
        }
    }
}