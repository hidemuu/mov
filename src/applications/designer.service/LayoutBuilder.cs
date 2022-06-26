using Mov.Designer.Models;
using Mov.Designer.Models.interfaces;
using Mov.Designer.Service.Layouts;
using Mov.Designer.Service.Layouts.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service
{
    public class LayoutBuilder
    {
        #region フィールド

        private readonly IDesignerRepositoryCollection repository;

        #endregion フィールド

        #region プロパティ

        public LayoutNodeBase Layout { get; private set; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutBuilder(IDesignerRepositoryCollection repository)
        {
            this.repository = repository;
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
            var node = new RootLayoutNode();
            CreateLayoutNode(node.Children, repository.LayoutTrees.Gets());
            return node;
        }

        private void CreateLayoutNode(ICollection<LayoutNodeBase> nodes, IEnumerable<LayoutTree> trees)
        {
            LayoutNodeBase node;
            foreach (var tree in trees)
            {
                switch (tree.LayoutNodeType)
                {
                    case LayoutNodeType.Root:
                        node = new RootLayoutNode(tree);
                        break;
                    case LayoutNodeType.Content:
                        ContentTable content = new ContentTable();
                        foreach(var table in repository.ContentTables.Gets())
                        {
                            if (!tree.Code.Equals(table.Code, StringComparison.OrdinalIgnoreCase)) continue;
                            content = table;
                            break;
                        }
                        node = new ContentLayoutNode(tree, content);
                        break;
                    case LayoutNodeType.Expander:
                        node = new ExpanderLayoutNode(tree);
                        break;
                    case LayoutNodeType.Scrollbar:
                        node = new ScrollbarLayoutNode(tree);
                        break;
                    case LayoutNodeType.Tab:
                        node = new TabLayoutNode(tree);
                        break;
                    default:
                        node = new ContentLayoutNode();
                        break;
                }
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
