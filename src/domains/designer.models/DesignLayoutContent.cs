using Mov.Designer.Models;
using Mov.Layouts;
using Mov.Layouts.Contents;
using Mov.Layouts.Contents.ValueObjects;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class DesignLayoutContent
    {

        #region プロパティ

        public LayoutKey LayoutKey { get; set; }
        public LayoutParameter LayoutParameter { get; set; }
        public LayoutDesign LayoutDesign { get; set; }
        public LayoutValue LayoutValue { get; set; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DesignLayoutContent() : this(new Content())
        {
            
        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="content"></param>
        public DesignLayoutContent(Content content)
        {
            this.LayoutKey = new DesignLayoutContentKey(content);
            this.LayoutParameter = new DesignLayoutContentParameter(content);
            this.LayoutDesign = new DesignLayoutContentDesign(content);
            this.LayoutValue = new DesignLayoutContentValue(content);

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
