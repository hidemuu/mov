using Mov.Designer.Models;
using Mov.Designer.Models.Nodes;
using Mov.Designer.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Engine
{
    public class LayoutBuilder
    {
        #region フィールド

        private readonly IDesignerQuery query;
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

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutBuilder(IDesignerQuery query)
        {
            this.query = query;
            this.factory = new LayoutNodeFactory(query);
        }

        #endregion コンストラクター

        #region メソッド

        public LayoutBuilder Build()
        {
            Nodes = Create();
            foreach(var node in Nodes)
            {
                if(node is RegionLayoutNode regionNode)
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
            return this;
        }

        #endregion メソッド

        #region 内部メソッド

        private IEnumerable<LayoutNodeBase> Create()
        {
            var node = new ContentLayoutNode();
            CreateLayoutNode(node.Children, this.query.LayoutNode.Gets());
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
