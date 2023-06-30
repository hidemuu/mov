namespace Mov.Core.Models
{
    /// <summary>
    /// ValueObjectのベースクラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValueObjectBase<TSelf> where TSelf : ValueObjectBase<TSelf>
    {
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
