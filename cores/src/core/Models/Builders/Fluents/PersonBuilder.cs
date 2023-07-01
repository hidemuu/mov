using Mov.Core.Models.Entities.Personals;
using Mov.Core.Models.ValueObjects.Units;
using Mov.Core.Templates.Builders;
using System;

namespace Mov.Core.Models.Builders.Fluents
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
