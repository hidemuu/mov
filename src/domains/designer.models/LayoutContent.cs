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
    public class LayoutContent : ILayoutContent
    {

        #region プロパティ

        public ILayoutKey LayoutKey { get; set; }
        public ILayoutParameter LayoutParameter { get; set; }
        public ILayoutDesign LayoutDesign { get; set; }
        public ILayoutValue LayoutValue { get; set; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutContent() : this(new Content())
        {
            
        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="content"></param>
        public LayoutContent(Content content)
        {
            this.LayoutKey = new LayoutContentKey(content);
            this.LayoutParameter = new LayoutContentParameter(content);
            this.LayoutDesign = new LayoutContentDesign(content);
            this.LayoutValue = new LayoutContentValue(content);

        }

        #endregion コンストラクター

        #region メソッド

        public override string ToString()
        {
            return "[Code] " + this.LayoutKey.Code.Value + " [Name] " + this.LayoutParameter.Name.Value;
        }

        #endregion メソッド

    }
}
