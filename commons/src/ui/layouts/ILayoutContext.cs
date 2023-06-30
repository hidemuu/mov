using Mov.Core.Layouts.Models.Contents.Entities;
using Mov.Core.Layouts.Models.Nodes.Entities;
using Mov.Core.Layouts.Models.Shells.Entities;
using Mov.Core.Layouts.Models.Themes.Entities;
using Mov.Core.Models.ValueObjects.Keys;
using System.Collections.Generic;

namespace Mov.Core.Layouts
{
    public interface ILayoutContext
    {
        #region property

        CodeKey DomainId { get; }
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
