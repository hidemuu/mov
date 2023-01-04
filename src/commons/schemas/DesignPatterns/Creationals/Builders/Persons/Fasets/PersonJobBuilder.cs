using Mov.Schemas.Elements.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.DesignPatterns.Creationals.Builders.Persons.Fasets
{
    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.Employment = new Employment(companyName, person.Employment.Position);
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Employment = new Employment(person.Employment.CompanyName, position);
            return this;
        }

        public PersonJobBuilder Earning(int annualIncome)
        {
            person.AnnualIncome = new Money(annualIncome);
            return this;
        }
    }
}
