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

        public LayoutNodeBase Layout { get; private set; }

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
            Layout = Create();
            return this;
        }

        #endregion メソッド

        #region 内部メソッド

        private LayoutNodeBase Create()
        {
            var node = new ContentLayoutNode();
            CreateLayoutNode(node.Children, repository.Nodes.Gets());
            return node;
        }

        private void CreateLayoutNode(ICollection<LayoutNodeBase> nodes, IEnumerable<LayoutNode> trees)
        {
            foreach (var tree in trees)
            {
                var node = this.factory.Create(tree);
                nodes.Add(node);
                //子階層再帰処理
                if (tree.Children.Count > 0)
                {
                    CreateLayoutNode(node.Children, tree.Children);
                }
            }
        }

        #endregion 内部メソッド

    }
}
