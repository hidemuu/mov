using Mov.Layouts;
using Mov.Layouts.Contents;
using Mov.Layouts.Contents.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.WpfLayouts.Components
{
    public interface ILayControl
    {
        LayoutContentKey LayoutKey { get; set; }

        LayoutContentParameter LayoutParameter { get; set; }

        LayoutContentDesign LayoutDesign { get; set; }

        LayoutContentValue LayoutValue { get; set; }
    }
}
