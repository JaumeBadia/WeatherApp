using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace Challenge1_2
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            BindingContext = App.ViewModel;

            if (App.ViewModel.NeedsRefresh)
                await App.ViewModel.RefreshCurrentConditionsAsync();

            base.OnAppearing();
        }



        void Handle_Clicked_F(object sender, EventArgs e)
        {
            temp.Text = "F";
        }

        void Handle_Clicked_C(object sender, EventArgs e)
        {
            temp.Text = "C";

        }
    }
}