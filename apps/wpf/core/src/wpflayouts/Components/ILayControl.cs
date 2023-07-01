using Mov.Core.Layouts.Models.Contents;

namespace Mov.WpfLayouts.Components
{
    public interface ILayControl
    {
        LayoutContentKey LayoutKey { get; set; }

        LayoutContentStatus LayoutParameter { get; set; }

        LayoutContentArrange LayoutDesign { get; set; }

        LayoutContentValue LayoutValue { get; set; }
    }
}