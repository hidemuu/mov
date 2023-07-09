using System;

namespace Mov.Core.Models.Units
{
    public sealed class Info : ValueObjectBase<Info>
    {
        
        #region property

        public string Value { get; }

        #endregion property

        #region constructor

        public Info(string info)
        {
            Value = info;
        }

        public static Info Empty = new Info(string.Empty);

        #endregion constructor

        #region method

        public bool IsEmpty => this.Equals(Empty);

        #endregion method

        #region protected method

        protected override bool EqualCore(Info other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion protected method
    }
}