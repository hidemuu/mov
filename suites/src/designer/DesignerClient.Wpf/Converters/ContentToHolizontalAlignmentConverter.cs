using Mov.Core.Styles.Models;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mov.Suite.DesignerClient.Wpf.Converters
{
    [ValueConversion(typeof(string), typeof(HorizontalAlignment))]
    public class ContentToHolizontalAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is HorizontalAlignmentStyle horizontalAlignment))
            {
                return DependencyProperty.UnsetValue;
            }
            if (horizontalAlignment.IsLeft) return HorizontalAlignment.Left;
            if (horizontalAlignment.IsCenter) return HorizontalAlignment.Center;
            if (horizontalAlignment.IsRight) return HorizontalAlignment.Right;
            if (horizontalAlignment.IsStretch) return HorizontalAlignment.Stretch;
            return HorizontalAlignment.Stretch;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
