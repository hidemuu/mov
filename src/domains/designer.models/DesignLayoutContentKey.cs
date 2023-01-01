using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.Contexts.Contents;
using Mov.Schemas.Keys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class DesignLayoutContentKey : LayoutContentKey
    {
        public DesignLayoutContentKey() : this(new Content())
        {

        }

        public DesignLayoutContentKey(Content content) 
            : base(new CodeKey(content.Code), new ControlStyle(content.ControlType))
        {
        }
    }
}
