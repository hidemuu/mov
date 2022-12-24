using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class LayoutContentValue : ILayoutValue
    {
        public ContentSchema Schema { get; }

        public ContentValue ContentValue { get; }

        public ContentMacro Macro { get; }

        public LayoutContentValue() : this(new Content())
        {

        }

        public LayoutContentValue(Content content)
        {
            this.Schema = new ContentSchema(content.Schema);
            this.ContentValue = new ContentValue(content.DefaultValue);
            this.Macro = new ContentMacro(content.Macro);
        }
    }
}
