using Moq;
using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;
using Mov.Designer.Repository;
using System;
using System.Collections.Generic;

namespace Mov.Designer.Test.Builders
{
    public class DesignerRepositoryBuilder
    {
        #region field

        private readonly IDesignerRepository repository;
        private readonly Mock<IDesignerRepository> mockRepository;
        private readonly Mock<IDbRepository<ContentSchema, Guid, DbRequestSchemaString>> mockContent;

        #endregion field

        #region constructor

        public DesignerRepositoryBuilder()
        {
            mockRepository = new Mock<IDesignerRepository>();
            mockContent = new Mock<IDbRepository<ContentSchema, Guid, DbRequestSchemaString>>();
            repository = new FileDesignerRepository("", FileType.Empty, EncodingValue.Empty);
        }

        #endregion constructor

        #region method

        public IDesignerRepository Build() => repository;

        public DesignerRepositoryBuilder WithContentCalled(List<ContentSchema> contents)
        {
            var mockRepositoryContent = new Mock<IDbRepository<ContentSchema, Guid, DbRequestSchemaString>>();
            mockRepositoryContent.Setup(x => x.GetsAsync()).ReturnsAsync(contents);
            mockRepositoryContent.Setup(x => x.PostAsync(new ContentSchema()));
            mockRepositoryContent.Setup(x => x.DeleteAsync(new ContentSchema()));
            mockRepository.Setup(x => x.Contents).Returns(mockRepositoryContent.Object);

            return this;
        }

        public DesignerRepositoryBuilder WithNodeCalled(List<NodeSchema> nodes)
        {
            var mockNode = new Mock<IDbRepository<NodeSchema, Guid, DbRequestSchemaString>>();
            mockNode.Setup(x => x.GetsAsync()).ReturnsAsync(nodes);
            mockNode.Setup(x => x.PostAsync(new NodeSchema()));
            mockNode.Setup(x => x.DeleteAsync(new NodeSchema()));
            mockRepository.Setup(x => x.Nodes).Returns(mockNode.Object);
            return this;
        }

        #endregion method
    }
}