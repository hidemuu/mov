using Mov.Core.Contexts.Layouts.ValueObjects;
using Mov.Core.Models.Units;
using Mov.Core.Models.Units.Sizes;

namespace Mov.Core.Layouts.Models.Shells
{
    public class LayoutShell
    {
        public static LayoutShell Empty = new LayoutShell(
            RegionStyle.Center, ColorStyle.Transrarent, ColorStyle.Transrarent, ThicknessUnit.Default, Size2D.Default);

        public RegionStyle Region { get; }

        public ColorStyle BackgroundColor { get; }

        public ColorStyle BorderColor { get; }

        public ThicknessUnit BorderThickness { get; }

        public Size2D Size { get; }

        public LayoutShell(RegionStyle region, ColorStyle background, ColorStyle border, ThicknessUnit thickness, Size2D size)
        {
            Region = region;
            BackgroundColor = background;
            BorderColor = border;
            BorderThickness = thickness;
            Size = size;
        }
    }
}