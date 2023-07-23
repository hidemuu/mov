using Mov.Core.Accessors.Services.Serializer.Implements;
using System.Diagnostics;

namespace Mov.Core.Accessors.Services.Serializer
{
    public class FileSerializerFactory
    {
        #region field

        private readonly IFileService context;

        #endregion field

        #region constructor

        public FileSerializerFactory(IFileService context)
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
                    return new JsonSerializer(context);
                case AccessConstants.PATH_EXTENSION_XML:
                    return new XmlSerializer(context);
                case AccessConstants.PATH_EXTENSION_CSV:
                    return new CsvSerializer(context);
                default:
                    Debug.Assert(false, "拡張子が不正です");
                    return null;
            }
        }

        #endregion method
    }
}
