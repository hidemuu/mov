using Moq;
using Mov.Layouts;
using Mov.Layouts.Models.Entities;
using Mov.Layouts.Services;

namespace Mov.Commons.Test.Layouts.Builders
{
    internal class LayoutEngineBuilder
    {
        #region field

        private readonly ILayoutEngine engine;
        private readonly Mock<ILayoutContext> mockContext;

        #endregion field

        #region constructor

        internal LayoutEngineBuilder()
        {
            this.mockContext = new Mock<ILayoutContext>();
            this.engine = new LayoutEngine(mockContext.Object);
        }

        #endregion constructor

        #region method

        public LayoutEngineBuilder WithNodeCalled(IEnumerable<LayoutNode> nodes)
        {
            this.mockContext.Setup(x => x.Nodes).Returns(nodes);
            return this;
        }

        public LayoutEngineBuilder WithContentCalled(IEnumerable<LayoutContent> contents)
        {
            this.mockContext.Setup(x => x.Contents).Returns(contents);
            return this;
        }

        public LayoutEngineBuilder WithShellCalled(IEnumerable<LayoutShell> shells)
        {
            this.mockContext.Setup(x => x.Shells).Returns(shells);
            return this;
        }

        public LayoutEngineBuilder WithThemeCalled(IEnumerable<LayoutTheme> themes)
        {
            this.mockContext.Setup(x => x.Themes).Returns(themes);
            return this;
        }

        public ILayoutEngine Build() => this.engine;

        #endregion method
    }
}