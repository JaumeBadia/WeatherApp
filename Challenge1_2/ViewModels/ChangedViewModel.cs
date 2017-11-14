using System;
using System.Windows.Input;
using Challenge1_2.Common;
using Xamarin.Forms;

namespace Challenge1_2.Models
{

    public class ChangedViewModel : ObservableBase
    {
        WeatherInformation.Main CurrentConditionsMain;

        public ChangedViewModel(WeatherInformation.Main currentConditionsMain)
        {
            TempChangedC = new Command(CalculateTempC);
            TempChangedF = new Command(CalculateTempF);

            CurrentConditionsMain = currentConditionsMain;
        }

        String _grades;
        public String grades
        {
            get { return _grades; }
            set { SetProperty(ref _grades, value); }
        }

        int _temp;
        public int temp
        {
            get { return _temp; }
            set { SetProperty(ref _temp, value); }
        }

        int _temp_min;
        public int temp_min
        {
            get { return _temp_min; }
            set { SetProperty(ref _temp_min, value); }
        }

        int _temp_max;
        public int temp_max
        {
            get { return _temp_max; }
            set { SetProperty(ref _temp_max, value); }
        }

        ICommand _TempChangedC;
        public ICommand TempChangedC
        {
            get { return _TempChangedC; }
            set { SetProperty(ref _TempChangedC, value); }
        }

        ICommand _TempChangedF;
        public ICommand TempChangedF
        {
            get { return _TempChangedF; }
            set { SetProperty(ref _TempChangedF, value); }
        }

        void CalculateTempC()
        {
            temp = Convert.ToInt32(CurrentConditionsMain.temp - 273.15);
            temp_min = Convert.ToInt32(CurrentConditionsMain.temp_min - 273.15);
            temp_max = Convert.ToInt32(CurrentConditionsMain.temp_max - 273.15);
            grades = "C";
        }

        void CalculateTempF()
        {
            temp = Convert.ToInt32(CurrentConditionsMain.temp * 9 / 5 - 459.67);
            temp_min = Convert.ToInt32(CurrentConditionsMain.temp_min * 9 / 5 - 459.67);
            temp_max = Convert.ToInt32(CurrentConditionsMain.temp_max * 9 / 5 - 459.67);
            grades = "F";
        }
    }
}
