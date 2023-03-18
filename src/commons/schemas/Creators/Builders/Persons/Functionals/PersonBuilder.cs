using Mov.Schemas.Elements.Personals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Creators.Builders.Persons.Functionals
{
    public sealed class PersonBuilder : FunctionalBuilderBase<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name) => Do(p => p.ChangeName(name));
    }
}
