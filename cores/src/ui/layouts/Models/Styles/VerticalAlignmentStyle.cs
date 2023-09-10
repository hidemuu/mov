using Mov.Core.Models;
using System;
using System.Collections.Generic;

namespace Mov.Core.Layouts.Models.Styles
{
    public sealed class VerticalAlignmentStyle : ValueObjectBase<VerticalAlignmentStyle>
    {
        #region オブジェクト

        public static readonly VerticalAlignmentStyle Top = new VerticalAlignmentStyle("Top");

        public static readonly VerticalAlignmentStyle Bottom = new VerticalAlignmentStyle("Bottom");

        public static readonly VerticalAlignmentStyle Center = new VerticalAlignmentStyle("Center");

        public static readonly VerticalAlignmentStyle Stretch = new VerticalAlignmentStyle("Stretch");

        #endregion オブジェクト

        #region プロパティ

        public string Value { get; }

        public bool IsTop => this == Top;

        public bool IsBottom => this == Bottom;

        public bool IsCenter => this == Center;

        public bool IsStretch => this == Stretch;

        #endregion プロパティ

        #region コンストラクター

        public VerticalAlignmentStyle(string alignment)
        {
            Value = alignment;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(VerticalAlignmentStyle other)
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
                Top.Value,
                Bottom.Value,
                Center.Value,
                Stretch.Value,
            };
        }

        #endregion 静的メソッド
    }
}
