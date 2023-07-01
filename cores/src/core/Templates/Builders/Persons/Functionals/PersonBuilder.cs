using Mov.Core.Models.Entities.Personals;

namespace Mov.Core.Templates.Builders.Persons.Functionals
{
    public sealed class PersonBuilder : FunctionalBuilderBase<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name) => Do(p => p.ChangeName(name));
    }
}
