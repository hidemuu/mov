using Mov.Core.Models;
using Mov.Core.Models.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Translators.Models.ValueObjects
{
    public sealed class LocalizeInfo : ValueObjectBase<LocalizeInfo>
    {
        #region property

        public Location Location { get; } = Location.Empty;

        public Info Description { get; } = Info.Empty;

        #endregion property

        #region constructor

        public LocalizeInfo(Location location, Info description)
        {
            Location = location;
            Description = description;
        }

        public readonly static LocalizeInfo Empty = new LocalizeInfo(Location.Empty, Info.Empty);

        #endregion constructor

        #region protected method

        protected override bool EqualCore(LocalizeInfo other)
        {
            return Location.Equals(other.Location) && Description.Equals(other.Description);
        }

        protected override int GetHashCodeCore()
        {
            return CreateHashCode(Location.GetHashCode(), Description.GetHashCode());
        }

        #endregion protected method
    }
}
