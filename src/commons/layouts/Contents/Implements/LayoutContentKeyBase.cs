using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public class LayoutContentKeyBase : ILayoutKey
    {
        public ContentCode Code { get; }

        public ContentControlType ControlType { get; }

        
        public LayoutContentKeyBase(string code, string controlType)
        {
            this.Code = new ContentCode(code);
            this.ControlType = new ContentControlType(controlType);
        }
    }
}
