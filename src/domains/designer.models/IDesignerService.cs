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

        IEnumerable<LayoutNode> GetNodes();

        IEnumerable<LayoutContent> GetContents();

        LayoutNode GetNode(Guid id);

        LayoutContent GetContent(Guid id);

        LayoutNode GetNode(string code);

        LayoutContent GetContent(string code);

        Shell GetShell(RegionType type);

        #endregion クエリ

        #region コマンド

        void Write();

        void PostNodes(IEnumerable<LayoutNode> items);

        void PostContents(IEnumerable<LayoutContent> items);

        void PostNode(LayoutNode item);

        void PostContent(LayoutContent item);

        void PutNode(LayoutNode item);

        void PutContent(LayoutContent item);

        void DeleteNode(LayoutNode item);

        void DeleteContent(LayoutContent item);

        #endregion コマンド

        #endregion メソッド

    }
}
