using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Elements.Personals.Fasets
{
    public class PersonBuilder
    {
        // the object we're going to build
        protected Person person = new Person(); // this is a reference!

        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);
        public PersonJobBuilder Works => new PersonJobBuilder(person);

        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }
    }
}
