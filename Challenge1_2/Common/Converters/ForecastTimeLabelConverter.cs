using System;
using Xamarin.Forms;
using System.Globalization;

namespace Challenge1_2.Common.Converters
{
    public class ForecastTimeLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (System.Convert.ToDateTime(value).ToString("ddd ht")).ToUpper();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
