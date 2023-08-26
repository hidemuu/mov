using Mov.Core.Accessors.Models;
using Mov.Core.Accessors.Services.Serializer.Implements;
using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using System.Diagnostics;

namespace Mov.Core.Accessors.Services.Serializer.FIles
{
    public class FileSerializerFactory
    {
        #region field

        private EncodingValue encoding;

        #endregion field

        #region constructor

        public FileSerializerFactory(EncodingValue encoding)
        {
            this.encoding = encoding;
        }

        public FileSerializerFactory() : this(EncodingValue.UTF8)
        {
        }

        #endregion constructor

        #region method

        public IFileSerializer Create(AccessType accessType)
        {
            if (accessType.IsJson())
            {
                return new JsonSerializer(encoding);
            }
            else if (accessType.IsXml())
            {
                return new XmlSerializer(encoding);
            }
            else if (accessType.IsCsv())
            {
                return new CsvSerializer(encoding);
            }
            else
            {
                Debug.Assert(false, "拡張子が不正です");
                return null;
            }
        }

        #endregion method
    }
}