using Mov.Layouts.Models.Contents.Entities;
using Mov.Layouts.Models.Nodes.Entities;
using Mov.Layouts.Models.Shells.Entities;
using Mov.Layouts.Models.Themes.Entities;
using Mov.Utilities.Models.ValueObjects.Keys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
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
