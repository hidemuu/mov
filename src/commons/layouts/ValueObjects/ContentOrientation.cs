using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.ValueObjects
{
    public sealed class ContentOrientation : ValueObjectBase<ContentOrientation>
    {
        #region オブジェクト

        /// <summary>
        /// 水平
        /// </summary>
        public static readonly ContentOrientation Horizontal = new ContentOrientation(OrientationType.Horizontal);

        /// <summary>
        /// 垂直
        /// </summary>
        public static readonly ContentOrientation Vertical = new ContentOrientation(OrientationType.Vertical);

        #endregion オブジェクト

        #region プロパティ

        public OrientationType Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public ContentOrientation(OrientationType value)
        {
            Value = value;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentOrientation other)
        {
            throw new NotImplementedException();
        }

        public bool IsHorizontal => this == Horizontal;

        public bool IsVertical => this == Vertical;

        #endregion メソッド
    }
}
