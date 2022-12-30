using Mov.Designer.Models;
using Mov.Designer.Models.Parameters;
using Mov.Designer.Models.Persistences;
using Mov.Layouts;
using Mov.Layouts.Nodes.ValueObjects;
using Mov.Layouts.ValueObjects;
using Mov.Schemas.Styles;
using System;
using System.Collections.Generic;

namespace Mov.Designer.Engine
{
    public class DesignerEngine : IDesignerEngine
    {
        #region フィールド

        private string endpoint;

        private readonly IDesignerRepository repository;

        private readonly IDesignerCommand command;

        private readonly IDesignerQuery query;

        private readonly LayoutNodeFactory factory;

        private IEnumerable<DesignLayoutNode> nodes;

        #endregion フィールド

        #region プロパティ

        public int DomainId { get; }

        #region UIモデル
        public DesignLayoutNode CenterNode { get; private set; }

        public DesignLayoutNode TopNode { get; private set; }

        public DesignLayoutNode BottomNode { get; private set; }

        public DesignLayoutNode LeftNode { get; private set; }

        public DesignLayoutNode RightNode { get; private set; }

        #endregion UIモデル

        #endregion プロパティ

        #region コンストラクター

        public DesignerEngine(IDesignerContext parameter, int domainId)
        {
            this.DomainId = domainId;
            this.endpoint = parameter.EndPoint;
            this.repository = parameter.Repository;
            this.query = parameter.Query;
            this.command = parameter.Command;
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
                    var region = new RegionStyle(node.LayoutKey.Code.Value);
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
            this.repository.Nodes.Read();
            this.repository.Contents.Read();
            this.repository.Shells.Read();
        }

        public IEnumerable<Node> GetNodes()
        {
            //return this.repository.Nodes.Get();
            return this.query.Nodes.Reader.ReadAll();
        }

        public Node GetNode(Guid id)
        {
            return this.repository.Nodes.Get(id);
        }

        public IEnumerable<Content> GetContents()
        {
            return this.repository.Contents.Get();
        }

        public Content GetContent(Guid id)
        {
            return this.repository.Contents.Get(id);
        }

        public Content GetContent(string code)
        {
            return this.repository.Contents.Get(code);
        }

        public IEnumerable<Shell> GetShells()
        {
            return this.repository.Shells.Get();
        }

        public Shell GetShell(RegionStyle region)
        {
            return this.repository.Shells.Get(region.Value);
        }
        public void Write()
        {
            this.repository.Nodes.Write();
            this.repository.Contents.Write();
            this.repository.Shells.Write();
        }

        public void PostNodes(IEnumerable<Node> items)
        {
            this.repository.Nodes.Posts(items);
        }

        public void DeleteNode(Node item)
        {
            this.repository.Nodes.Delete(item);
        }

        public void PostContents(IEnumerable<Content> items)
        {
            this.repository.Contents.Posts(items);
        }

        public void DeleteContent(Content item)
        {
            this.repository.Contents.Delete(item);
        }

        public void PostShells(IEnumerable<Shell> items)
        {
            this.repository.Shells.Posts(items);
        }

        public void PostShell(Shell item)
        {
            this.repository.Shells.Post(item);
        }


        public void DeleteShell(Shell item)
        {
            this.repository.Shells.Delete(item);
        }


        #endregion メソッド

        #region 内部メソッド

        private IEnumerable<DesignLayoutNode> CreateNodes()
        {
            var node = new DesignLayoutNode();
            var data = this.repository?.Nodes?.Get();
            if (data == null) return default;
            CreateLayoutNode(node.Children, data);
            return node.Children;
        }

        private void CreateLayoutNode(ICollection<DesignLayoutNode> nodes, IEnumerable<Node> repositoryNodes)
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
