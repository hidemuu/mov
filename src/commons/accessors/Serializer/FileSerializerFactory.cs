using Mov.Accessors.Serializer.Implements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Mov.Accessors.Serializer
{
    public class FileSerializerFactory
    {
        #region フィールド

        private readonly IFileContext _context;

        #endregion フィールド

        #region コンストラクター

        public FileSerializerFactory(IFileContext context) 
        {
            _context = context;
        }

        #endregion コンストラクター

        #region メソッド

        public ISerializer Create(string extension)
        {
            if (string.IsNullOrEmpty(extension)) Debug.Assert(false, "拡張子が含まれていません");
            switch (extension)
            {
                case AccessConstants.PATH_EXTENSION_JSON:
                    return new JsonSerializer(_context.Endpoint.Path, _context.Encoding.ToString());
                case AccessConstants.PATH_EXTENSION_XML:
                    return new XmlSerializer(_context.Endpoint.Path, _context.Encoding.ToString());
                case AccessConstants.PATH_EXTENSION_CSV:
                    return new CsvSerializer(_context.Endpoint.Path, _context.Encoding.ToString());
                default:
                    Debug.Assert(false, "拡張子が不正です");
                    return null;
            }
        }

        #endregion メソッド
    }
}
