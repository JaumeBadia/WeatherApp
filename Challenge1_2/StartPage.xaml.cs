using System;
using Challenge1_2.Models;
using Xamarin.Forms;

namespace Challenge1_2
{
    public partial class StartPage : TabbedPage
	{
		public StartPage()
		{
			InitializeComponent();

		}

		protected override void OnAppearing()
		{
			InitializeAppAsync();
			base.OnAppearing();
		}

		void InitializeAppAsync()
		{
			if (App.ViewModel == null) 
                App.ViewModel = new MainViewModel();

		}

		async void ViewForecastClicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new ForecastPage());
        }

	}
}