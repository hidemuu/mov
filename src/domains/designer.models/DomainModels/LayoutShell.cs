using Mov.Layouts;
using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.DomainModels
{
    public class LayoutShell : ILayoutShell
    {
        public ShellRegion Region { get; }

        public LayoutShell(Shell shell)
        {

        }

    }
}
