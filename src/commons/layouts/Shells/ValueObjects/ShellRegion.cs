using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.ValueObjects
{
    public sealed class ShellRegion : ValueObjectBase<ShellRegion>
    {
        #region オブジェクト

        public static readonly ShellRegion Center = new ShellRegion("Center");

        public static readonly ShellRegion Top = new ShellRegion("Top");

        public static readonly ShellRegion Bottom = new ShellRegion("Bottom");

        public static readonly ShellRegion Left = new ShellRegion("Left");

        public static readonly ShellRegion Right = new ShellRegion("Right");

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

        public ShellRegion(string region)
        {
            this.Value = region;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ShellRegion other)
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
