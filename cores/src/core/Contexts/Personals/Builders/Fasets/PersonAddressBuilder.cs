﻿using Mov.Core.Contexts.Personals.Entities;

namespace Mov.Core.Contexts.Personals.Builders.Fasets
{
    public class PersonAddressBuilder : PersonBuilder
    {
        // might not work with a value type!
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            person.Address.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostcode(string postcode)
        {
            person.Address.Postcode = postcode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.Address.City = city;
            return this;
        }
    }
}