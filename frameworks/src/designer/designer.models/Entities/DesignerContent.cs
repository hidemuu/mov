using Mov.Core.Layouts.Models.Contents;

namespace Mov.Designer.Models.Entities
{
    public class DesignerContent : LayoutContent
    {
        public DesignerContent(LayoutContentKey keys, LayoutContentStatus statuses, LayoutContentArrange arranges, LayoutContentValue schemas)
            : base(keys, statuses, arranges, schemas)
        {
        }
    }
}
