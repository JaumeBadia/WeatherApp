using Challenge1_2.Common;
using Challenge1_2.Models;
using System.Threading.Tasks;
using Plugin.Geolocator.Abstractions;
using Challenge1_2.Helpers;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Challenge1_2
{
    public class MainViewModel : ObservableBase
    {
        #region constructor

        public MainViewModel()
        {
            IsBusy = true;
            NeedsRefresh = true;
            LocationType = LocationType.City;
            CityName = "Amsterdam";
            CountryCode = "HL";
            CurrentConditions = new WeatherInformation();
        }

        #endregion

        #region properties

        LocationType _locationType;
        public LocationType LocationType
        {
            get { return _locationType; }
            set { SetProperty(ref _locationType, value); }
        }

        string _postalCode;
        public string PostalCode
        {
            get { return _postalCode; }
            set { SetProperty(ref _postalCode, value); }
        }

        string _cityName;
        public string CityName
        {
            get { return _cityName; }
            set { SetProperty(ref _cityName, value); }
        }

        string _countryCode;
        public string CountryCode
        {
            get { return _countryCode; }
            set { SetProperty(ref _countryCode, value); }
        }

        WeatherInformation _currentConditions;
        public WeatherInformation CurrentConditions
        {
            get { return _currentConditions; }
            set { SetProperty(ref _currentConditions, value); }
        }

        bool _needsRefresh;
        public bool NeedsRefresh
        {
            get { return _needsRefresh || string.IsNullOrEmpty(_currentConditions.Conditions); }
            set { SetProperty(ref _needsRefresh, value); }
        }

        bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        Position _location;
        public Position Location
        {
            get { return _location; }
            set { SetProperty(ref _location, value); }
        }

        ObservableCollection<WeatherInformation> _forecast;
        public ObservableCollection<WeatherInformation> Forecast
        {
            get
            {
                if (_forecast == null)
                {
                    _forecast = new ObservableCollection<WeatherInformation>();
                }
                return _forecast;
            }
            set { SetProperty(ref _forecast, value); }
        }

        #endregion

        public async Task RefreshForecastAsync()
        {
            IsBusy = true;
            NeedsRefresh = false;

            List<WeatherInformation> results = null;

            Forecast.Clear();

            switch (LocationType)
            {
                case LocationType.Location:

                    if (Location == null)
                        Location = await LocationHelper.GetCurrentLocationAsync();
                    results = await WeatherHelper.GetForecastAsync(Location.Latitude, Location.Longitude);

                    break;
                case LocationType.City:
                    results = await WeatherHelper.GetForecastAsync(CityName, CountryCode);
                    break;
            }

            foreach (var result in results)
            {
                Forecast.Add(result);
            }

            IsBusy = false;
        }

        public async Task RefreshCurrentConditionsAsync()
        {

            IsBusy = true;
            NeedsRefresh = false;

            WeatherInformation results = null;

            switch (LocationType)
            {
                case LocationType.Location:
                    if (Location == null)
                        Location = await LocationHelper.GetCurrentLocationAsync();
                    results = await WeatherHelper.GetCurrentConditionsAsync(Location.Latitude, Location.Longitude);
                    break;

                case LocationType.City:
                    results = await WeatherHelper.GetCurrentConditionsAsync(CityName, CountryCode);
                    break;
            }

            CurrentConditions.Conditions = results.Conditions;
            CurrentConditions.Description = results.Description;
            CurrentConditions.DisplayName = results.DisplayName;
            CurrentConditions.Icon = results.Icon;
            CurrentConditions.Id = results.Id;
            CurrentConditions.MaxTemperature = results.MaxTemperature;
            CurrentConditions.MinTemperature = results.MinTemperature;
            CurrentConditions.Temperature = results.Temperature;
            CurrentConditions.Temperature = results.Temperature;
            CurrentConditions.Humidity = results.Humidity;
            CurrentConditions.TimeStamp = results.TimeStamp.ToLocalTime();

            IsBusy = false;
        }
    }
}