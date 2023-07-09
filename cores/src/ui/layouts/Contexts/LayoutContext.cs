using Mov.Core.Layouts.Models.Contents;
using Mov.Core.Layouts.Models.Nodes;
using Mov.Core.Layouts.Models.Shells;
using Mov.Core.Layouts.Models.Themes;
using Mov.Core.Models.Keys;
using System.Collections.Generic;

namespace Mov.Core.Layouts.Contexts
{
    public class LayoutContext : ILayoutContext
    {
        #region property

        public IdentifierCode DomainId { get; }
        public IEnumerable<LayoutNode> Nodes { get; }
        public IEnumerable<LayoutContent> Contents { get; }
        public IEnumerable<LayoutShell> Shells { get; }
        public IEnumerable<LayoutTheme> Themes { get; }

        #endregion property

        #region constructor

        public LayoutContext(
            IdentifierCode code,
            IEnumerable<LayoutNode> nodes,
            IEnumerable<LayoutContent> contents,
            IEnumerable<LayoutShell> shells,
            IEnumerable<LayoutTheme> themes)
        {
            DomainId = code;
            Nodes = nodes;
            Contents = contents;
            Shells = shells;
            Themes = themes;
        }

        #endregion constructor

        #region method

        public void Update()
        {

        }

        public void Read()
        {

        }

        public void Write()
        {

        }

        #endregion method
    }
}
