using Mov.Core.Accessors.Models;
using Mov.Core.Accessors.Services.Serializer.Implements;
using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mov.Core.Accessors.Services.Serializer
{
    public class SerializerFactory
    {
        #region field

        private PathValue endpoint;

        private EncodingValue encoding;

        #endregion field

        #region constructor

        public SerializerFactory(PathValue endpoint, EncodingValue encoding) 
        {
            this.endpoint = endpoint;
            this.encoding = encoding;
        }

        public SerializerFactory(PathValue endpoint) : this(endpoint, EncodingValue.UTF8) 
        {
        }

        public SerializerFactory(string path) : this(new PathValue(path)) 
        {
        }

        #endregion constructor

        #region method

        public ISerializer Create(AccessType accessType)
        {
            if (accessType.IsJson())
            {
                return new JsonSerializer(this.endpoint, this.encoding);
            }
            else if (accessType.IsXml())
            {
                return new XmlSerializer(this.endpoint, this.encoding);
            }
            else if (accessType.IsCsv())
            {
                return new CsvSerializer(this.endpoint, this.encoding);
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
