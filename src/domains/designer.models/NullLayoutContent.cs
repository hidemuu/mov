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

        public ILayoutKey LayoutKey { get; set; } = new LayoutContentKey();
        public ILayoutParameter LayoutParameter { get; set; } = new LayoutContentParameter();
        public ILayoutDesign LayoutDesign { get; set; } = new LayoutContentDesign();
        public ILayoutValue LayoutValue { get; set; } = new LayoutContentValue();
    }
}
