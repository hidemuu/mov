using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Mov.WpfModels.Converters
{
    [ValueConversion(typeof(DateTime), typeof(Brush))]
    public class DateTimeToPatternBrushConverter : IValueConverter
    {
        /// <summary>
        /// 日曜日用のブラシリソース
        /// </summary>
        public static Brush SundayBrush
        {
            get { return Brushes.PapayaWhip; }
        }

        /// <summary>
        /// 土曜日用のブラシリソース
        /// </summary>
        public static Brush SaturdayBrush
        {
            get { return Brushes.LightBlue; }
        }

        public static Brush NormalBrush
        {
            get { return Brushes.Azure; }
        }

        /// <summary>値を変換します。</summary>
        /// <returns>変換された値。 メソッドが null を返す場合は、有効な null 値が使用されています。</returns>
        /// <param name="value">バインディング ソースによって生成された値。</param>
        /// <param name="targetType">バインディング ターゲット プロパティの型。</param>
        /// <param name="parameter">使用するコンバーター パラメーター。</param>
        /// <param name="culture">コンバーターで使用するカルチャ。</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DateTime))
            {
                return DependencyProperty.UnsetValue;
            }

            var dayOfWeek = ((DateTime)value).DayOfWeek;
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return SundayBrush;
                case DayOfWeek.Saturday:
                    return SaturdayBrush;
                default:
                    return NormalBrush;
                    //return DependencyProperty.UnsetValue;
            }
        }

        /// <summary>値を変換します。</summary>
        /// <returns>変換された値。 メソッドが null を返す場合は、有効な null 値が使用されています。</returns>
        /// <param name="value">バインディング ターゲットによって生成される値。</param>
        /// <param name="targetType">変換後の型。</param>
        /// <param name="parameter">使用するコンバーター パラメーター。</param>
        /// <param name="culture">コンバーターで使用するカルチャ。</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
