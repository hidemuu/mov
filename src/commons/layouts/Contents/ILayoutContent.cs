﻿using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Layouts
{
    /// <summary>
    /// コンテンツ
    /// </summary>
    public interface ILayoutContent
    {
        /// <summary>
        /// コード
        /// </summary>
        ContentCode Code { get; }

        /// <summary>
        /// 名称
        /// </summary>
        ContentName Name { get; }

        /// <summary>
        /// コントロールタイプ
        /// </summary>
        ContentControlType ControlType { get; }

        /// <summary>
        /// アイコン
        /// </summary>
        ContentIcon Icon { get; }

        /// <summary>
        /// インデックス
        /// </summary>
        ContentIndent Indent { get; }

        /// <summary>
        /// 幅
        /// </summary>
        ContentWidth Width { get; }

        /// <summary>
        /// 表示状態
        /// </summary>
        ContentVisibility Visibility { get; }

        /// <summary>
        /// 活性状態
        /// </summary>
        ContentEnable Enable { get; }

        /// <summary>
        /// 方向
        /// </summary>
        ContentOrientation Orientation { get; }

        /// <summary>
        /// 水平位置
        /// </summary>
        ContentHorizontalAlignment HorizontalAlignment { get; }

        /// <summary>
        /// 垂直位置
        /// </summary>
        ContentVerticalAlignment VerticalAlignment { get; }

        /// <summary>
        /// 高さ
        /// </summary>
        ContentHeight Height { get; }

        /// <summary>
        /// コントロールのスキーマ
        /// </summary>
        ContentSchema Schema { get; }

        /// <summary>
        /// 値
        /// </summary>
        ContentValue ContentValue { get; }

        /// <summary>
        /// マクロ
        /// </summary>
        ContentMacro Macro { get; }

        /// <summary>
        /// パラメータ
        /// </summary>
        ContentParameter Parameter { get; }
    }
}