using LiveCharts.Defaults;
using LiveCharts;
using Mov.Schemas.Units.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Mov.WpfControls.Extensions
{
    internal static class ColorStringExtensions
    {
        internal static Brush GetBrush(this string color)
        {
            return (Brush)new BrushConverter().ConvertFromString(color);
        }
    }
}
