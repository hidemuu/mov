using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Themes.ValueObjects
{
    public sealed class ThemeColor : ValueObjectBase<ThemeColor>
    {

        #region オブジェクト

        public static readonly ThemeColor Light = new ThemeColor("Light");

        public static readonly ThemeColor Dark = new ThemeColor("Dark");

        #endregion オブジェクト

        #region プロパティ

        public string Value { get; }

        public bool IsLight => this == Light;

        public bool IsDark => this == Dark;

        #endregion プロパティ

        #region コンストラクター

        public ThemeColor(string color)
        {
            this.Value = color;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ThemeColor other)
        {
            return this.Value.Equals(other.Value, StringComparison.Ordinal);
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
