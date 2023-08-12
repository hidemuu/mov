using Moq;
using Mov.Core.Accessors.Services.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Repositories.Test.Builders
{
    public class RepositorySerializerBuilder
    {
        #region field

        private readonly Mock<ISerializer> mockSerializer;

        #endregion field

        #region constructor

        public RepositorySerializerBuilder() 
        {
            mockSerializer = new Mock<ISerializer>();
        }

        #endregion constructor

        #region method

        public ISerializer Build()
        {
            return mockSerializer.Object;
        }

        #endregion method
    }
}
