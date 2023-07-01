using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mov.WpfModels.Converters
{
    public class BoolToVisibillityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }
            var isCanExcute = (bool)value;
            if (isCanExcute)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Hidden;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
