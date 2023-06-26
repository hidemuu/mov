using Moq;
using Mov.Layouts;
using Mov.Layouts.Implements;
using Mov.Layouts.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Commons.Test.Layouts.Builders
{
    internal class LayoutEngineBuilder
    {
        private readonly ILayoutEngine engine;
        private readonly Mock<ILayoutContext> mockContext;

        internal LayoutEngineBuilder()
        {
            this.mockContext = new Mock<ILayoutContext>();
            this.engine = new LayoutEngine(mockContext.Object);
        }

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

    }
}
