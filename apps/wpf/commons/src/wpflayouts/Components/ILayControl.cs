using Mov.Layouts.Models.Entities.Contents;

namespace Mov.WpfLayouts.Components
{
    public interface ILayControl
    {
        LayoutContentKey LayoutKey { get; set; }

        LayoutContentStatus LayoutParameter { get; set; }

        LayoutContentArrange LayoutDesign { get; set; }

        LayoutContentSchema LayoutValue { get; set; }
    }
}