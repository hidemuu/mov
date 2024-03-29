﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mov.WpfModels.Converters
{
    [ValueConversion(typeof(string), typeof(VerticalAlignment))]
    public class StringToVerticalAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
            {
                return DependencyProperty.UnsetValue;
            }

            switch ((string)value)
            {
                case "Top":
                    return VerticalAlignment.Top;
                case "Bottom":
                    return VerticalAlignment.Bottom;
                case "Center":
                    return VerticalAlignment.Center;
                case "Stretch":
                    return VerticalAlignment.Stretch;
            }
            return VerticalAlignment.Stretch;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
