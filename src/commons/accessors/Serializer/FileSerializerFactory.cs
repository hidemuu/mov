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
        #region field

        private readonly IFileAccessContext context;

        #endregion field

        #region constructor

        public FileSerializerFactory(IFileAccessContext context) 
        {
            this.context = context;
        }

        #endregion constructor

        #region method

        public ISerializer Create(string extension)
        {
            if (string.IsNullOrEmpty(extension)) Debug.Assert(false, "拡張子が含まれていません");
            switch (extension)
            {
                case AccessConstants.PATH_EXTENSION_JSON:
                    return new JsonSerializer(this.context);
                case AccessConstants.PATH_EXTENSION_XML:
                    return new XmlSerializer(this.context);
                case AccessConstants.PATH_EXTENSION_CSV:
                    return new CsvSerializer(this.context);
                default:
                    Debug.Assert(false, "拡張子が不正です");
                    return null;
            }
        }

        #endregion method
    }
}
