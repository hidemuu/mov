using Mov.Designer.Models;
using Mov.Designer.Service.Layouts.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service.Layouts
{
    public abstract class LayoutNodeBase : LayoutBase, IEnumerable<LayoutNodeBase>
    {
        #region フィールド

        /// <summary>
        /// 子階層
        /// </summary>
        private List<LayoutNodeBase> children = new List<LayoutNodeBase>();

        #endregion フィールド

        #region プロパティ

        /// <summary>
        /// 開閉状態
        /// </summary>
        public bool IsExpand { get; set; } = true;

        /// <summary>
        /// 子階層
        /// </summary>
        public List<LayoutNodeBase> Children => children;

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutNodeBase()
        {

        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutNodeBase(LayoutTree tree)
        {
            Code = tree.Code;
            Name = tree.Code;
            IsExpand = tree.IsExpand;
            LayoutType = tree.LayoutType;
            LayoutStyle = tree.LayoutStyle;
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerator<LayoutNodeBase> GetEnumerator()
        {
            return (IEnumerator<LayoutNodeBase>)children;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(LayoutNodeBase layout)
        {
            children.Add(layout);
        }

        public void AddRange(IEnumerable<LayoutNodeBase> layouts)
        {
            children.AddRange(layouts);
        }

        #endregion メソッド

        #region 内部メソッド

        #endregion 内部メソッド
    }
}
