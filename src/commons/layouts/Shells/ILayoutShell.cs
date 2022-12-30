using Mov.Layouts.ValueObjects;
using Mov.Schemas.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public interface ILayoutShell
    {
        RegionStyle Region { get; }
    }
}
