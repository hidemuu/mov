using Mov.Layouts.Models.Styles;
using Mov.Utilities.Models.ValueObjects.Units;
using Mov.Utilities.Models.ValueObjects.Units.Sizes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Models.Entities.Contents
{
    public class LayoutContentArrange
    {
        public static LayoutContentArrange Empty = new LayoutContentArrange(
            MarginUnit.Default, Size2D.Default, OrientationStyle.Horizontal, HorizontalAlignmentStyle.Center, VerticalAlignmentStyle.Center);

        public MarginUnit Indent { get; }

        public Size2D Size { get; }

        public OrientationStyle Orientation { get; }

        public HorizontalAlignmentStyle HorizontalAlignment { get; }

        public VerticalAlignmentStyle VerticalAlignment { get; }

        public LayoutContentArrange(MarginUnit indent, Size2D size, OrientationStyle orientation, HorizontalAlignmentStyle horizontalAlignment, VerticalAlignmentStyle verticalAlignment)
        {
            Indent = indent;
            Size = size;
            Orientation = orientation;
            HorizontalAlignment = horizontalAlignment;
            VerticalAlignment = verticalAlignment;
        }

    }
}
