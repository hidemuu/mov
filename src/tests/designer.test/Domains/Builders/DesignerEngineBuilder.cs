using Moq;
using Mov.Accessors;
using Mov.Controllers;
using Mov.Designer.Engine;
using Mov.Designer.Models;
using Mov.Designer.Models.Entities;
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

        public DesignerEngineBuilder WithContentCalled(List<Content> contents)
        {
            var mockRepositoryContent = new Mock<IDbObjectRepository<Content, ContentCollection>>();
            mockRepositoryContent.Setup(x => x.Get()).Returns(contents);
            mockRepositoryContent.Setup(x => x.Post(new Content()));
            mockRepositoryContent.Setup(x => x.Delete(new Content()));
            this.mockRepository.Setup(x => x.Contents).Returns(mockRepositoryContent.Object);

            var mockQueryContent = new Mock<IPersistenceQuery<Content>>();
            mockQueryContent.Setup(x => x.Reader.ReadAll()).Returns(contents);
            this.mockQuery.Setup(x => x.Contents).Returns(mockQueryContent.Object);

            var mockCommandContent = new Mock<IPersistenceCommand<Content>>();
            mockCommandContent.Setup(x => x.Saver.Save(new Content()));
            this.mockCommand.Setup(x => x.Contents).Returns(mockCommandContent.Object);

            return this;
        }

        public DesignerEngineBuilder WithNodeCalled(List<Node> nodes)
        {
            var mockNode = new Mock<IDbObjectRepository<Node, NodeCollection>>();
            mockNode.Setup(x => x.Get()).Returns(nodes);
            mockNode.Setup(x => x.Post(new Node()));
            mockNode.Setup(x => x.Delete(new Node()));
            this.mockRepository.Setup(x => x.Nodes).Returns(mockNode.Object);
            return this;
        }


        #endregion メソッド

        #region 内部メソッド

        

        #endregion 内部メソッド

    }
}
