using Mov.Core.Contexts.Personals.Entities;
using Mov.Core.Templates.Builders;

namespace Mov.Core.Contexts.Personals.Builders.Functionals
{
    public sealed class PersonBuilder : FunctionalBuilderBase<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name) => Do(p => p.ChangeName(name));
    }
}
