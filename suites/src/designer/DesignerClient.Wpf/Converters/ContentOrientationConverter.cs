using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using Mov.Core.Styles.Models;

namespace Mov.Suite.DesignerClient.Wpf.Converters
{
    public class ContentOrientationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }
            var isCanExcute = (string)value;
            if (isCanExcute == OrientationStyle.Vertical.Value)
            {
                return Orientation.Vertical;
            }
            else
            {
                return Orientation.Horizontal;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
