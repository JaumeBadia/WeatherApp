using Challenge1_2.Common;
using Challenge1_2.Models;
using System.Threading.Tasks;
using Plugin.Geolocator.Abstractions;
using Challenge1_2.Helpers;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;

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
            CountryCode = "NL";
            CurrentConditionsResponse = new WeatherInformation.ResponseWeather();
            CurrentConditionsCoord = new WeatherInformation.Coord();
            //CurrentConditionsWeather = new List<WeatherInformation.Weather>();
            CurrentConditionsWeather = new WeatherInformation.Weather();
            CurrentConditionsMain = new WeatherInformation.Main();
            CurrentConditionsWind = new WeatherInformation.Wind();
            CurrentConditionsClouds = new WeatherInformation.Clouds();
            CurrentConditionsSys = new WeatherInformation.Sys();
            ChangedConditions = new ChangedViewModel(CurrentConditionsMain);
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

        WeatherInformation.ResponseWeather _currentConditionsResponse;
        public WeatherInformation.ResponseWeather CurrentConditionsResponse
        {
            get { return _currentConditionsResponse; }
            set { SetProperty(ref _currentConditionsResponse, value); }
        }

        WeatherInformation.Coord _currentConditionsCoord;
        public WeatherInformation.Coord CurrentConditionsCoord
        {
            get { return _currentConditionsCoord; }
            set { SetProperty(ref _currentConditionsCoord, value); }
        }

        /*List<WeatherInformation.Weather> _currentConditionsWeather;
        public List<WeatherInformation.Weather> CurrentConditionsWeather
        {
            get { return _currentConditionsWeather; }
            set { SetProperty(ref _currentConditionsWeather, value); }
        }*/

        WeatherInformation.Weather _currentConditionsWeather;
        public WeatherInformation.Weather CurrentConditionsWeather
        {
            get { return _currentConditionsWeather; }
            set { SetProperty(ref _currentConditionsWeather, value); }
        }

        WeatherInformation.Main _currentConditionsMain;
        public WeatherInformation.Main CurrentConditionsMain
        {
            get { return _currentConditionsMain; }
            set { SetProperty(ref _currentConditionsMain, value); }
        }

        WeatherInformation.Wind _currentConditionsWind;
        public WeatherInformation.Wind CurrentConditionsWind
        {
            get { return _currentConditionsWind; }
            set { SetProperty(ref _currentConditionsWind, value); }
        }

        WeatherInformation.Clouds _currentConditionsClouds;
        public WeatherInformation.Clouds CurrentConditionsClouds
        {
            get { return _currentConditionsClouds; }
            set { SetProperty(ref _currentConditionsClouds, value); }
        }

        WeatherInformation.Sys _currentConditionsSys;
        public WeatherInformation.Sys CurrentConditionsSys
        {
            get { return _currentConditionsSys; }
            set { SetProperty(ref _currentConditionsSys, value); }
        }

        ChangedViewModel _changedConditions;
        public ChangedViewModel ChangedConditions
        {
            get { return _changedConditions; }
            set { SetProperty(ref _changedConditions, value); }
        }

        bool _needsRefresh;
        public bool NeedsRefresh
        {
            get { return _needsRefresh || string.IsNullOrEmpty(_currentConditionsResponse.name); }
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

        ObservableCollection<WeatherInformation.ResponseWeather> _forecast;

        public ObservableCollection<WeatherInformation.ResponseWeather> Forecast
        {
            get
            {
                if (_forecast == null)
                {
                    _forecast = new ObservableCollection<WeatherInformation.ResponseWeather>();
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

            List<WeatherInformation.ResponseWeather> results = null;

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

            WeatherInformation.ResponseWeather resultsResponse = null;

            switch (LocationType)
            {
                case LocationType.Location:
                    if (Location == null)
                        Location = await LocationHelper.GetCurrentLocationAsync();
                    resultsResponse = await WeatherHelper.GetCurrentConditionsAsync(Location.Latitude, Location.Longitude);
                    break;

                case LocationType.City:
                    resultsResponse = await WeatherHelper.GetCurrentConditionsAsync(CityName, CountryCode);
                    break;
            }

            CurrentConditionsWeather.main = resultsResponse.weather[0].main;
            CurrentConditionsWeather.description = resultsResponse.weather[0].description;
            //CurrentConditionsWeather[0].icon = resultsResponse.weather[0].icon;
            CurrentConditionsWeather.icon = resultsResponse.weather[0].icon;
            CurrentConditionsResponse.name = resultsResponse.name;
            //CurrentConditionsResponse.weather.Contains() = resultsWeather;
            CurrentConditionsResponse.id = resultsResponse.id;
            CurrentConditionsMain.temp_max = resultsResponse.main.temp_max;
            CurrentConditionsMain.temp_min = resultsResponse.main.temp_min;
            CurrentConditionsMain.temp = resultsResponse.main.temp;
            //CurrentConditions.Humidity = results.Humidity;
            CurrentConditionsResponse.dt = resultsResponse.dt;

            ChangedConditions.temp_max = Convert.ToInt32(CurrentConditionsMain.temp_max - 273.15);
            ChangedConditions.temp_min = Convert.ToInt32(CurrentConditionsMain.temp_min - 273.15);
            ChangedConditions.temp = Convert.ToInt32(CurrentConditionsMain.temp - 273.15);
            ChangedConditions.grades = "C";

            IsBusy = false;
        }
    }
}