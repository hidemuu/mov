using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.ValueObjects;
using Mov.Schemas.Keys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class DesignLayoutContentKey : ILayoutKey
    {
        public CodeKey Code { get; }

        public ContentControlType ControlType { get; }

        public DesignLayoutContentKey() : this(new Content())
        {

        }

        public DesignLayoutContentKey(Content content)
        {
            this.Code = new CodeKey(content.Code);
            this.ControlType = new ContentControlType(content.ControlType);
        }
    }
}
