using Mov.Designer.Models;
using Mov.Layouts;
using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.ValueObjects;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public abstract class LayoutContentBase : ILayoutContent
    {

        #region プロパティ

        public ContentCode Code { get; }

        public ContentName Name { get; }

        public ContentControlType ControlType { get; }

        public ContentIcon Icon { get; }

        public ContentIndent Indent { get; }

        public ContentHeight Height { get; }

        public ContentWidth Width { get; }

        public ContentVisibility Visibility { get; }

        public ContentEnable Enable { get; }

        public ContentOrientation Orientation { get; }

        public ContentHorizontalAlignment HorizontalAlignment { get; }

        public ContentVerticalAlignment VerticalAlignment { get; }

        public ContentSchema Schema { get; }

        public ContentValue ContentValue { get; }

        public ContentMacro Macro { get; }

        public ContentParameter Parameter { get; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutContentBase() : this(new Content())
        {
            
        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="content"></param>
        public LayoutContentBase(Content content)
        {
            this.Code = new ContentCode(content.Code);
            this.Name = new ContentName(content.Name);
            this.ControlType = new ContentControlType(content.ControlType);
            this.Icon = new ContentIcon(content.Icon);
            this.Indent = new ContentIndent(0);
            this.Height = new ContentHeight(content.Height);
            this.Width = new ContentWidth(content.Width);
            this.Visibility = new ContentVisibility(true);
            this.Enable = new ContentEnable(true);
            this.Orientation = new ContentOrientation(OrientationType.Horizontal);
            this.HorizontalAlignment = new ContentHorizontalAlignment(content.HorizontalAlignment);
            this.VerticalAlignment = new ContentVerticalAlignment(content.VerticalAlignment);
            this.Schema = new ContentSchema(content.Schema);
            this.ContentValue = new ContentValue(content.DefaultValue);
            this.Macro = new ContentMacro(content.Macro);
            this.Parameter = new ContentParameter(content.Parameter);
        }

        #endregion コンストラクター

        #region メソッド

        public override string ToString()
        {
            return "[Code] " + Code.Value + " [Name] " + Name.Value;
        }

        #endregion メソッド

    }
}
