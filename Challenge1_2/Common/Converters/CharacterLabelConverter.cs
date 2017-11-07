using System;
using Xamarin.Forms;
using System.Globalization;

namespace Challenge1_2.Common.Converters
{
    public class CharacterLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (((int)value) == 0) ? "" : (value) + "" + parameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
