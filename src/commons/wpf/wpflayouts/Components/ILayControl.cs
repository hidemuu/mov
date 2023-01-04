using Mov.Layouts;
using Mov.Layouts.Contexts.Contents;
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

        LayoutContentStatus LayoutParameter { get; set; }

        LayoutContentArrange LayoutDesign { get; set; }

        LayoutContentSchema LayoutValue { get; set; }
    }
}
