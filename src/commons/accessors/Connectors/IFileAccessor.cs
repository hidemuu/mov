using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Connectors
{
    /// <summary>
    /// ファイルアクセス処理
    /// </summary>
    public interface IFileAccessor
    {
        void Upload(string fileName);
    }
}
