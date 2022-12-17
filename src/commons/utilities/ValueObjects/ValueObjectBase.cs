using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.ValueObjects
{
    /// <summary>
    /// ValueObjectのベースクラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValueObjectBase<T> where T : ValueObjectBase<T>
    {
        #region 抽象メソッド

        protected abstract bool EqualCore(T other);

        protected abstract int GetHashCodeCore();

        #endregion 抽象メソッド

        #region メソッド

        public override bool Equals(object obj)
        {
            var vo = obj as T;
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

        #endregion メソッド

        #region 静的メソッド

        public static bool operator == (ValueObjectBase<T> vo1, ValueObjectBase<T> vo2)
        {
            return Equals(vo1, vo2);
        }

        public static bool operator != (ValueObjectBase<T> vo1, ValueObjectBase<T> vo2)
        {
            return !Equals(vo1, vo2);
        }

        #endregion 静的メソッド

    }
}
