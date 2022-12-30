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

        public LayoutKey LayoutKey { get; set; } = LayoutKey.Default;
        public LayoutParameter LayoutParameter { get; set; } = LayoutParameter.Empty;
        public LayoutDesign LayoutDesign { get; set; } = LayoutDesign.Empty;
        public LayoutValue LayoutValue { get; set; } = LayoutValue.Empty;
    }
}
