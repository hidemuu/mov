using Mov.Designer.Models;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service.Layouts.Nodes
{
    public class ContentLayoutNode : LayoutNodeBase
    {
        #region プロパティ

        public override LayoutNodeType LayoutNodeType => LayoutNodeType.Content;

        public string ControlType { get; } = string.Empty;

        public string ControlStyle { get; } = string.Empty;

        public string Macro { get; } = string.Empty;

        public ReactivePropertySlim<bool> IsVisible { get; } = new ReactivePropertySlim<bool>(true);

        public ReactivePropertySlim<bool> IsEnable { get; } = new ReactivePropertySlim<bool>(true);

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ContentLayoutNode()
        {

        }

        public ContentLayoutNode(LayoutNode layout, Content content) : base(layout)
        {
            Code = content.Code;
            ControlType = content.ControlType;
            ControlStyle = content.ControlStyle;
            Macro = content.Macro;
            IsVisible.Value = content.IsVisible;
            IsEnable.Value = content.IsEnable;
        }

        #endregion コンストラクター

        #region メソッド

        public override string ToString()
        {
            return base.ToString() + " [ControlType] " + ControlType + " [ControlStyle] " + ControlStyle + " [Macro] " + Macro;
        }

        #endregion メソッド

    }
}
