using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Mov.WpfControls.Converters
{
    [ValueConversion(typeof(string), typeof(HorizontalAlignment))]
    public class StringToHolizontalAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
            {
                return DependencyProperty.UnsetValue;
            }

            switch ((string)value) 
            {
                case "Left":
                    return HorizontalAlignment.Left;
                case "Center":
                    return HorizontalAlignment.Center;
                case "Right":
                    return HorizontalAlignment.Right;
                case "Stretch":
                    return HorizontalAlignment.Stretch;
            }
            return HorizontalAlignment.Stretch;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
