﻿using Mov.Core.Models;
using System;

namespace Mov.Core.Contexts.Personals.ValueObjects
{
    [Serializable]
    public sealed class Address : ValueObjectBase<Address>
    {
        public string StreetAddress { get; set; }

        public string Postcode { get; set; }

        public string City { get; set; }

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}";
        }

        protected override bool EqualCore(Address other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}