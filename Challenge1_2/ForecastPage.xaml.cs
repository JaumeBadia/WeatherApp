using Xamarin.Forms;

namespace Challenge1_2
{
    public partial class ForecastPage : ContentPage
    {
        public ForecastPage()
        {
            InitializeComponent();
        }

		protected override async void OnAppearing()
		{
			BindingContext = App.ViewModel;
            await App.ViewModel.RefreshForecastAsync();
			base.OnAppearing();
		}
    }
}
