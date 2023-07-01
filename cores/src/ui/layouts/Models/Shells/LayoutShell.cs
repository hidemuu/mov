using Mov.Core.Models.ValueObjects.Layouts;
using Mov.Core.Models.ValueObjects.Styles;
using Mov.Core.Models.ValueObjects.Units;
using Mov.Core.Models.ValueObjects.Units.Sizes;

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