﻿using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contents.ValueObjects
{
    public sealed class VisibilityStyle : ValueObjectBase<VisibilityStyle>
    {
        public static VisibilityStyle Visible = new VisibilityStyle("Visible");

        public static VisibilityStyle Collapse = new VisibilityStyle("Collapse");

        public static VisibilityStyle Hidden = new VisibilityStyle("Hidden");

        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public VisibilityStyle(string isVisible)
        {
            this.Value = isVisible;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(VisibilityStyle other)
        {
            return this.Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }

        #endregion メソッド
    }
}