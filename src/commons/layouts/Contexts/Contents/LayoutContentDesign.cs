using Mov.Layouts.Contents.ValueObjects;
using Mov.Schemas.Styles;
using Mov.Schemas.Units;
using Mov.Schemas.Units.Sizes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contexts.Contents
{
    public class LayoutContentDesign
    {
        public static LayoutContentDesign Empty = new LayoutContentDesign(
            MarginUnit.Default, Size2D.Default, OrientationStyle.Horizontal, HorizontalAlignmentStyle.Center, VerticalAlignmentStyle.Center);

        public MarginUnit Indent { get; }

        public Size2D Size { get; }

        public OrientationStyle Orientation { get; }

        public HorizontalAlignmentStyle HorizontalAlignment { get; }

        public VerticalAlignmentStyle VerticalAlignment { get; }

        public LayoutContentDesign(MarginUnit indent, Size2D size, OrientationStyle orientation, HorizontalAlignmentStyle horizontalAlignment, VerticalAlignmentStyle verticalAlignment)
        {
            Indent = indent;
            Size = size;
            Orientation = orientation;
            HorizontalAlignment = horizontalAlignment;
            VerticalAlignment = verticalAlignment;
        }

    }
}
