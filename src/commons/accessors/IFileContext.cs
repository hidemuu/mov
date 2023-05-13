using Mov.Schemas.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    /// <summary>
    /// ファイルのコンテキスト
    /// </summary>
    public interface IFileContext
    {
        /// <summary>
        /// ファイルパス
        /// </summary>
        FileUnit FileUnit { get; }

        /// <summary>
        /// エンコード
        /// </summary>
        Encoding Encoding { get; }
    }
}
