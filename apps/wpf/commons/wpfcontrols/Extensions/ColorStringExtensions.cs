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