﻿using Mov.Schemas.Resources.Localizes;
using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Resources.Macros
{
    public sealed class Macro : ValueObjectBase<Macro>
    {
        public static Macro Empty = new Macro("");

        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public Macro(string macro)
        {
            this.Value = macro;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(Macro other)
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