﻿using Mov.Designer.Models;
using Mov.Designer.Service.Nodes;
using Reactive.Bindings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service
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
        /// レイアウトタイプ
        /// </summary>
        public abstract LayoutNodeType LayoutNodeType { get; }

        /// <summary>
        /// 配置方向
        /// </summary>
        public OrientationType OrientationType { get; } = OrientationType.Horizontal;

        /// <summary>
        /// 開閉状態
        /// </summary>
        public ReactivePropertySlim<bool> IsExpand { get; } = new ReactivePropertySlim<bool>(true);

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
        public LayoutNodeBase(LayoutNode tree)
        {
            Code = tree.Code;
            Name.Value = tree.Code;
            IsExpand.Value = tree.IsExpand;
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

        public override string ToString()
        {
            return base.ToString() + " [NodeType] " + LayoutNodeType.ToString();
        }

        #endregion メソッド

        #region 内部メソッド

        #endregion 内部メソッド
    }
}