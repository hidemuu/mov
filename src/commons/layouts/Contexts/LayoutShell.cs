using Mov.Schemas.Styles;
using Mov.Schemas.Units;
using Mov.Schemas.Units.Sizes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contexts
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
