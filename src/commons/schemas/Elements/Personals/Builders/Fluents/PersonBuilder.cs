﻿using Mov.Schemas.Elements.Personals;
using Mov.Schemas.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Personals.Builders.Fluents
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