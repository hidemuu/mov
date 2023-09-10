using System;

namespace Mov.Core.Models.Locations
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
            this.StreetAddress = streetAddress;
            this.Postcode = postCode;
            this.City = city;
        }

        public static Address Empty = new Address(string.Empty, string.Empty, string.Empty);

        #endregion constructor

        #region method

        public override string ToString()
        {
            return $"{nameof(this.StreetAddress)}: {this.StreetAddress}, {nameof(this.Postcode)}: {this.Postcode}";
        }

        protected override bool EqualCore(Address other)
        {
            return 
                this.StreetAddress.Equals(other.StreetAddress, StringComparison.Ordinal) && 
                this.Postcode.Equals(other.Postcode, StringComparison.Ordinal) &&
                this.City.Equals(other.City, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return CreateHashCode(this.StreetAddress.GetHashCode(), this.Postcode.GetHashCode(), this.City.GetHashCode());
        }

        #endregion method
    }
}
