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
    public class DesignLayoutContent : LayoutContent
    {

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
            : base(new DesignLayoutContentKey(content), 
                   new DesignLayoutContentParameter(content), 
                   new DesignLayoutContentDesign(content), 
                   new DesignLayoutContentValue(content))
        {
            
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
