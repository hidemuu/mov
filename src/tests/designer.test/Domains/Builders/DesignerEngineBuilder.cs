using Moq;
using Mov.Accessors;
using Mov.Controllers.Repository.Persistences;
using Mov.Designer.Engine;
using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Designer.Test
{
    public class DesignerEngineBuilder
    {
        #region フィールド

        private readonly Mock<IDesignerRepository> mockRepository;
        private readonly Mock<IDesignerQuery> mockQuery;
        private readonly Mock<IDesignerCommand> mockCommand;

        #endregion フィールド

        #region コンストラクター

        public DesignerEngineBuilder()
        {
            //モックオブジェクト生成
            this.mockRepository = new Mock<IDesignerRepository>();
            this.mockQuery = new Mock<IDesignerQuery>();
            this.mockCommand = new Mock<IDesignerCommand>();;
            //インスタンス生成
            //this.engine = new DesignerEngine(this.mockContext.Object, 0);
        }

        #endregion コンストラクター

        #region メソッド

        public DesignerEngineBuilder WithContentCalled(List<ContentSchema> contents)
        {
            var mockRepositoryContent = new Mock<IDbObjectRepository<ContentSchema, ContentCollection>>();
            mockRepositoryContent.Setup(x => x.Get()).Returns(contents);
            mockRepositoryContent.Setup(x => x.Post(new ContentSchema()));
            mockRepositoryContent.Setup(x => x.Delete(new ContentSchema()));
            this.mockRepository.Setup(x => x.Contents).Returns(mockRepositoryContent.Object);

            var mockQueryContent = new Mock<IPersistenceQuery<ContentSchema>>();
            mockQueryContent.Setup(x => x.Reader.ReadAll()).Returns(contents);
            this.mockQuery.Setup(x => x.Contents).Returns(mockQueryContent.Object);

            var mockCommandContent = new Mock<IPersistenceCommand<ContentSchema>>();
            mockCommandContent.Setup(x => x.Saver.Save(new ContentSchema()));
            this.mockCommand.Setup(x => x.Contents).Returns(mockCommandContent.Object);

            return this;
        }

        public DesignerEngineBuilder WithNodeCalled(List<NodeSchema> nodes)
        {
            var mockNode = new Mock<IDbObjectRepository<NodeSchema, NodeCollection>>();
            mockNode.Setup(x => x.Get()).Returns(nodes);
            mockNode.Setup(x => x.Post(new NodeSchema()));
            mockNode.Setup(x => x.Delete(new NodeSchema()));
            this.mockRepository.Setup(x => x.Nodes).Returns(mockNode.Object);
            return this;
        }


        #endregion メソッド

        #region 内部メソッド

        

        #endregion 内部メソッド

    }
}
