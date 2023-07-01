using Mov.Core.Contexts.Personals.Entities;
using Mov.Core.Contexts.Personals.ValueObjects;
using Mov.Core.Models.Units;
using Mov.Core.Templates.Builders;
using System;

namespace Mov.Core.Contexts.Personals.Builders.Fluents
{
    public abstract class PersonBuilder : IBuilder<Person>
    {
        protected Name Name { get; set; }

        protected Employment Employment { get; set; }

        protected MoneyUnit AnnualIncome { get; set; }

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
