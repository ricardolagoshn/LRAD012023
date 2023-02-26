using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace LRAD012023
{
    public partial class App : Application
    {
        static Controllers.AlumnosController dbalum;

        public static Controllers.AlumnosController DBAlum 
        { 
            get 
            {
                if (dbalum == null)
                {
                    var dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var dbname = "Alum.db3";
                    dbalum = new Controllers.AlumnosController(Path.Combine(dbpath, dbname));
                }

                return dbalum;
            }  
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.PageInitial());
        }

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
