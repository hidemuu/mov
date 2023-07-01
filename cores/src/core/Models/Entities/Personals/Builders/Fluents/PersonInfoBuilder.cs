using Mov.Core.Models.Entities.Personals.Persons.Fluents;
using Mov.Core.Models.ValueObjects.Personals;

namespace Mov.Core.Models.Entities.Personals.Builders.Fluents
{
    public class PersonInfoBuilder<TSelf> : PersonBuilder
        where TSelf : PersonInfoBuilder<TSelf>
    {
        public TSelf Called(string name)
        {
            Name = new Name("", name);
            return (TSelf)this;
        }
    }
}