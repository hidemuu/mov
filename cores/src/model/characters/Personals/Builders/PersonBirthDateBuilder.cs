﻿using System;

namespace Mov.Core.Characters.Personals.Builders
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
