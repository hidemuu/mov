using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.Contexts.Contents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contexts
{
    public class LayoutContent
    {

        public static LayoutContent Default = new LayoutContent(
            LayoutContentKey.Default, LayoutContentStatus.Empty, LayoutContentDesign.Empty, LayoutContentSchema.Empty);

        #region プロパティ

        public LayoutContentKey Keys { get; set; }
        public LayoutContentStatus Statuses { get; set; }
        public LayoutContentDesign Designs { get; set; }
        public LayoutContentSchema Schemas { get; set; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutContent(LayoutContentKey keys, LayoutContentStatus statuses, LayoutContentDesign designs, LayoutContentSchema schemas)
        {
            Keys = keys;
            Statuses = statuses;
            Designs = designs;
            Schemas = schemas;

        }

        #endregion コンストラクター

        #region メソッド

        public override string ToString()
        {
            return "[Code] " + Keys.Code.Value + " [Name] " + Statuses.Name.Value;
        }

        #endregion メソッド

    }
}
