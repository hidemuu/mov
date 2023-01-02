using Moq;
using Mov.Layouts;
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

        }

        public ILayoutEngine Build() => this.engine;

    }
}
