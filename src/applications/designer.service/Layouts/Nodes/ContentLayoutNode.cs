using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service.Layouts.Nodes
{
    public class ContentLayoutNode : LayoutNodeBase
    {
        #region プロパティ

        public string ControlType { get; }

        public string ControlStyle { get; }

        public string Macro { get; }

        public bool IsVisible { get; }

        public bool IsEnable { get; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ContentLayoutNode()
        {

        }

        public ContentLayoutNode(LayoutTree layout, ContentTable content) : base(layout)
        {
            Code = content.Code;
            ControlType = content.ControlType;
            ControlStyle = content.ControlStyle;
            Macro = content.Macro;
            IsVisible = content.IsVisible;
            IsEnable = content.IsEnable;
        }

        #endregion コンストラクター

    }
}
