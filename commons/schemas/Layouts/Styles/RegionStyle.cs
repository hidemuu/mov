using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Layouts.Styles
{
    public sealed class RegionStyle : ValueObjectBase<RegionStyle>
    {
        #region オブジェクト

        public static readonly RegionStyle Center = new RegionStyle("Center");

        public static readonly RegionStyle Top = new RegionStyle("Top");

        public static readonly RegionStyle Bottom = new RegionStyle("Bottom");

        public static readonly RegionStyle Left = new RegionStyle("Left");

        public static readonly RegionStyle Right = new RegionStyle("Right");

        #endregion オブジェクト

        #region プロパティ

        public string Value { get; }

        public bool IsCenter => this == Center;

        public bool IsTop => this == Top;

        public bool IsBottom => this == Bottom;

        public bool IsLeft => this == Left;

        public bool IsRight => this == Right;

        #endregion プロパティ

        #region コンストラクター

        public RegionStyle(string region)
        {
            Value = region;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(RegionStyle other)
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
                Center.Value,
                Top.Value,
                Bottom.Value,
                Left.Value,
                Right.Value,
            };
        }

        #endregion 静的メソッド
    }
}
