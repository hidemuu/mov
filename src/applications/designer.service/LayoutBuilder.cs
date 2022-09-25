using Mov.Designer.Models;
using Mov.Designer.Service.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service
{
    public class LayoutBuilder
    {
        #region フィールド

        private readonly IDesignerRepository repository;
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
        public LayoutBuilder(IDesignerRepository repository)
        {
            this.repository = repository;
            this.factory = new LayoutNodeFactory(repository);
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
                    switch (regionNode.Code) 
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
            CreateLayoutNode(node.Children, repository.Nodes.Get());
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
