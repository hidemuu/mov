using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    /// <summary>
    /// ノード種別
    /// </summary>
    public enum NodeType
    {
        /// <summary>
        /// コンテンツ
        /// </summary>
        Content,
        /// <summary>
        /// グループ
        /// </summary>
        Group,
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
