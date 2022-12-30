using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Styles
{
    public sealed class ThemeStyle : ValueObjectBase<ThemeStyle>
    {

        #region オブジェクト

        public static readonly ThemeStyle Light = new ThemeStyle("Light");

        public static readonly ThemeStyle Dark = new ThemeStyle("Dark");

        #endregion オブジェクト

        #region プロパティ

        public string Value { get; }

        public bool IsLight => this == Light;

        public bool IsDark => this == Dark;

        #endregion プロパティ

        #region コンストラクター

        public ThemeStyle(string color)
        {
            this.Value = color;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ThemeStyle other)
        {
            return this.Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }

        #endregion メソッド

        #region 静的メソッド

        public static IEnumerable<string> GetStrings()
        {
            return new string[]
            {
                Light.Value,
                Dark.Value,
            };
        }

        #endregion 静的メソッド
    }
}
