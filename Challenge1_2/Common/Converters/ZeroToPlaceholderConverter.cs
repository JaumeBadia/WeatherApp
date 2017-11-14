using System;
using Xamarin.Forms;
using System.Globalization;

namespace Challenge1_2.Common.Converters
{
    public class ZeroToPlaceholderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (System.Convert.ToInt32(value) == 0) ? " " : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
