using Mov.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions.ValueObjects
{
    public sealed class RegionCategory : ValueObjectBase<RegionCategory>
    {
        #region property

        public string Value { get; }

        #endregion property

        #region constructor

        public RegionCategory(string value)
        {
            Value = value;
        }

        public static RegionCategory Empty => new RegionCategory(string.Empty);

        public static RegionCategory City => new RegionCategory("city");

        public static RegionCategory Prefecture => new RegionCategory("prefecture");

        #endregion constructor

        #region method

        public bool IsEmpty() => Equals(Empty);

        public bool IsCity() => Equals(City);

        public bool IsPrefecture() => Equals(Prefecture);

        #endregion method

        #region logic

        protected override bool EqualCore(RegionCategory other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion logic
    }
}
