using System;
using System.Collections.Generic;
using Challenge1_2.Common;

namespace Challenge1_2.Models
{
    public class WeatherInformation : ObservableBase
    {
        /*int _id;
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
        }*/

        public class ResponseWeather : ObservableBase
        {
            Coord _coord;
            public Coord coord              
            { 
                get {return _coord;} 
                set {SetProperty(ref _coord, value);}
            }

            List<Weather> _weather;
            public List<Weather> weather    
            { 
                get {return _weather;} 
                set {SetProperty(ref _weather, value);}
            }

            Main _main; 
            public Main main                
            { 
                get {return _main;} 
                set {SetProperty(ref _main, value);}
            }

            Wind _wind;
            public Wind wind                
            { 
                get {return _wind;} 
                set {SetProperty(ref _wind, value);}
            }

            Clouds _clouds;
            public Clouds clouds            
            { 
                get {return _clouds;} 
                set {SetProperty(ref _clouds, value);}
            }

            Sys _sys;
            public Sys sys                  
            { 
                get {return _sys;} 
                set {SetProperty(ref _sys, value);}
            }

            String _base;
            public string @base 
            { 
                get { return _base; } 
                set { SetProperty(ref _base, value); } 
            }

            int _visibility;
            public int visibility   
            { 
                get { return _visibility; } 
                set { SetProperty(ref _visibility, value); } 
            }

            int _dt;
            public int dt           
            { 
                get { return _dt; } 
                set { SetProperty(ref _dt, value); } 
            }

            int _id;
            public int id          
            { 
                get { return _id; } 
                set { SetProperty(ref _id, value); }
            }

            String _name;
            public string name      
            { 
                get { return _name; } 
                set { SetProperty(ref _name, value); }
            }

            int _cod;
            public int cod          
            { 
                get { return _cod; } 
                set { SetProperty(ref _cod, value); }
            }

        }


        public class Coord : ObservableBase
        {
            Double _lon;
            public double lon 
            { 
                get { return _lon; } 
                set { SetProperty(ref _lon, value); }
            }

            Double _lat;
            public double lat 
            { 
                get { return _lat; } 
                set { SetProperty(ref _lat, value); }
            }

        }

        public class Weather : ObservableBase
        {
            int _id;
            public int id               
            { 
                get {return _id;} 
                set { SetProperty(ref _id, value); }
            }

            String _main;
            public string main          
            { 
                get {return _main;} 
                set { SetProperty(ref _main, value); } 
            }

            String _description;
            public string description   
            { 
                get {return _description;} 
                set { SetProperty(ref _description, value); } 
            }

            String _icon;
            public string icon          
            { 
                get {return _icon;}
                set { SetProperty(ref _icon, value); }
            }

        }

        public class Main : ObservableBase
        {
            double _temp;
            public double temp      
            { 
                get {return _temp;} 
                set { SetProperty(ref _temp, value); } 
            }

            double _pressure;
            public double pressure     
            { 
                get {return _pressure;} 
                set { SetProperty(ref _pressure, value); } 
            }

            int _humidity;
            public int humidity     
            { 
                get {return _humidity;} 
                set { SetProperty(ref _humidity, value); } 
            }

            double _temp_min;
            public double temp_min  
            { 
                get {return _temp_min;} 
                set { SetProperty(ref _temp_min, value); } 
            }

            double _temp_max;
            public double temp_max  
            { 
                get {return _temp_max;} 
                set { SetProperty(ref _temp_max, value); } 
            }

        }

        public class Wind : ObservableBase
        {
            double _speed;
            public double speed         
            { 
                get {return _speed;} 
                set { SetProperty(ref _speed, value); } 
            }

            int _deg;
            public int deg              
            { 
                get {return _deg;} 
                set { SetProperty(ref _deg, value); } 
            }

        }

        public class Clouds : ObservableBase
        {
            int _all;
            public int all              
            { 
                get { return _all; } 
                set { SetProperty(ref _all, value); } 
            }

        }

        public class Sys : ObservableBase
        {
            int _type;
            public int type             
            { 
                get {return _type;} 
                set { SetProperty(ref _type, value); } 
            }

            int _id;
            public int id               
            { 
                get {return _id;} 
                set { SetProperty(ref _id, value); } 
            }

            double _message;
            public double message       
            { 
                get {return _message;} 
                set { SetProperty(ref _message, value); } 
            }

            string _country;
            public string country       
            { 
                get {return _country;} 
                set { SetProperty(ref _country, value); } 
            }

            int _sunrise;
            public int sunrise          
            { 
                get {return _sunrise;} 
                set { SetProperty(ref _sunrise, value); } 
            }

            int _sunset;
            public int sunset           
            { 
                get {return _sunset;} 
                set { SetProperty(ref _sunset, value); } 
            }

        }
    }
}

