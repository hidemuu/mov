﻿using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.ValueObjects
{
    public sealed class ContentIcon : ValueObjectBase<ContentIcon>
    {
        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public ContentIcon(string url)
        {
            this.Value = url;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentIcon other)
        {
            return this.Value.Equals(other.Value, StringComparison.Ordinal);
        }

        #endregion メソッド
    }
}