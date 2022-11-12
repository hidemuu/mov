using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerEngine
    {
        #region プロパティ

        IEnumerable<LayoutNodeBase> Nodes { get; }

        LayoutNodeBase CenterNode { get; }

        LayoutNodeBase TopNode { get; }

        LayoutNodeBase BottomNode { get; }

        LayoutNodeBase LeftNode { get; }

        LayoutNodeBase RightNode { get; }

        #endregion プロパティ

        #region メソッド

        Shell GetShell(LocationType type);

        #endregion メソッド
    }
}
