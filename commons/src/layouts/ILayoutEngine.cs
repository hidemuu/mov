using Mov.Layouts.Models.Contents.Entities;
using Mov.Layouts.Models.Nodes.Entities;
using Mov.Layouts.Models.Shells.Entities;
using Mov.Layouts.Models.Shells.ValueObjects;
using Mov.Layouts.Models.Themes.Entities;
using Mov.Utilities.Models.ValueObjects.Keys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Mov.Layouts
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
