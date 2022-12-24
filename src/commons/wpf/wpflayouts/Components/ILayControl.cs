using Mov.Layouts;
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
        ILayoutKey LayoutKey { get; set; }

        ILayoutParameter LayoutParameter { get; set; }

        ILayoutDesign LayoutDesign { get; set; }

        ILayoutValue LayoutValue { get; set; }
    }
}
