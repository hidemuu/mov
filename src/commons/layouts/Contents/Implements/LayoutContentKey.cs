using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.ValueObjects;
using Mov.Schemas.Keys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public class LayoutContentKey : ILayoutKey
    {
        public CodeKey Code { get; }

        public ContentControlType ControlType { get; }

        
        public LayoutContentKey(string code, string controlType)
        {
            this.Code = new CodeKey(code);
            this.ControlType = new ContentControlType(controlType);
        }

        public LayoutContentKey() : this("", "")
        {

        }
    }
}
