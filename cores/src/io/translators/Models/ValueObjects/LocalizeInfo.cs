using Mov.Core.Models;
using Mov.Core.Models.Texts;
using Mov.Core.Models.Locations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Translators.Models.ValueObjects
{
    public sealed class LocalizeInfo : ValueObjectBase<LocalizeInfo>
    {
        #region property

        public Language Location { get; } = Language.Empty;

        public Document Description { get; } = Document.Empty;

        #endregion property

        #region constructor

        public LocalizeInfo(Language location, Document description)
        {
            Location = location;
            Description = description;
        }

        public readonly static LocalizeInfo Empty = new LocalizeInfo(Language.Empty, Document.Empty);

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
