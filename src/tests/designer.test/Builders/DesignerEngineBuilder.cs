using Moq;
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
            this.mockParameter = new Mock<IDesignerParameter>();
            this.mockRepository = new Mock<IDesignerRepository>();
            this.mockQuery = new Mock<IDesignerQuery>();
            this.mockCommand = new Mock<IDesignerCommand>();
            this.mockParameter.Setup(x => x.Repository).Returns(this.mockRepository.Object);
            this.mockParameter.Setup(x => x.Query).Returns(this.mockQuery.Object);
            this.mockParameter.Setup(x => x.Command).Returns(this.mockCommand.Object);
            this.engine = new DesignerEngine(this.mockParameter.Object);
        }

        #endregion コンストラクター

        #region メソッド

        public DesignerEngineBuilder WithParameterCalled()
        {
            var mockContent = new Mock<IDbObjectRepository<LayoutContent, LayoutContentCollection>>();
            mockContent.Setup(x => x.Get()).Returns(new List<LayoutContent>());
            this.mockRepository.Setup(x => x.Contents).Returns(mockContent.Object);
            return this;
        }

        public IDesignerEngine Build() => this.engine;

        #endregion メソッド

        #region 内部メソッド

        

        #endregion 内部メソッド

    }
}
