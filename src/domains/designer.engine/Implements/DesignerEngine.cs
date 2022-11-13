using Mov.Designer.Models;
using Mov.Designer.Models.Nodes;
using Mov.Designer.Models.Parameters;
using Mov.Designer.Models.Persistences;
using System;
using System.Collections.Generic;

namespace Mov.Designer.Engine
{
    public class DesignerEngine : IDesignerEngine
    {
        #region フィールド

        private readonly int domainId;

        private readonly IDesignerParameter parameter;

        private readonly LayoutNodeFactory factory;

        #endregion フィールド

        #region プロパティ

        #region クエリ・コマンド

        public IDesignerRepository Repository { get; }

        public IDesignerCommand Command { get; }

        public IDesignerQuery Query { get; }

        #endregion クエリ・コマンド

        #region UIモデル

        public IEnumerable<LayoutNodeBase> Nodes { get; private set; }

        public LayoutNodeBase CenterNode { get; private set; }

        public LayoutNodeBase TopNode { get; private set; }

        public LayoutNodeBase BottomNode { get; private set; }

        public LayoutNodeBase LeftNode { get; private set; }

        public LayoutNodeBase RightNode { get; private set; }

        #endregion UIモデル

        #endregion プロパティ

        #region コンストラクター

        public DesignerEngine(IDesignerParameter parameter)
        {
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
            Nodes = CreateNodes();
            foreach (var node in Nodes)
            {
                if (node is RegionLayoutNode regionNode)
                {
                    switch (regionNode.Content.Code)
                    {
                        case RegionLayoutNode.REGION_CENTER: CenterNode = regionNode; break;
                        case RegionLayoutNode.REGION_TOP: TopNode = regionNode; break;
                        case RegionLayoutNode.REGION_BOTTOM: BottomNode = regionNode; break;
                        case RegionLayoutNode.REGION_LEFT: LeftNode = regionNode; break;
                        case RegionLayoutNode.REGION_RIGHT: RightNode = regionNode; break;
                    }
                }
            }
        }

        public void UpdateRepository(string repositoryName)
        {
            this.parameter.UpdateRepository(repositoryName);
            BuildNode();
        }

        #endregion メソッド

        #region 内部メソッド

        private IEnumerable<LayoutNodeBase> CreateNodes()
        {
            var node = new ContentLayoutNode();
            CreateLayoutNode(node.Children, this.Repository.Nodes.Get());
            return node.Children;
        }

        private void CreateLayoutNode(ICollection<LayoutNodeBase> nodes, IEnumerable<LayoutNode> repositoryNodes)
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
