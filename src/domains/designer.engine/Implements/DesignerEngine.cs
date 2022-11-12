using Mov.Designer.Models;
using Mov.Designer.Models.Nodes;
using Mov.Designer.Models.Parameters;
using System;
using System.Collections.Generic;

namespace Mov.Designer.Engine
{
    public class DesignerEngine : IDesignerEngine
    {
        #region フィールド

        private readonly IDesignerParameter parameter;

        private readonly LayoutNodeFactory factory;

        #endregion フィールド

        #region プロパティ

        public IEnumerable<LayoutNodeBase> Nodes { get; private set; }

        public LayoutNodeBase CenterNode { get; private set; }

        public LayoutNodeBase TopNode { get; private set; }

        public LayoutNodeBase BottomNode { get; private set; }

        public LayoutNodeBase LeftNode { get; private set; }

        public LayoutNodeBase RightNode { get; private set; }

        #endregion プロパティ

        #region コンストラクター

        public DesignerEngine(IDesignerParameter parameter)
        {
            this.parameter = parameter;
            this.factory = new LayoutNodeFactory(parameter.Query);
            Build();
        }

        #endregion コンストラクター

        #region メソッド

        public void Build()
        {
            Nodes = CreateNodes();
            foreach (var node in Nodes)
            {
                if (node is RegionLayoutNode regionNode)
                {
                    switch (regionNode.Content.Code)
                    {
                        case "Center": CenterNode = regionNode; break;
                        case "Top": TopNode = regionNode; break;
                        case "Bottom": BottomNode = regionNode; break;
                        case "Left": LeftNode = regionNode; break;
                        case "Right": RightNode = regionNode; break;
                    }
                }
            }
        }

        public Shell GetShell(LocationType type)
        {
            return this.parameter.Query.Shell.Get(type.ToString());
        }

        #endregion メソッド

        #region 内部メソッド

        private IEnumerable<LayoutNodeBase> CreateNodes()
        {
            var node = new ContentLayoutNode();
            CreateLayoutNode(node.Children, this.parameter.Query.LayoutNode.Gets());
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
