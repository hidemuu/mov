using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contents.ValueObjects
{
    public interface ILayoutValue
    {
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
    }
}
