namespace Mov.Core.Models.ValueObjects.Personals
{
    public sealed class Employment : ValueObjectBase<Employment>
    {
        #region property

        public string CompanyName { get; }

        public string Position { get; }

        #endregion property

        #region constructor

        public Employment(string companyName, string position)
        {
            this.CompanyName = companyName;
            this.Position = position;
        }

        #endregion constructor

        #region protected method

        protected override bool EqualCore(Employment other)
        {
            return this.CompanyName.Equals(other.CompanyName) && this.Position.Equals(other.Position);
        }

        protected override int GetHashCodeCore()
        {
            return this.CreateHashCode(this.CompanyName.GetHashCode(), this.Position.GetHashCode());
        }

        #endregion protected method
    }
}
