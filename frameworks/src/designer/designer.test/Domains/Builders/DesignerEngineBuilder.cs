using Moq;
using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;
using System.Collections.Generic;

namespace Mov.Designer.Test.Domains.Builders
{
    public class DesignerEngineBuilder
    {
        #region フィールド

        private readonly Mock<IDesignerRepository> mockRepository;
        private readonly Mock<IDesignerStoreQuery> mockQuery;
        private readonly Mock<IDesignerStoreCommand> mockCommand;

        #endregion フィールド

        #region コンストラクター

        public DesignerEngineBuilder()
        {
            //モックオブジェクト生成
            mockRepository = new Mock<IDesignerRepository>();
            mockQuery = new Mock<IDesignerStoreQuery>();
            mockCommand = new Mock<IDesignerStoreCommand>(); ;
            //インスタンス生成
            //this.engine = new DesignerEngine(this.mockContext.Object, 0);
        }

        #endregion コンストラクター

        #region メソッド

        public DesignerEngineBuilder WithContentCalled(List<ContentSchema> contents)
        {
            var mockRepositoryContent = new Mock<IDbObjectRepository<ContentSchema, ContentSchemaCollection>>();
            mockRepositoryContent.Setup(x => x.Get()).Returns(contents);
            mockRepositoryContent.Setup(x => x.Post(new ContentSchema()));
            mockRepositoryContent.Setup(x => x.Delete(new ContentSchema()));
            mockRepository.Setup(x => x.Contents).Returns(mockRepositoryContent.Object);

            var mockQueryContent = new Mock<IPersistenceQuery<ContentSchema>>();
            mockQueryContent.Setup(x => x.Reader.ReadAll()).Returns(contents);
            mockQuery.Setup(x => x.Contents).Returns(mockQueryContent.Object);

            var mockCommandContent = new Mock<IPersistenceCommand<ContentSchema>>();
            mockCommandContent.Setup(x => x.Saver.Save(new ContentSchema()));
            mockCommand.Setup(x => x.Contents).Returns(mockCommandContent.Object);

            return this;
        }

        public DesignerEngineBuilder WithNodeCalled(List<NodeSchema> nodes)
        {
            var mockNode = new Mock<IDbObjectRepository<NodeSchema, NodeSchemaCollection>>();
            mockNode.Setup(x => x.Get()).Returns(nodes);
            mockNode.Setup(x => x.Post(new NodeSchema()));
            mockNode.Setup(x => x.Delete(new NodeSchema()));
            mockRepository.Setup(x => x.Nodes).Returns(mockNode.Object);
            return this;
        }

        #endregion メソッド
    }
}