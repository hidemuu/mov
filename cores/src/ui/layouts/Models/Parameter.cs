﻿using Mov.Core.Models;
using System;

namespace Mov.Core.Layouts.Models
{
    public sealed class Parameter : ValueObjectBase<Parameter>
    {
        public static Parameter Empty = new Parameter("");

        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public Parameter(string parameter)
        {
            Value = parameter;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(Parameter other)
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
