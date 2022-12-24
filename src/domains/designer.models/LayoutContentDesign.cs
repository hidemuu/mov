using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class LayoutContentDesign : ILayoutDesign
    {
        public ContentIndent Indent { get; }

        public ContentHeight Height { get; }

        public ContentWidth Width { get; }

        public ContentOrientation Orientation { get; }

        public ContentHorizontalAlignment HorizontalAlignment { get; }

        public ContentVerticalAlignment VerticalAlignment { get; }

        public LayoutContentDesign() : this(new Content())
        {

        }

        public LayoutContentDesign(Content content)
        {
            this.Indent = new ContentIndent(0);
            this.Height = new ContentHeight(content.Height);
            this.Width = new ContentWidth(content.Width);
            this.Orientation = ContentOrientation.Horizontal;
            this.HorizontalAlignment = new ContentHorizontalAlignment(content.HorizontalAlignment);
            this.VerticalAlignment = new ContentVerticalAlignment(content.VerticalAlignment);
        }
    }
}
