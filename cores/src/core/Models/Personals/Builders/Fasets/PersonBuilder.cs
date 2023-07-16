using Mov.Core.Models.Personals.Entities;

namespace Mov.Core.Models.Personals.Builders.Fasets
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
