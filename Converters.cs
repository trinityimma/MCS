using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MCS
{
    internal class BackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isEnabled= (bool)value;
            if (!isEnabled)
                return Brushes.LightGray;
            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
