using Mov.Designer.Models;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service
{
    public abstract class LayoutBase
    {
        #region フィールド

        private readonly LayoutContent content;

        #endregion フィールド

        #region プロパティ

        /// <summary>
        /// コード
        /// </summary>
        public string Code => this.content.Code;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name => this.content.Name;

        /// <summary>
        /// コントロール種別
        /// </summary>
        public ControlType ControlType => this.content.ControlType;

        /// <summary>
        /// マクロ
        /// </summary>
        public string Macro => this.content.Macro;

        /// <summary>
        /// 並び順インデックス
        /// </summary>
        public int Index => this.content.Index;

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
            this.content = new LayoutContent();
        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="content"></param>
        public LayoutBase(LayoutContent content)
        {
            this.content = content;
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
