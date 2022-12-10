using Mov.Designer.Models;
using Mov.Layouts;
using Mov.Layouts.ValueObjects;
using Reactive.Bindings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public abstract class LayoutNodeBase : LayoutContentBase
    {
        #region フィールド

        private readonly Node node;

        /// <summary>
        /// 子階層
        /// </summary>
        private List<LayoutNodeBase> children = new List<LayoutNodeBase>();

        #endregion フィールド

        #region プロパティ

        /// <summary>
        /// 子階層
        /// </summary>
        public List<LayoutNodeBase> Children => children;

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutNodeBase() : this(new Node(), new Content())
        {
            
        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="node"></param>
        /// <param name="content"></param>
        public LayoutNodeBase(Node node, Content content) : base(content)
        {
            this.node = node;
        }

        #endregion コンストラクター

        #region メソッド

        
        public void Add(LayoutNodeBase layout)
        {
            children.Add(layout);
        }

        public void AddRange(IEnumerable<LayoutNodeBase> layouts)
        {
            children.AddRange(layouts);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion メソッド

        #region 内部メソッド

        #endregion 内部メソッド
    }
}
