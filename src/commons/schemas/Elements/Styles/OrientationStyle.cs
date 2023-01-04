using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Styles
{
    public sealed class OrientationStyle : ValueObjectBase<OrientationStyle>
    {
        #region オブジェクト

        /// <summary>
        /// 水平
        /// </summary>
        public static readonly OrientationStyle Horizontal = new OrientationStyle("Horizontal");

        /// <summary>
        /// 垂直
        /// </summary>
        public static readonly OrientationStyle Vertical = new OrientationStyle("Vertical");

        #endregion オブジェクト

        #region プロパティ

        public string Value { get; }

        public bool IsHorizontal => this == Horizontal;

        public bool IsVertical => this == Vertical;

        #endregion プロパティ

        #region コンストラクター

        public OrientationStyle(string orientation)
        {
            Value = orientation;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(OrientationStyle other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion メソッド

        #region 静的メソッド

        public static IEnumerable<string> GetStrings()
        {
            return new string[]
            {
                Horizontal.Value,
                Vertical.Value,
            };
        }

        #endregion 静的メソッド
    }
}
