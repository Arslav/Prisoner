using Prisoner.Test;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Prisoner
{
    public partial class App : Application
    {
        public static TestContext DB { get; private set; }
        public App()
        {
            InitializeComponent();
            var dbName = "db.sqlite";
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var fullPath = Path.Combine(directory,dbName);
            DB = new TestContext(fullPath);
            DB.Database.EnsureCreated();
            MainPage = new StartPage();
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
