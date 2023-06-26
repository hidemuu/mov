using Mov.Utilities.Models;
using Mov.Utilities.Models.ValueObjects.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Models.Styles
{
    public sealed class ThemeStyle : ValueObjectBase<ThemeStyle>
    {

        #region オブジェクト

        public static readonly ThemeStyle Light = new ThemeStyle(ColorStyle.Black, ColorStyle.White);

        public static readonly ThemeStyle Dark = new ThemeStyle(ColorStyle.White, ColorStyle.DarkGray);

        #endregion オブジェクト

        #region プロパティ

        public ColorStyle TextColor { get; }

        public ColorStyle BackgroundColor { get; }

        public bool IsLight => this == Light;

        public bool IsDark => this == Dark;

        #endregion プロパティ

        #region コンストラクター

        public ThemeStyle(ColorStyle textColor, ColorStyle backgroundColor)
        {
            TextColor = textColor;
            BackgroundColor = backgroundColor;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ThemeStyle other)
        {
            return TextColor.Equals(other.TextColor) && BackgroundColor.Equals(other.BackgroundColor);
        }

        protected override int GetHashCodeCore()
        {
            return TextColor.GetHashCode() ^ BackgroundColor.GetHashCode();
        }

        #endregion メソッド

        #region 静的メソッド

        public static IEnumerable<string> GetStrings()
        {
            return new string[]
            {
                Light.TextColor.Value,
                Dark.TextColor.Value,
            };
        }

        #endregion 静的メソッド
    }
}
