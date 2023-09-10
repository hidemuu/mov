using Mov.Core.Functions.Builders;
using Mov.Core.Models.Locations;
using Mov.Core.Models.Personals.Entities;
using System;

namespace Mov.Core.Models.Personals.Builders
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
