using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.ValueObjects
{
    public sealed class Orientation : ValueObjectBase<Orientation>
    {
        #region オブジェクト

        /// <summary>
        /// 水平
        /// </summary>
        public static readonly Orientation Horizontal = new Orientation(0);

        /// <summary>
        /// 垂直
        /// </summary>
        public static readonly Orientation Vertical = new Orientation(1);

        #endregion オブジェクト

        #region プロパティ

        public int Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public Orientation(int value)
        {
            Value = value;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(Orientation other)
        {
            throw new NotImplementedException();
        }

        public bool IsHorizontal => this == Horizontal;

        public bool IsVertical => this == Vertical;

        #endregion メソッド
    }
}
