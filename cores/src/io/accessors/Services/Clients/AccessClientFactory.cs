using Mov.Core.Accessors.Models;
using Mov.Core.Accessors.Services.Clients.Implements;
using Mov.Core.Accessors.Services.Serializer;
using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Accessors.Services.Clients
{
    public class AccessClientFactory
    {
        #region field

        private PathValue endpoint;

        private EncodingValue encoding;

        #endregion field

        #region constructor

        public AccessClientFactory(PathValue endpoint, EncodingValue encoding) 
        {
            this.endpoint = endpoint;
            this.encoding = encoding;
        }

        public AccessClientFactory(PathValue endpoint) : this(endpoint, EncodingValue.UTF8)
        {
        }

        #endregion constructor

        #region method

        public IAccessClient Create(AccessType accessType)
        {
            var serializer = new SerializerFactory(this.endpoint, this.encoding).Create(accessType);
            if (accessType.IsFile())
            {
                return new FileAccessClient(serializer);
            }
            else if (accessType.IsWeb())
            {
                return new WebAccessClient(this.endpoint, this.encoding);
            }
            return null;
        }

        #endregion method

    }
}
