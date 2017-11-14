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
            {
                await App.ViewModel.RefreshCurrentConditionsAsync();



            }


            base.OnAppearing();
        }
    }
}