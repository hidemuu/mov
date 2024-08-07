﻿using Mov.Core.Models;

namespace Mov.Core.Characters.Personals
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
            CompanyName = companyName;
            Position = position;
        }

        #endregion constructor

        #region protected method

        protected override bool EqualCore(Employment other)
        {
            return CompanyName.Equals(other.CompanyName) && Position.Equals(other.Position);
        }

        protected override int GetHashCodeCore()
        {
            return CreateHashCode(CompanyName.GetHashCode(), Position.GetHashCode());
        }

        #endregion protected method
    }
}
