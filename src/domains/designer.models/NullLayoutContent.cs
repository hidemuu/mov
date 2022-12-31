using Mov.Layouts;
using Mov.Layouts.Contents;
using Mov.Layouts.Contents.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class NullLayoutContent
    {

        public LayoutContentKey LayoutKey { get; set; } = LayoutContentKey.Default;
        public LayoutContentParameter LayoutParameter { get; set; } = LayoutContentParameter.Empty;
        public LayoutContentDesign LayoutDesign { get; set; } = LayoutContentDesign.Empty;
        public LayoutContentValue LayoutValue { get; set; } = LayoutContentValue.Empty;
    }
}
