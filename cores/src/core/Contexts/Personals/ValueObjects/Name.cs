using Mov.Core.Models;

namespace Mov.Core.Contexts.Personals.ValueObjects
{
    public sealed class Name : ValueObjectBase<Name>
    {
        #region property

        public string FirstName { get; }
        public string LastName { get; }
        public string FullName => string.Join(" ", FirstName, LastName);

        #endregion property

        #region constructor

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        #endregion constructor

        #region protected method

        protected override bool EqualCore(Name other)
        {
            return FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName);
        }

        protected override int GetHashCodeCore()
        {
            return CreateHashCode(FirstName.GetHashCode(), LastName.GetHashCode());
        }

        #endregion protected method
    }
}
