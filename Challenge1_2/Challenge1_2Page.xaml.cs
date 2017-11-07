using System;
using Xamarin.Forms;

namespace Challenge1_2
{
	public partial class MainPage : ContentPage
	{

        bool btn;

        public MainPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			BindingContext = App.ViewModel;

			if (App.ViewModel.NeedsRefresh) 
                await App.ViewModel.RefreshCurrentConditionsAsync(btn);
            
			base.OnAppearing();
		}

        async void Handle_Clicked_F(object sender, EventArgs e)
        {
            btn = true;
            await App.ViewModel.RefreshCurrentConditionsAsync(btn);
            temp.Text = "F";
        }

        async void Handle_Clicked_C(object sender, EventArgs e)
        {
            btn = false;
            await App.ViewModel.RefreshCurrentConditionsAsync(btn);
            temp.Text = "C";
        }
    }

}