using Mov.Layouts.Contents;
using Mov.Layouts.Contents.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public class LayoutContent
    {

        #region プロパティ

        public LayoutKey LayoutKey { get; set; }
        public LayoutParameter LayoutParameter { get; set; }
        public LayoutDesign LayoutDesign { get; set; }
        public LayoutValue LayoutValue { get; set; }

        #endregion プロパティ

        #region コンストラクター

        public LayoutContent()
        {

        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutContent(LayoutKey key, LayoutParameter parameter, LayoutDesign design, LayoutValue value)
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
