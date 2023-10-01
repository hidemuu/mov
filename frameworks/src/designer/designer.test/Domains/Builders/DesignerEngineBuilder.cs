using Moq;
using Mov.Core.Repositories;
using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;
using System;
using System.Collections.Generic;

namespace Mov.Designer.Test.Domains.Builders
{
    public class DesignerEngineBuilder
    {
        #region フィールド

        private readonly Mock<IDesignerRepository> mockRepository;

        #endregion フィールド

        #region コンストラクター

        public DesignerEngineBuilder()
        {
            //モックオブジェクト生成
            mockRepository = new Mock<IDesignerRepository>();
            //インスタンス生成
            //this.engine = new DesignerEngine(this.mockContext.Object, 0);
        }

        #endregion コンストラクター

        #region メソッド

        public DesignerEngineBuilder WithContentCalled(List<ContentSchema> contents)
        {
            var mockRepositoryContent = new Mock<IDbRepository<ContentSchema, Guid>>();
            mockRepositoryContent.Setup(x => x.GetAsync()).ReturnsAsync(contents);
            mockRepositoryContent.Setup(x => x.PostAsync(new ContentSchema()));
            mockRepositoryContent.Setup(x => x.DeleteAsync(new ContentSchema()));
            mockRepository.Setup(x => x.Contents).Returns(mockRepositoryContent.Object);

            return this;
        }

        public DesignerEngineBuilder WithNodeCalled(List<NodeSchema> nodes)
        {
            var mockNode = new Mock<IDbRepository<NodeSchema, Guid>>();
            mockNode.Setup(x => x.GetAsync()).ReturnsAsync(nodes);
            mockNode.Setup(x => x.PostAsync(new NodeSchema()));
            mockNode.Setup(x => x.DeleteAsync(new NodeSchema()));
            mockRepository.Setup(x => x.Nodes).Returns(mockNode.Object);
            return this;
        }

        #endregion メソッド
    }
}