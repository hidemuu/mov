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

        private PathValue endpoint;

        private EncodingValue encoding;

        #endregion field

        #region constructor

        public FileSerializerFactory(PathValue endpoint, EncodingValue encoding)
        {
            this.endpoint = endpoint;
            this.encoding = encoding;
        }

        public FileSerializerFactory(PathValue endpoint) : this(endpoint, EncodingValue.UTF8)
        {
        }

        public FileSerializerFactory(string path) : this(new PathValue(path))
        {
        }

        #endregion constructor

        #region method

        public IFileSerializer Create(AccessType accessType)
        {
            if (accessType.IsJson())
            {
                return new JsonSerializer(endpoint, encoding);
            }
            else if (accessType.IsXml())
            {
                return new XmlSerializer(endpoint, encoding);
            }
            else if (accessType.IsCsv())
            {
                return new CsvSerializer(endpoint, encoding);
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