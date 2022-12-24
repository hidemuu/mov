using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contents.ValueObjects
{
    public interface ILayoutKey
    {
        /// <summary>
        /// コード
        /// </summary>
        ContentCode Code { get; }

        /// <summary>
        /// コントロールタイプ
        /// </summary>
        ContentControlType ControlType { get; }
    }
}
