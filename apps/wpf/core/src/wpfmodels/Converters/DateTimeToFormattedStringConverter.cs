using System;
using System.Globalization;
using System.Windows.Data;

namespace Mov.WpfModels.Converters
{
    [ValueConversion(typeof(DateTime?), typeof(string))]

    public class DateTimeToFormattedStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime = value as DateTime?;
            var format = parameter?.ToString() ?? "yyyy/MM/dd HH:mm";

            if (dateTime.HasValue)
            {
                return dateTime.Value.ToString(format);
            }
            else
            {
                var dummyDateTime = new DateTime(1111, 11, 11, 11, 11, 11);
                var text = dummyDateTime.ToString(format);
                return text.Replace("1", " ‐");
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
