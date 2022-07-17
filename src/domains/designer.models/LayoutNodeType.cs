using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    /// <summary>
    /// ノード種別
    /// </summary>
    public enum LayoutNodeType
    {
        /// <summary>
        /// ルート
        /// </summary>
        Root,
        /// <summary>
        /// コンテンツ
        /// </summary>
        Content,
        /// <summary>
        /// エキスパンダー
        /// </summary>
        Expander,
        /// <summary>
        /// スクロールビュー
        /// </summary>
        Scrollbar,
        /// <summary>
        /// タブ
        /// </summary>
        Tab,
        /// <summary>
        /// テーブル
        /// </summary>
        Table,
        /// <summary>
        /// ツリー
        /// </summary>
        Tree,
    }
}
