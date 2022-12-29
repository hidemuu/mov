using Mov.Layouts;
using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class NullLayoutContent : ILayoutContent
    {

        public ILayoutKey LayoutKey { get; set; } = new DesignLayoutContentKey();
        public ILayoutParameter LayoutParameter { get; set; } = new DesignLayoutContentParameter();
        public ILayoutDesign LayoutDesign { get; set; } = new DesignLayoutContentDesign();
        public ILayoutValue LayoutValue { get; set; } = new DesignLayoutContentValue();
    }
}
