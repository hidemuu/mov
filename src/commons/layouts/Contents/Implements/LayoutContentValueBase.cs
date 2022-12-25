using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public class LayoutContentValueBase : ILayoutValue
    {
        public ContentSchema Schema { get; }

        public ContentValue ContentValue { get; }

        public ContentMacro Macro { get; }

        
        public LayoutContentValueBase(string schema, string value, string macro)
        {
            this.Schema = new ContentSchema(schema);
            this.ContentValue = new ContentValue(value);
            this.Macro = new ContentMacro(macro);
        }
    }
}
