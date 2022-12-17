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
        public static readonly ContentOrientation Horizontal = new ContentOrientation("Horizontal");

        /// <summary>
        /// 垂直
        /// </summary>
        public static readonly ContentOrientation Vertical = new ContentOrientation("Vertical");

        #endregion オブジェクト

        #region プロパティ

        public string Value { get; }

        public bool IsHorizontal => this == Horizontal;

        public bool IsVertical => this == Vertical;

        #endregion プロパティ

        #region コンストラクター

        public ContentOrientation(string orientation)
        {
            this.Value = orientation;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentOrientation other)
        {
            return this.Value.Equals(other.Value);
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
                Horizontal.Value,
                Vertical.Value,
            };
        }

        #endregion 静的メソッド
    }
}
