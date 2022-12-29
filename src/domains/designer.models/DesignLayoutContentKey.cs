using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class DesignLayoutContentKey : ILayoutKey
    {
        public ContentCode Code { get; }

        public ContentControlType ControlType { get; }

        public DesignLayoutContentKey() : this(new Content())
        {

        }

        public DesignLayoutContentKey(Content content)
        {
            this.Code = new ContentCode(content.Code);
            this.ControlType = new ContentControlType(content.ControlType);
        }
    }
}
