using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service.Layouts.Nodes
{
    public class ContentLayout : LayoutNodeBase
    {
        #region プロパティ
        public string Code { get; }

        public string ControlType { get; }

        public string ControlStyle { get; }

        public string Command { get; }

        public string Macro { get; }

        public bool IsVisible { get; }

        public bool IsEnable { get; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ContentLayout()
        {

        }

        public ContentLayout(ContentTable table)
        {
            Code = table.Code;
            ControlType = table.ControlType;
            ControlStyle = table.ControlStyle;
            Command = table.Command;
            Macro = table.Macro;
            IsVisible = table.IsVisible;
            IsEnable = table.IsEnable;
        }

        #endregion コンストラクター

    }
}
