using Mov.Layouts.Contents;
using Mov.Layouts.Contents.ValueObjects;
using Mov.Schemas.Bodies;
using Mov.Schemas.Parameters;
using Mov.Schemas.Resources.Macros;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class DesignLayoutContentValue : LayoutContentValue
    {
        
        public DesignLayoutContentValue() : this(new Content())
        {

        }

        public DesignLayoutContentValue(Content content) : base(new LayoutSchema(content.Schema), new Variable(content.DefaultValue), new Macro(content.Macro))
        {
            
        }
    }
}
