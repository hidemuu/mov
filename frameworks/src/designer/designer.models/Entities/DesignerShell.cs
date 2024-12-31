using Mov.Core.Layouts.Models.Shells;
using Mov.Core.Styles.Models;
using Mov.Core.Valuables.Sizes;

namespace Mov.Designer.Models.Entities
{
    public class DesignerShell : LayoutShell
    {
        public DesignerShell(RegionStyle region, ColorStyle background, ColorStyle border, ThicknessValue thickness, Size2D size)
            : base(region, background, border, thickness, size)
        {
        }
    }
}
