﻿using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contents.ValueObjects
{
    public sealed class ContentVisibility : ValueObjectBase<ContentVisibility>
    {
        #region プロパティ

        public bool Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public ContentVisibility(bool isVisible)
        {
            this.Value = isVisible;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentVisibility other)
        {
            throw new NotImplementedException();
        }

        #endregion メソッド
    }
}