using Mov.Core.Locations;
using Mov.Core.Valuables;
using System;

namespace Mov.Core.Characters.Personals.Entities
{
    public class Person
    {
        public Name Name { get; set; }

        public Address Address { get; set; }

        public Employment Employment { get; set; }

        public Money AnnualIncome { get; set; }

        public DateTime DateOfBirth { get; set; }

        //public Person(Name name, Employment employment, Money income, DateTime birthDate)
        //{
        //    this.Name = name;
        //    this.Employment = employment;
        //    this.AnnualIncome = income;
        //    this.DateOfBirth = birthDate;
        //}

        //public class Builder : PersonBirthDateBuilder<Builder>
        //{
        //    internal Builder() { }
        //}

        //public static Builder New => new Builder();

        public void ChangeName(string lastName)
        {
            Name = new Name(Name.FirstName, lastName);
        }

        public void ChangePosition(string position)
        {
            Employment = new Employment(Employment.CompanyName, position);
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name.FullName}, {nameof(Employment)}: {Employment.Position}";
        }
    }
}
