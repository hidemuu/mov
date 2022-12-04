using Mov.Designer.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerService
    {
        #region プロパティ

        #endregion プロパティ

        #region メソッド

        #region UIモデル

        IEnumerable<LayoutNodeBase> GetNodeModels();

        LayoutNodeBase GetNodeModel(RegionType type);

        #endregion UIモデル

        #region クエリ

        void Read();

        IEnumerable<LayoutNode> GetNodes();

        LayoutNode GetNode(Guid id);

        LayoutNode GetNode(string code);

        IEnumerable<LayoutContent> GetContents();

        LayoutContent GetContent(Guid id);

        LayoutContent GetContent(string code);

        IEnumerable<Shell> GetShells();

        Shell GetShell(RegionType type);

        #endregion クエリ

        #region コマンド

        void Write();

        void PostNodes(IEnumerable<LayoutNode> items);

        void PostNode(LayoutNode item);

        void PutNode(LayoutNode item);

        void DeleteNode(LayoutNode item);

        void PostContents(IEnumerable<LayoutContent> items);

        void PostContent(LayoutContent item);

        void PutContent(LayoutContent item);

        void DeleteContent(LayoutContent item);

        void PostShells(IEnumerable<Shell> items);

        void PostShell(Shell item);

        void PutShell(Shell item);

        void DeleteShell(Shell item);


        #endregion コマンド

        #endregion メソッド

    }
}
