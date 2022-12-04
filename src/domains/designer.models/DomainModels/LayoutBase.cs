using Mov.Designer.Models;
using Mov.Layouts;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public abstract class LayoutBase
    {
        #region フィールド

        public LayoutContent Content { get; }

        #endregion フィールド

        #region プロパティ

        

        /// <summary>
        /// インデント
        /// </summary>
        public ReactivePropertySlim<double> Indent { get; } = new ReactivePropertySlim<double>();

        /// <summary>
        /// 値
        /// </summary>
        public ReactivePropertySlim<string> Value { get; } = new ReactivePropertySlim<string>();

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutBase()
        {
            this.Content = new LayoutContent();
        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="content"></param>
        public LayoutBase(LayoutContent content)
        {
            this.Content = content;
        }

        #endregion コンストラクター

        #region メソッド

        public override string ToString()
        {
            return "[Code] " + Content.Code + " [Name] " + Content.Name;
        }

        #endregion メソッド

    }
}
