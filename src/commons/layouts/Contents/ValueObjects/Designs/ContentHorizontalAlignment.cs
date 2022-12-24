using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.ValueObjects
{
    public sealed class ContentHorizontalAlignment : ValueObjectBase<ContentHorizontalAlignment>
    {
        #region インスタンス

        public static readonly ContentHorizontalAlignment Left = new ContentHorizontalAlignment("Left");

        public static readonly ContentHorizontalAlignment Right = new ContentHorizontalAlignment("Right");

        public static readonly ContentHorizontalAlignment Center = new ContentHorizontalAlignment("Center");

        public static readonly ContentHorizontalAlignment Stretch = new ContentHorizontalAlignment("Stretch");

        #endregion インスタンス

        #region プロパティ

        public string Value { get; }

        public bool IsLeft => this == Left;

        public bool IsRight => this == Right;

        public bool IsCenter => this == Center;

        public bool IsStretch => this == Stretch;


        #endregion プロパティ

        #region コンストラクター

        public ContentHorizontalAlignment(string alignment)
        {
            this.Value = alignment;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentHorizontalAlignment other)
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
                Left.Value,
                Right.Value,
                Center.Value,
                Stretch.Value,
            };
        }

        #endregion 静的メソッド
    }
}
