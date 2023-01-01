using Mov.Layouts;
using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.Contexts.Contents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class NullLayoutContent
    {

        public LayoutContentKey LayoutKey { get; set; } = LayoutContentKey.Default;
        public LayoutContentStatus LayoutParameter { get; set; } = LayoutContentStatus.Empty;
        public LayoutContentDesign LayoutDesign { get; set; } = LayoutContentDesign.Empty;
        public LayoutContentSchema LayoutValue { get; set; } = LayoutContentSchema.Empty;
    }
}
