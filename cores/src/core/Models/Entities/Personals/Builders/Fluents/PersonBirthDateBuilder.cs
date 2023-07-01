using System;

namespace Mov.Core.Models.Entities.Personals.Builders.Fluents
{
    public class PersonBirthDateBuilder<TSelf> : PersonJobBuilder<PersonBirthDateBuilder<TSelf>>
        where TSelf : PersonBirthDateBuilder<TSelf>
    {
        public TSelf Born(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
            return (TSelf)this;
        }
    }
}
