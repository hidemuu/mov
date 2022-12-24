using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contents.ValueObjects
{
    public interface ILayoutDesign
    {
        /// <summary>
        /// インデックス
        /// </summary>
        ContentIndent Indent { get; }

        /// <summary>
        /// 幅
        /// </summary>
        ContentWidth Width { get; }

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
    }
}
