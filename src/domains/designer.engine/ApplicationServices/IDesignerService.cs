using Mov.Designer.Models.Persistences;
using Mov.Layouts;
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

        IEnumerable<LayoutNode> GetNodeModels();

        LayoutNode GetNodeModel(RegionType type);

        #endregion UIモデル

        #region クエリ

        void Read();

        IEnumerable<Node> GetNodes();

        Node GetNode(Guid id);

        Node GetNode(string code);

        IEnumerable<Content> GetContents();

        Content GetContent(Guid id);

        Content GetContent(string code);

        IEnumerable<Shell> GetShells();

        Shell GetShell(RegionType type);

        #endregion クエリ

        #region コマンド

        void Write();

        void PostNodes(IEnumerable<Node> items);

        void PostNode(Node item);

        void PutNode(Node item);

        void DeleteNode(Node item);

        void PostContents(IEnumerable<Content> items);

        void PostContent(Content item);

        void PutContent(Content item);

        void DeleteContent(Content item);

        void PostShells(IEnumerable<Shell> items);

        void PostShell(Shell item);

        void PutShell(Shell item);

        void DeleteShell(Shell item);


        #endregion コマンド

        #endregion メソッド

    }
}
