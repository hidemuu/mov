using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Styles
{
    public sealed class HorizontalAlignmentStyle : ValueObjectBase<HorizontalAlignmentStyle>
    {
        #region インスタンス

        public static readonly HorizontalAlignmentStyle Left = new HorizontalAlignmentStyle("Left");

        public static readonly HorizontalAlignmentStyle Right = new HorizontalAlignmentStyle("Right");

        public static readonly HorizontalAlignmentStyle Center = new HorizontalAlignmentStyle("Center");

        public static readonly HorizontalAlignmentStyle Stretch = new HorizontalAlignmentStyle("Stretch");

        #endregion インスタンス

        #region プロパティ

        public string Value { get; }

        public bool IsLeft => this == Left;

        public bool IsRight => this == Right;

        public bool IsCenter => this == Center;

        public bool IsStretch => this == Stretch;


        #endregion プロパティ

        #region コンストラクター

        public HorizontalAlignmentStyle(string alignment)
        {
            Value = alignment;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(HorizontalAlignmentStyle other)
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
                Left.Value,
                Right.Value,
                Center.Value,
                Stretch.Value,
            };
        }

        #endregion 静的メソッド
    }
}
