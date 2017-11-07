using System;
using Challenge1_2.Common;

namespace Challenge1_2.Models
{
    public class WeatherInformation : ObservableBase
    {
		int _id;
		public int Id
		{
			get { return _id; }
			set { SetProperty(ref _id, value); }
		}

		string _displayName;
		public string DisplayName
		{
			get { return _displayName; }
			set { SetProperty(ref _displayName, value); }
		}
        
		int _temperature;
		public int Temperature
		{
            get { return _temperature; }
			set { SetProperty(ref _temperature, value); }
		}

		int _humidity;
		public int Humidity
		{
			get { return _humidity; }
			set { SetProperty(ref _humidity, value); }
		}

		int _minTemperature;
		public int MinTemperature
		{
			get { return _minTemperature; }
			set { SetProperty(ref _minTemperature, value); }
		}

		int _maxTemperature;
		public int MaxTemperature
		{
			get { return _maxTemperature; }
			set { SetProperty(ref _maxTemperature, value); }
		}

		string _conditions;
		public string Conditions
		{
			get { return _conditions; }
			set { SetProperty(ref _conditions, value); }
		}

		string _description;
		public string Description
		{
			get { return _description; }
			set { SetProperty(ref _description, value); }
		}

		string _icon;
		public string Icon
		{
			get { return _icon; }
			set { SetProperty(ref _icon, value); }
		}

		DateTime _timeStamp;
		public DateTime TimeStamp
		{
			get { return _timeStamp; }
			set { SetProperty(ref _timeStamp, value); }
		}
    }
}

