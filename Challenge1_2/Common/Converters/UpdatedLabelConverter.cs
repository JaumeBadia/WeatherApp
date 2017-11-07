using System;
using Xamarin.Forms;
using System.Globalization;

namespace Challenge1_2.Common.Converters
{
    public class UpdatedLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "Updated as of " + (System.Convert.ToDateTime(value).ToString("h:mm tt")).ToUpper();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
