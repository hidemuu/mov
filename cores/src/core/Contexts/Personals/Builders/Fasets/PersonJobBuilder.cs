using Mov.Core.Contexts.Personals.Entities;
using Mov.Core.Contexts.Personals.ValueObjects;
using Mov.Core.Models.Units;

namespace Mov.Core.Contexts.Personals.Builders.Fasets
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
            person.AnnualIncome = new MoneyUnit(annualIncome);
            return this;
        }
    }
}