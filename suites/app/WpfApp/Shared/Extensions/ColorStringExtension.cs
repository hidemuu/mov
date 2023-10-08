using System.Windows.Media;

namespace Mov.Suite.WpfApp.Shared.Extensions
{
    internal static class ColorStringExtension
    {
        internal static Brush GetBrush(this string color)
        {
            return (Brush)new BrushConverter().ConvertFromString(color);
        }
    }
}
