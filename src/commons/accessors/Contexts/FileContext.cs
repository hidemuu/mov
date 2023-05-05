using Mov.Schemas.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Contexts
{
    public class FileContext : IFileContext
    {
        #region プロパティ

        public FileUnit Endpoint { get; }

        public Encoding Encoding { get; }

        #endregion プロパティ

        #region コンストラクター

        public FileContext(string path)
        {
            this.Endpoint = new FileUnit(path);
            this.Encoding = Encoding.UTF8;
        }

        #endregion コンストラクター
    }
}
