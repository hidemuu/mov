using Mov.Schemas.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Contexts
{
    public class FileContext : IFileContext
    {
        #region プロパティ

        public FileUnit FileUnit { get; }

        public Encoding Encoding { get; }

        #endregion プロパティ

        #region コンストラクター

        public FileContext(string path, string encodeName = AccessConstants.ENCODE_NAME_UTF8)
        {
            this.FileUnit = new FileUnit(path);
            this.Encoding = Encoding.GetEncoding(encodeName);
        }

        #endregion コンストラクター
    }
}
