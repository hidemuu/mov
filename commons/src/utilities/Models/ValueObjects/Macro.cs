﻿using System;
using System.Collections.Generic;
using System.Text;
using Mov.Utilities.Models;

namespace Mov.Utilities.Models.ValueObjects
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
            Value = macro;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(Macro other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion メソッド
    }
}