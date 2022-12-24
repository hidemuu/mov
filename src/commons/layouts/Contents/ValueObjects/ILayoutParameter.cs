using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contents.ValueObjects
{
    public interface ILayoutParameter
    {
        /// <summary>
        /// 名称
        /// </summary>
        ContentName Name { get; }

        /// <summary>
        /// アイコン
        /// </summary>
        ContentIcon Icon { get; }

        /// <summary>
        /// 表示状態
        /// </summary>
        ContentVisibility Visibility { get; }

        /// <summary>
        /// 活性状態
        /// </summary>
        ContentEnable Enable { get; }

        /// <summary>
        /// パラメータ
        /// </summary>
        ContentParameter Parameter { get; }
    }
}
