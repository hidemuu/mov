using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Layouts
{
    /// <summary>
    /// コンテンツ
    /// </summary>
    public interface ILayoutContent
    {
        ILayoutKey LayoutKey { get; set; }

        ILayoutParameter LayoutParameter { get; set; }

        ILayoutDesign LayoutDesign { get; set; }

        ILayoutValue LayoutValue { get; set; }
    }
}
