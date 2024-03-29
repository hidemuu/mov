﻿namespace Mov.Core.Models
{
    /// <summary>
    /// ValueObjectのベースクラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValueObjectBase<TSelf> where TSelf : ValueObjectBase<TSelf>
    {
        #region constant

        private const int HASH_PRIME_NUMBER = 397;

        #endregion constant

        #region abstruct method

        protected abstract bool EqualCore(TSelf other);

        protected abstract int GetHashCodeCore();

        #endregion abstruct method

        #region method

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var vo = obj as TSelf;
            if (vo == null) return false;
            return EqualCore(vo);
        }

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion method

        #region protected method

        protected int CreateHashCode(params int[] hashCodes)
        {
            var result = 0;
            for (int i = 0; i < hashCodes.Length; i++)
            {
                if (i == 0)
                {
                    result = hashCodes[i];
                    continue;
                }
                result = result * HASH_PRIME_NUMBER ^ hashCodes[i];
            }
            return result;
        }

        #endregion protected method

        #region static method

        public static bool operator ==(ValueObjectBase<TSelf> vo1, ValueObjectBase<TSelf> vo2)
        {
            return Equals(vo1, vo2);
        }

        public static bool operator !=(ValueObjectBase<TSelf> vo1, ValueObjectBase<TSelf> vo2)
        {
            return !Equals(vo1, vo2);
        }

        #endregion static method

    }
}
