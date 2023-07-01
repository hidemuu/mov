using Mov.Core.Contexts.Layouts.ValueObjects;
using Mov.Core.Models.Units;
using Mov.Core.Models.Units.Sizes;

namespace Mov.Core.Layouts.Models.Contents
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
