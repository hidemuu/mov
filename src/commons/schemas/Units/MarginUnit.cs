﻿using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Units
{
    public sealed class MarginUnit : ValueObjectBase<MarginUnit>
    {
        public static MarginUnit Default = new MarginUnit(0);

        #region プロパティ

        public int Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public MarginUnit(int indent)
        {
            this.Value = indent;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(MarginUnit other)
        {
            return this.Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }

        #endregion メソッド
    }
}