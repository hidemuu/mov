using Mov.Layouts;
using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public class LayoutContentBase : ILayoutContent
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
        /// <param name="content"></param>
        public LayoutContentBase(ILayoutKey key, ILayoutParameter parameter, ILayoutDesign design, ILayoutValue value)
        {
            this.LayoutKey = key;
            this.LayoutParameter = parameter;
            this.LayoutDesign = design;
            this.LayoutValue = value;

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
