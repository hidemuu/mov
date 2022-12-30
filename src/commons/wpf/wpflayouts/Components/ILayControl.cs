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
        LayoutKey LayoutKey { get; set; }

        LayoutParameter LayoutParameter { get; set; }

        LayoutDesign LayoutDesign { get; set; }

        LayoutValue LayoutValue { get; set; }
    }
}
