using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Personals.Builders.Functionals
{
    public sealed class PersonBuilder : FunctionalBuilderBase<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name) => Do(p => p.ChangeName(name));
    }
}
