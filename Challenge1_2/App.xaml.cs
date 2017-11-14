using Challenge1_2.Models;
using Xamarin.Forms;

namespace Challenge1_2
{
    public partial class App : Application
    {
		public static MainViewModel ViewModel;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartPage());
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
