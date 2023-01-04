using Mov.Schemas.Elements.Members.Personals;
using Mov.Schemas.Elements.Units;
using Mov.Shemas.DesignPatterns.Creationals.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.DesignPatterns.Creationals.Builders.Persons.Fluents
{
    public abstract class PersonBuilder : IBuilder<Person>
    {
        protected Name Name { get; set; }

        protected Employment Employment { get; set; }

        protected MoneyUnit AnnualIncome { get; set; }

        protected DateTime DateOfBirth { get; set; }

        public Person Build()
        {
            return new Person {
            Name = Name,
            Employment = Employment,
            AnnualIncome = AnnualIncome,
            DateOfBirth = DateOfBirth,
            };
        }
    }
}
