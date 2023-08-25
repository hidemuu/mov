using Mov.Core.Accessors.Models;
using Mov.Core.Accessors.Services.Clients.Implements;
using Mov.Core.Accessors.Services.Serializer;
using Mov.Core.Accessors.Services.Serializer.FIles;
using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Accessors.Services.Clients
{
    public class ClientFactory
    {
        #region field

        private PathValue endpoint;

        private EncodingValue encoding;

        #endregion field

        #region constructor

        public ClientFactory(PathValue endpoint, EncodingValue encoding) 
        {
            this.endpoint = endpoint;
            this.encoding = encoding;
        }

        public ClientFactory(PathValue endpoint) : this(endpoint, EncodingValue.UTF8)
        {
        }

        #endregion constructor

        #region method

        public IClient Create(AccessType accessType)
        {
            var serializer = new FileSerializerFactory(this.endpoint, this.encoding).Create(accessType);
            if (accessType.IsFile())
            {
                return new FileClient(serializer);
            }
            else if (accessType.IsWeb())
            {
                return new WebClient(this.endpoint, this.encoding);
            }
            return null;
        }

        #endregion method

    }
}
