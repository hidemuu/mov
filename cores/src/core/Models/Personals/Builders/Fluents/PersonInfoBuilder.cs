namespace Mov.Core.Models.Personals.Builders.Fluents
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