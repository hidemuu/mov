using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Models.Contents.Entities
{
    public class LayoutContent
    {
        #region property

        public LayoutContentKey Keys { get; }
        public LayoutContentStatus Statuses { get; }
        public LayoutContentArrange Arranges { get; }
        public LayoutContentValue Schemas { get; }

        #endregion property

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutContent(LayoutContentKey keys, LayoutContentStatus statuses, LayoutContentArrange arranges, LayoutContentValue schemas)
        {
            Keys = keys;
            Statuses = statuses;
            Arranges = arranges;
            Schemas = schemas;
        }

        public static LayoutContent Empty =>
            new LayoutContent(LayoutContentKey.Default, LayoutContentStatus.Empty, LayoutContentArrange.Empty, LayoutContentValue.Empty);

        #endregion constructor

        #region method

        public override string ToString()
        {
            return "[Code] " + Keys.Code.Value + " [Name] " + Statuses.Name.Value;
        }

        #endregion method

    }
}
