using Mov.Designer.Models;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service
{
    public abstract class LayoutBase
    {
        #region プロパティ

        /// <summary>
        /// コード
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public ReactivePropertySlim<string> Name { get; } = new ReactivePropertySlim<string>();

        /// <summary>
        /// 並び順インデックス
        /// </summary>
        public ReactivePropertySlim<int> Index { get; } = new ReactivePropertySlim<int>();

        /// <summary>
        /// レイアウトスタイル
        /// </summary>
        public string LayoutStyle { get; set; }

        /// <summary>
        /// インデント
        /// </summary>
        public ReactivePropertySlim<double> Indent { get; } = new ReactivePropertySlim<double>();

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutBase()
        {

        }

        #endregion コンストラクター

        #region メソッド

        public override string ToString()
        {
            return "[Code] " + Code + " [Name] " + Name;
        }

        #endregion メソッド

    }
}
