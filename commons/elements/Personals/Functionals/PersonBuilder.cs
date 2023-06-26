using System;
using System.Collections.Generic;
using System.Text;
using Mov.Utilities.Templates.Builders;

namespace Mov.Elements.Personals.Functionals
{
    public sealed class PersonBuilder : FunctionalBuilderBase<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name) => Do(p => p.ChangeName(name));
    }
}
