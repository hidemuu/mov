using Mov.Layouts;
using Mov.Schemas.Styles;
using Mov.Schemas.Units;
using Mov.Schemas.Units.Sizes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.DomainModels
{
    public class DesignLayoutShell : LayoutShell
    {

        public DesignLayoutShell(Shell shell) 
            : base(RegionStyle.Center, ColorStyle.Transrarent, ColorStyle.Transrarent, ThicknessUnit.Default, Size2D.Default)
        {

        }

    }
}
