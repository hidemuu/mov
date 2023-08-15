using Mov.Core.Accessors.Models;
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

        #endregion constructor

        #region method

        public IAccessClient Create(AccessType accessType)
        {
            var serializer = new SerializerFactory(this.endpoint, this.encoding).Create(accessType);
            return null;
        }

        #endregion method

    }
}
