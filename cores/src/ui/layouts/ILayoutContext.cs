using Mov.Core.Layouts.Models.Contents;
using Mov.Core.Layouts.Models.Nodes;
using Mov.Core.Layouts.Models.Shells;
using Mov.Core.Layouts.Models.Themes;
using Mov.Core.Models.Identifiers;
using System.Collections.Generic;

namespace Mov.Core.Layouts
{
    public interface ILayoutContext
    {
        #region property

        IdentifierCode DomainId { get; }
        IEnumerable<LayoutNode> Nodes { get; }
        IEnumerable<LayoutContent> Contents { get; }
        IEnumerable<LayoutShell> Shells { get; }
        IEnumerable<LayoutTheme> Themes { get; }

        #endregion property

        #region method

        void Read();

        void Write();

        void Update();

        #endregion method

    }
}
