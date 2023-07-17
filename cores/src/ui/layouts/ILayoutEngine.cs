using Mov.Core.Layouts.Models.Contents;
using Mov.Core.Layouts.Models.Nodes;
using Mov.Core.Layouts.Models.Shells;
using Mov.Core.Layouts.Models.Themes;
using Mov.Core.Models.Identifiers;
using Mov.Core.Models.Styles;
using System.Collections.Generic;

namespace Mov.Core.Layouts
{
    public interface ILayoutEngine
    {
        #region プロパティ

        IdentifierCode DomainId { get; }

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
