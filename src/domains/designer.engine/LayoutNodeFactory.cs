using Mov.Designer.Models;
using Mov.Designer.Models.Persistences;
using Mov.Layouts;
using Mov.Layouts.Contents;
using Mov.Layouts.Nodes.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Engine
{
    internal class LayoutNodeFactory
    {
        #region フィールド

        private readonly IDesignerRepository repository;

        #endregion フィールド

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutNodeFactory(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public DesignLayoutNode Create(Node node)
        {
            var content = GetContent(node);
            return new DesignLayoutNode(node, content);
        }

        #endregion メソッド

        #region 内部メソッド

        private Content GetContent(Node node)
        {
            return this.repository.Contents.Get(node.Code);
        }

        #endregion 内部メソッド

    }
}
