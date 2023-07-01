using Mov.Core.Layouts.Models.Contents.Entities;
using Mov.Core.Layouts.Models.Nodes.Entities;
using Mov.Core.Layouts.Models.Shells.Entities;
using Mov.Core.Layouts.Models.Shells.ValueObjects;
using Mov.Core.Layouts.Models.Themes.Entities;
using Mov.Core.Models.ValueObjects.Keys;
using System.Collections.Generic;

namespace Mov.Core.Layouts
{
    public interface ILayoutEngine
    {
        #region プロパティ

        CodeKey DomainId { get; }

        #endregion プロパティ

        #region メソッド

        void Build(ILayoutContext context);

        IEnumerable<LayoutNode> GetNodes();

        LayoutNode GetRegionNode(RegionStyle region);

        IEnumerable<LayoutContent> GetContents();

        IEnumerable<LayoutShell> GetShells();

        LayoutShell GetRegionShell(RegionStyle region);

        IEnumerable<LayoutTheme> GetThemes();

        #endregion メソッド

    }
}
