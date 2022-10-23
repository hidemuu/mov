using Mov.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.WpfLayouts.Components
{
    public interface ILayControl
    {
        ILayoutContent LayoutContent { get; set; }
    }
}
