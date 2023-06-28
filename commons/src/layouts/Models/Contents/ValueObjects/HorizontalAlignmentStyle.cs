using Mov.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Models.Contents.ValueObjects
{
    public sealed class HorizontalAlignmentStyle : ValueObjectBase<HorizontalAlignmentStyle>
    {
        #region property

        public string Value { get; }

        public bool IsLeft => this == Left;

        public bool IsRight => this == Right;

        public bool IsCenter => this == Center;

        public bool IsStretch => this == Stretch;


        #endregion property

        #region constructor

        public HorizontalAlignmentStyle(string alignment)
        {
            Value = alignment;
        }

        public static readonly HorizontalAlignmentStyle Left = new HorizontalAlignmentStyle("Left");

        public static readonly HorizontalAlignmentStyle Right = new HorizontalAlignmentStyle("Right");

        public static readonly HorizontalAlignmentStyle Center = new HorizontalAlignmentStyle("Center");

        public static readonly HorizontalAlignmentStyle Stretch = new HorizontalAlignmentStyle("Stretch");

        #endregion constructor

        #region protected method

        protected override bool EqualCore(HorizontalAlignmentStyle other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion protected method

        #region static method

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

        #endregion static method
    }
}
