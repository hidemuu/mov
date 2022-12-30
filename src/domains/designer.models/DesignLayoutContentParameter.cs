using Mov.Layouts.Contents;
using Mov.Layouts.Contents.ValueObjects;
using Mov.Schemas.Parameters;
using Mov.Schemas.Resources.Images;
using Mov.Schemas.Resources.Localizes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class DesignLayoutContentParameter : LayoutParameter
    {

        public DesignLayoutContentParameter() : this(new Content())
        {

        }

        public DesignLayoutContentParameter(Content content) : base(new LocalString(content.Name), new IconImage(content.Icon), VisibilityStyle.Visible, EnableStyle.Enable, new Parameter(content.Parameter))
        {
            
        }
    }
}
