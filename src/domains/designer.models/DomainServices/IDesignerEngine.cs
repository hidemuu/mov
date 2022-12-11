using Mov.Designer.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerEngine
    {
        #region プロパティ

        IDesignerRepository Repository { get; }

        IDesignerCommand Command { get; }

        IDesignerQuery Query { get; }

        LayoutNode CenterNode { get; }

        LayoutNode TopNode { get; }

        LayoutNode BottomNode { get; }

        LayoutNode LeftNode { get; }

        LayoutNode RightNode { get; }

        #endregion プロパティ

        #region メソッド

        void BuildNode();

        void UpdateRepository(string repositoryName);

        #endregion メソッド
    }
}
