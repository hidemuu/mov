using Mov.Designer.Models;
using Mov.Designer.Service.Nodes;
using Reactive.Bindings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service
{
    public abstract class LayoutNodeBase : LayoutBase
    {
        #region フィールド

        private readonly LayoutNode node;

        /// <summary>
        /// 子階層
        /// </summary>
        private List<LayoutNodeBase> children = new List<LayoutNodeBase>();

        #endregion フィールド

        #region プロパティ

        /// <summary>
        /// 配置方向
        /// </summary>
        public OrientationType OrientationType => node.OrientationType;

        /// <summary>
        /// レイアウトスタイル
        /// </summary>
        public string LayoutStyle => node.Style;

        /// <summary>
        /// 開閉状態
        /// </summary>
        public ReactivePropertySlim<bool> IsExpand { get; } = new ReactivePropertySlim<bool>(true);

        /// <summary>
        /// 表示状態
        /// </summary>
        public ReactivePropertySlim<bool> IsVisible { get; } = new ReactivePropertySlim<bool>(true);

        /// <summary>
        /// 活性状態
        /// </summary>
        public ReactivePropertySlim<bool> IsEnable { get; } = new ReactivePropertySlim<bool>(true);

        /// <summary>
        /// 子階層
        /// </summary>
        public List<LayoutNodeBase> Children => children;

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutNodeBase() : base()
        {
            this.node = new LayoutNode();
        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="node"></param>
        /// <param name="content"></param>
        public LayoutNodeBase(LayoutNode node, LayoutContent content) : base(content)
        {
            this.node = node;
            IsExpand.Value = node.IsExpand;
            IsVisible.Value = node.IsVisible;
            IsEnable.Value = node.IsEnable;
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
