using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Services.Connectors
{
    /// <summary>
    /// ファイルアクセス処理
    /// </summary>
    public interface IFiler
    {
        void Upload(string fileName);
    }
}
