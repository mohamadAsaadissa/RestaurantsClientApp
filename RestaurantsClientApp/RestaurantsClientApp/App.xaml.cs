using RestaurantsClientApp.Services;
using RestaurantsClientApp.Views;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantsClientApp
{//"/data/user/0/com.companyname.createrestaurantdbapp/files/.local/share/RestaurantDB.db";.Replace("com.companyname.restaurantsclientdbapp", "com.companyname.createrestaurantdbapp")
    public partial class App : Application
    {
        public const string DATABASE_NAME = "RestaurantDB.db";
        public static string DBPATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                             DATABASE_NAME);


       

        public static DetailOrderDataStoreAsyncRepository detailOrderdatabase;
        public static DetailOrderDataStoreAsyncRepository DetailOrderdatabase
        {
            
            get
            {
                if (detailOrderdatabase == null)
                {

                    detailOrderdatabase = new DetailOrderDataStoreAsyncRepository(DBPATH);

                }
                return detailOrderdatabase;
            }
        }

        public static OrderDataStoreAsyncRepository orderdatabase;
        public static OrderDataStoreAsyncRepository OrderDatabase
        {
            get
            {
                if (orderdatabase == null)
                {

                    orderdatabase = new OrderDataStoreAsyncRepository(DBPATH);

                }
                return orderdatabase;
            }
        }

        public static ClientAsyncRepository clientdatabase;
        public static ClientAsyncRepository ClientDatabase
        {
            get
            {
                if (clientdatabase == null)
                {

                    clientdatabase = new ClientAsyncRepository(DBPATH);

                }
                return clientdatabase;
            }
        }
        public static TempDetailOrderDataStoreAsyncRepository tempDetailOrderdatabase;
        public static TempDetailOrderDataStoreAsyncRepository TempDetailOrderDatabase
        {
            get
            {
                if (tempDetailOrderdatabase == null)
                {

                    tempDetailOrderdatabase = new TempDetailOrderDataStoreAsyncRepository(DBPATH);

                }
                return tempDetailOrderdatabase;
            }
        }
        public static WorkerAsyncRepository workerdatabase;
        public static WorkerAsyncRepository WorkerDatabase
        {
            get
            {
                if (workerdatabase == null)
                {

                   workerdatabase = new WorkerAsyncRepository(DBPATH);

                }
                return workerdatabase;
            }
        }
        public static MealAsyncRepository mealdatabase;
        public static MealAsyncRepository MealDatabase
        {
            get
            {
                if (mealdatabase == null)
                {

                    mealdatabase = new MealAsyncRepository(DBPATH);

                }
                return mealdatabase;
            }
        }
        public static MenuAsyncRepository menudatabase;
     
        public static MenuAsyncRepository MenuDatabase
        {
            get
            {
                if (menudatabase == null)
                {

                    menudatabase = new MenuAsyncRepository(DBPATH);

                }
                return menudatabase;
            }
        }
        public App()
        {
            InitializeComponent();
           
          
            MainPage = new  AppShell();
        }

        // path where the database will be located
        //private static string GetDatabasePath()
        //{
        //    string dbPath = "/data/user/0/com.companyname.createrestaurantdbapp/files/.local/share/RestaurantDB.db";
        //   // string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
        //    // if the database does not exist (not copied yet)
        //    if (!File.Exists(dbPath))
        //    {
        //        // get the current build
        //        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
        //        // take a database resource from it and create a stream from it
        //        using (Stream stream = assembly.GetManifestResourceStream($"CreateRestaurantDBApp.{DATABASE_NAME}"))
        //        {
        //            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
        //            {
        //                stream.CopyTo(fs); // copy the database file to the desired location
        //                fs.Flush();
        //            }
        //        }

        //    }
        //    return dbPath;
        //}

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
