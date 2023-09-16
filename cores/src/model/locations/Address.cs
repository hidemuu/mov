using Mov.Core.Models;
using System;

namespace Mov.Core.Locations
{
    [Serializable]
    public sealed class Address : ValueObjectBase<Address>
    {
        #region property

        public string StreetAddress { get; }

        public string Postcode { get; }

        public string City { get; }

        #endregion property

        #region constructor

        public Address(string streetAddress, string postCode, string city)
        {
            StreetAddress = streetAddress;
            Postcode = postCode;
            City = city;
        }

        public static Address Empty = new Address(string.Empty, string.Empty, string.Empty);

        #endregion constructor

        #region method

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}";
        }

        protected override bool EqualCore(Address other)
        {
            return
                StreetAddress.Equals(other.StreetAddress, StringComparison.Ordinal) &&
                Postcode.Equals(other.Postcode, StringComparison.Ordinal) &&
                City.Equals(other.City, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return CreateHashCode(StreetAddress.GetHashCode(), Postcode.GetHashCode(), City.GetHashCode());
        }

        #endregion method
    }
}
