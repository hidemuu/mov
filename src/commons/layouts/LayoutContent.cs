using Mov.Layouts.Contents;
using Mov.Layouts.Contents.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public class LayoutContent
    {

        public static LayoutContent Default = new LayoutContent(
            LayoutContentKey.Default, LayoutContentParameter.Empty, LayoutContentDesign.Empty, LayoutContentValue.Empty);

        #region プロパティ

        public LayoutContentKey LayoutKey { get; set; }
        public LayoutContentParameter LayoutParameter { get; set; }
        public LayoutContentDesign LayoutDesign { get; set; }
        public LayoutContentValue LayoutValue { get; set; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutContent(LayoutContentKey key, LayoutContentParameter parameter, LayoutContentDesign design, LayoutContentValue value)
        {
            LayoutKey = key;
            LayoutParameter = parameter;
            LayoutDesign = design;
            LayoutValue = value;

        }

        #endregion コンストラクター

        #region メソッド

        public override string ToString()
        {
            return "[Code] " + LayoutKey.Code.Value + " [Name] " + LayoutParameter.Name.Value;
        }

        #endregion メソッド

    }
}
