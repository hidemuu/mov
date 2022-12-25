using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public class LayoutContentParameterBase : ILayoutParameter
    {
        public ContentName Name { get; }

        public ContentIcon Icon { get; }

        public ContentVisibility Visibility { get; }

        public ContentEnable Enable { get; }

        public ContentParameter Parameter { get; }

        
        public LayoutContentParameterBase(string name, string icon, bool isVisible, bool isEnable, string parameter)
        {
            this.Name = new ContentName(name);
            this.Icon = new ContentIcon(icon);
            this.Visibility = new ContentVisibility(isVisible);
            this.Enable = new ContentEnable(isEnable);
            this.Parameter = new ContentParameter(parameter);
        }
    }
}
