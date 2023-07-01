namespace Mov.Core.Models.ValueObjects.Personals
{
    public sealed class Name : ValueObjectBase<Name>
    {
        #region property

        public string FirstName { get; }
        public string LastName { get; }
        public string FullName => string.Join(" ", this.FirstName, this.LastName);

        #endregion property

        #region constructor

        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        #endregion constructor

        #region protected method

        protected override bool EqualCore(Name other)
        {
            return this.FirstName.Equals(other.FirstName) && this.LastName.Equals(other.LastName);
        }

        protected override int GetHashCodeCore()
        {
            return this.CreateHashCode(this.FirstName.GetHashCode(), this.LastName.GetHashCode());
        }

        #endregion protected method
    }
}
