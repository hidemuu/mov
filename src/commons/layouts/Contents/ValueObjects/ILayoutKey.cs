using Mov.Layouts.ValueObjects;
using Mov.Schemas.Keys;
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
        CodeKey Code { get; }

        /// <summary>
        /// コントロールタイプ
        /// </summary>
        ContentControlType ControlType { get; }
    }
}
