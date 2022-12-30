using Mov.Layouts;
using Mov.Layouts.ValueObjects;
using Mov.Schemas.Styles;
using Mov.Schemas.Units.Sizes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public class LayoutShell : ILayoutShell
    {
        public RegionStyle Region { get; }

        public ColorStyle BackgroundColor { get; }

        public ColorStyle BorderColor { get; }

        public Size2D Size { get; }

        public LayoutShell(RegionStyle region, ColorStyle background, ColorStyle border, Size2D size)
        {
            this.Region = region;
            this.BackgroundColor = background;
            this.BorderColor = border;
            this.Size = size;
        }

    }
}
