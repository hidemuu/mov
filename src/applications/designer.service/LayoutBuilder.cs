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

        private IDesignerRepositoryCollection repository;

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
            Layout = Import();
            return this;
        }

        #endregion メソッド

        #region 内部メソッド

        private LayoutNodeBase Import()
        {
            var node = new ContentLayout();
            foreach (var tree in repository.LayoutTrees.Gets())
            {
                switch (tree.LayoutType)
                {
                    case LayoutType.Content:
                        node.Add(new ContentLayout());
                        break;
                    case LayoutType.Expander:
                        node.Add(new ExpanderLayout());
                        break;
                    case LayoutType.Header:
                        node.Add(new HeaderLayout());
                        break;
                    case LayoutType.Scrollbar:
                        node.Add(new ScrollbarLayout());
                        break;
                    case LayoutType.Tab:
                        node.Add(new TabLayout());
                        break;
                    default:
                        node.Add(new ContentLayout());
                        break;
                }
            }
            return node;
        }

        #endregion 内部メソッド

    }
}
