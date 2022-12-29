using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public class LayoutContentDesign : ILayoutDesign
    {
        public ContentIndent Indent { get; }

        public ContentHeight Height { get; }

        public ContentWidth Width { get; }

        public ContentOrientation Orientation { get; }

        public ContentHorizontalAlignment HorizontalAlignment { get; }

        public ContentVerticalAlignment VerticalAlignment { get; }

        public LayoutContentDesign(int indent, double height, double width, ContentOrientation orientation, string horizontalAlignment, string verticalAlignment)
        {
            this.Indent = new ContentIndent(indent);
            this.Height = new ContentHeight(height);
            this.Width = new ContentWidth(width);
            this.Orientation = orientation;
            this.HorizontalAlignment = new ContentHorizontalAlignment(horizontalAlignment);
            this.VerticalAlignment = new ContentVerticalAlignment(verticalAlignment);
        }

        public LayoutContentDesign() : this(0, 0, 0, ContentOrientation.Horizontal, "", "")
        {

        }
    }
}
