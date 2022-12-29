using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class DesignLayoutContentParameter : ILayoutParameter
    {
        public ContentName Name { get; }

        public ContentIcon Icon { get; }

        public ContentVisibility Visibility { get; }

        public ContentEnable Enable { get; }

        public ContentParameter Parameter { get; }

        public DesignLayoutContentParameter() : this(new Content())
        {

        }

        public DesignLayoutContentParameter(Content content)
        {
            this.Name = new ContentName(content.Name);
            this.Icon = new ContentIcon(content.Icon);
            this.Visibility = new ContentVisibility(true);
            this.Enable = new ContentEnable(true);
            this.Parameter = new ContentParameter(content.Parameter);
        }
    }
}
