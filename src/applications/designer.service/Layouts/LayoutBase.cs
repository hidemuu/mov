using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service.Layouts
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
        public string Name { get; set; }

        /// <summary>
        /// 並び順インデックス
        /// </summary>
        public int Index { get; set; } = 0;

        /// <summary>
        /// レイアウトタイプ
        /// </summary>
        public LayoutType LayoutType { get; set; } = LayoutType.Content;

        /// <summary>
        /// レイアウトスタイル
        /// </summary>
        public string LayoutStyle { get; set; }

        /// <summary>
        /// インデント
        /// </summary>
        public double Indent { get; set; } = 0;

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutBase()
        {

        }

        #endregion コンストラクター

    }
}
