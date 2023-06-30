using Moq;
using Mov.Core.Layouts.Models.Contents.Entities;
using Mov.Core.Layouts.Models.Nodes.Entities;
using Mov.Core.Layouts.Models.Shells.Entities;
using Mov.Core.Layouts.Models.Themes.Entities;
using Mov.Core.Layouts.Services;

namespace Mov.Core.Layouts.Test.Builders
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
            mockContext = new Mock<ILayoutContext>();
            engine = new LayoutEngine(mockContext.Object);
        }

        #endregion constructor

        #region method

        public LayoutEngineBuilder WithNodeCalled(IEnumerable<LayoutNode> nodes)
        {
            mockContext.Setup(x => x.Nodes).Returns(nodes);
            return this;
        }

        public LayoutEngineBuilder WithContentCalled(IEnumerable<LayoutContent> contents)
        {
            mockContext.Setup(x => x.Contents).Returns(contents);
            return this;
        }

        public LayoutEngineBuilder WithShellCalled(IEnumerable<LayoutShell> shells)
        {
            mockContext.Setup(x => x.Shells).Returns(shells);
            return this;
        }

        public LayoutEngineBuilder WithThemeCalled(IEnumerable<LayoutTheme> themes)
        {
            mockContext.Setup(x => x.Themes).Returns(themes);
            return this;
        }

        public ILayoutEngine Build() => engine;

        #endregion method
    }
}