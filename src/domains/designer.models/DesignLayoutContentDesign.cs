using Mov.Layouts.Contents;
using Mov.Layouts.Contents.ValueObjects;
using Mov.Schemas.Styles;
using Mov.Schemas.Units;
using Mov.Schemas.Units.Sizes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class DesignLayoutContentDesign : LayoutContentDesign
    {
        
        public DesignLayoutContentDesign() : this(new Content())
        {

        }

        public DesignLayoutContentDesign(Content content) 
            : base(MarginUnit.Default, new Size2D((decimal)content.Width, (decimal)content.Height), OrientationStyle.Horizontal, new HorizontalAlignmentStyle(content.HorizontalAlignment), new VerticalAlignmentStyle(content.VerticalAlignment))
        {
            
        }
    }
}
