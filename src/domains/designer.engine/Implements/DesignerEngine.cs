using Mov.Designer.Models;
using Mov.Designer.Models.Parameters;
using Mov.Designer.Models.Persistences;
using Mov.Layouts.Nodes.ValueObjects;
using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;

namespace Mov.Designer.Engine
{
    public class DesignerEngine : IDesignerEngine
    {
        #region フィールド

        private readonly IDesignerParameter parameter;

        private readonly LayoutNodeFactory factory;

        private IEnumerable<LayoutNode> nodes;

        #endregion フィールド

        #region プロパティ

        public int DomainId { get; }

        #region クエリ・コマンド

        public IDesignerRepository Repository { get; }

        public IDesignerCommand Command { get; }

        public IDesignerQuery Query { get; }

        #endregion クエリ・コマンド

        #region UIモデル
        public LayoutNode CenterNode { get; private set; }

        public LayoutNode TopNode { get; private set; }

        public LayoutNode BottomNode { get; private set; }

        public LayoutNode LeftNode { get; private set; }

        public LayoutNode RightNode { get; private set; }

        #endregion UIモデル

        #endregion プロパティ

        #region コンストラクター

        public DesignerEngine(IDesignerParameter parameter, int domainId)
        {
            this.DomainId = domainId;
            this.parameter = parameter;
            this.Repository = parameter.Repository;
            this.Query = parameter.Query;
            this.Command = parameter.Command;
            this.factory = new LayoutNodeFactory(parameter.Repository);
            BuildNode();
        }

        #endregion コンストラクター

        #region メソッド

        public void BuildNode()
        {
            this.nodes = CreateNodes();
            if (this.nodes == null) return;
            foreach (var node in this.nodes)
            {
                if (node.NodeType.IsRegion)
                {
                    var region = new ShellRegion(node.Code.Value);
                    if (region.IsCenter) CenterNode = node;
                    if (region.IsTop) TopNode = node;
                    if (region.IsBottom) BottomNode = node;
                    if (region.IsLeft) LeftNode = node;
                    if (region.IsRight) RightNode = node;
                }
            }
        }

        public void Read()
        {
            this.Repository.Nodes.Read();
            this.Repository.Contents.Read();
            this.Repository.Shells.Read();
        }

        public IEnumerable<Node> GetNodes()
        {
            return this.Repository.Nodes.Get();
        }

        public Node GetNode(Guid id)
        {
            return this.Repository.Nodes.Get(id);
        }

        public IEnumerable<Content> GetContents()
        {
            return this.Repository.Contents.Get();
        }

        public Content GetContent(Guid id)
        {
            return this.Repository.Contents.Get(id);
        }

        public Content GetContent(string code)
        {
            return this.Repository.Contents.Get(code);
        }

        public IEnumerable<Shell> GetShells()
        {
            return this.Repository.Shells.Get();
        }

        public Shell GetShell(ShellRegion region)
        {
            return this.Repository.Shells.Get(region.Value);
        }
        public void Write()
        {
            this.Repository.Nodes.Write();
            this.Repository.Contents.Write();
            this.Repository.Shells.Write();
        }

        public void PostNodes(IEnumerable<Node> items)
        {
            this.Repository.Nodes.Posts(items);
        }

        public void DeleteNode(Node item)
        {
            this.Repository.Nodes.Delete(item);
        }

        public void PostContents(IEnumerable<Content> items)
        {
            this.Repository.Contents.Posts(items);
        }

        public void DeleteContent(Content item)
        {
            this.Repository.Contents.Delete(item);
        }

        public void PostShells(IEnumerable<Shell> items)
        {
            this.Repository.Shells.Posts(items);
        }

        public void PostShell(Shell item)
        {
            this.Repository.Shells.Post(item);
        }


        public void DeleteShell(Shell item)
        {
            this.Repository.Shells.Delete(item);
        }


        #endregion メソッド

        #region 内部メソッド

        private IEnumerable<LayoutNode> CreateNodes()
        {
            var node = new LayoutNode();
            var data = this.Repository?.Nodes?.Get();
            if (data == null) return default;
            CreateLayoutNode(node.Children, data);
            return node.Children;
        }

        private void CreateLayoutNode(ICollection<LayoutNode> nodes, IEnumerable<Node> repositoryNodes)
        {
            foreach (var repositoryNode in repositoryNodes)
            {
                var node = this.factory.Create(repositoryNode);
                nodes.Add(node);
                //子階層再帰処理
                if (repositoryNode.Children.Count > 0)
                {
                    CreateLayoutNode(node.Children, repositoryNode.Children);
                }
            }
        }

        #endregion 内部メソッド

    }
}
