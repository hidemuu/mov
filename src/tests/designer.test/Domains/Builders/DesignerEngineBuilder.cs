﻿using Moq;
using Mov.Accessors;
using Mov.Designer.Engine;
using Mov.Designer.Models;
using Mov.Designer.Models.Parameters;
using Mov.Designer.Models.Persistences;
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

        private readonly IDesignerEngine engine;
        private readonly Mock<IDesignerParameter> mockParameter;
        private readonly Mock<IDesignerRepository> mockRepository;
        private readonly Mock<IDesignerQuery> mockQuery;
        private readonly Mock<IDesignerCommand> mockCommand;

        #endregion フィールド

        #region コンストラクター

        public DesignerEngineBuilder()
        {
            //モックオブジェクト生成
            this.mockParameter = new Mock<IDesignerParameter>();
            this.mockRepository = new Mock<IDesignerRepository>();
            this.mockQuery = new Mock<IDesignerQuery>();
            this.mockCommand = new Mock<IDesignerCommand>();
            this.mockParameter.Setup(x => x.Repository).Returns(this.mockRepository.Object);
            this.mockParameter.Setup(x => x.Query).Returns(this.mockQuery.Object);
            this.mockParameter.Setup(x => x.Command).Returns(this.mockCommand.Object);
            //インスタンス生成
            this.engine = new DesignerEngine(this.mockParameter.Object);
        }

        #endregion コンストラクター

        #region メソッド

        public DesignerEngineBuilder WithContentCalled(List<LayoutContent> contents)
        {
            var mockRepositoryContent = new Mock<IDbObjectRepository<LayoutContent, LayoutContentCollection>>();
            mockRepositoryContent.Setup(x => x.Get()).Returns(contents);
            mockRepositoryContent.Setup(x => x.Post(new LayoutContent()));
            mockRepositoryContent.Setup(x => x.Delete(new LayoutContent()));
            this.mockRepository.Setup(x => x.Contents).Returns(mockRepositoryContent.Object);

            var mockQueryContent = new Mock<IPersistenceQuery<LayoutContent>>();
            mockQueryContent.Setup(x => x.Reader.ReadAll()).Returns(contents);
            this.mockQuery.Setup(x => x.LayoutContent).Returns(mockQueryContent.Object);

            var mockCommandContent = new Mock<IPersistenceCommand<LayoutContent>>();
            mockCommandContent.Setup(x => x.Saver.Save(new LayoutContent()));
            this.mockCommand.Setup(x => x.LayoutContent).Returns(mockCommandContent.Object);

            return this;
        }

        public DesignerEngineBuilder WithNodeCalled(List<LayoutNode> nodes)
        {
            var mockNode = new Mock<IDbObjectRepository<LayoutNode, LayoutNodeCollection>>();
            mockNode.Setup(x => x.Get()).Returns(nodes);
            mockNode.Setup(x => x.Post(new LayoutNode()));
            mockNode.Setup(x => x.Delete(new LayoutNode()));
            this.mockRepository.Setup(x => x.Nodes).Returns(mockNode.Object);
            return this;
        }

        public IDesignerEngine Build() => this.engine;

        #endregion メソッド

        #region 内部メソッド

        

        #endregion 内部メソッド

    }
}