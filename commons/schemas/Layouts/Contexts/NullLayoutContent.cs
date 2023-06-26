using Mov.Layouts;
using Mov.Layouts.Contexts.Contents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contexts
{
    public class NullLayoutContent
    {

        public LayoutContentKey LayoutKey { get; } = LayoutContentKey.Default;
        public LayoutContentStatus LayoutParameter { get; } = LayoutContentStatus.Empty;
        public LayoutContentArrange LayoutDesign { get; } = LayoutContentArrange.Empty;
        public LayoutContentSchema LayoutValue { get; } = LayoutContentSchema.Empty;
    }
}
