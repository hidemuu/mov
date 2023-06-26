using Mov.Layouts.Models.Entities.Contents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Models.Entities
{
    public class LayoutContent
    {

        public static LayoutContent Default = new LayoutContent(
            LayoutContentKey.Default, LayoutContentStatus.Empty, LayoutContentArrange.Empty, LayoutContentSchema.Empty);

        #region プロパティ

        public LayoutContentKey Keys { get; }
        public LayoutContentStatus Statuses { get; }
        public LayoutContentArrange Arranges { get; }
        public LayoutContentSchema Schemas { get; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutContent(LayoutContentKey keys, LayoutContentStatus statuses, LayoutContentArrange arranges, LayoutContentSchema schemas)
        {
            Keys = keys;
            Statuses = statuses;
            Arranges = arranges;
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
