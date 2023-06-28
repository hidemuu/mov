using Mov.Layouts.Models.Entities.Contents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Models.Entities
{
    public class NullLayoutContent
    {

        public LayoutContentKey LayoutKey { get; } = LayoutContentKey.Default;
        public LayoutContentStatus LayoutParameter { get; } = LayoutContentStatus.Empty;
        public LayoutContentArrange LayoutDesign { get; } = LayoutContentArrange.Empty;
        public LayoutContentValue LayoutValue { get; } = LayoutContentValue.Empty;
    }
}
