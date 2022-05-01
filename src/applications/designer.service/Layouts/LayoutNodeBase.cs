using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service.Layouts
{
    public abstract class LayoutNodeBase : LayoutBase, IEnumerable<LayoutNodeBase>
    {
        #region フィールド

        private List<LayoutNodeBase> children = new List<LayoutNodeBase>();

        #endregion フィールド

        #region プロパティ

        public bool IsExpand { get; set; }

        public List<LayoutNodeBase> Children => children;

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutNodeBase()
        {

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
    }
}
