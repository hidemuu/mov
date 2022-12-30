using Mov.Layouts;
using Mov.Layouts.ValueObjects;
using Mov.Schemas.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.DomainModels
{
    public class DesignLayoutShell : ILayoutShell
    {
        public RegionStyle Region { get; }

        public DesignLayoutShell(Shell shell)
        {

        }

    }
}
