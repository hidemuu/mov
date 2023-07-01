namespace Mov.Core.Elements.Personals
{
    public sealed class Name
    {
        public string FirstName { get; }
        public string LastName { get; }

        public string FullName => string.Join(" ", FirstName, LastName);

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
