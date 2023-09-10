using Mov.Core.Characters.Personals.Entities;
using Mov.Core.Functions.Builders;
using Mov.Core.Valuables;
using System;

namespace Mov.Core.Characters.Personals.Builders
{
    public abstract class PersonBuilder : IBuilder<Person>
    {
        protected Name Name { get; set; }

        protected Employment Employment { get; set; }

        protected Money AnnualIncome { get; set; }

        protected DateTime DateOfBirth { get; set; }

        public Person Build()
        {
            return new Person
            {
                Name = Name,
                Employment = Employment,
                AnnualIncome = AnnualIncome,
                DateOfBirth = DateOfBirth,
            };
        }
    }
}
