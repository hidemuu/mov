using Mov.Designer.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerEngine
    {
        #region プロパティ

        IDesignerCommand Command { get; }

        IDesignerQuery Query { get; }

        IEnumerable<LayoutNodeBase> Nodes { get; }

        LayoutNodeBase CenterNode { get; }

        LayoutNodeBase TopNode { get; }

        LayoutNodeBase BottomNode { get; }

        LayoutNodeBase LeftNode { get; }

        LayoutNodeBase RightNode { get; }

        #endregion プロパティ

        #region メソッド

        void BuildNode();

        void UpdateRepository(string repositoryName);

        #endregion メソッド
    }
}
