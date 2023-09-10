using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Models.Codes
{
    public sealed class KeyboardCode : ValueObjectBase<KeyboardCode>
    {
        #region constant

        /// <summary>
        /// キー指定無
        /// </summary>
        private const int CODE_NONE = 0;
        /// <summary>
        /// 左キー
        /// </summary>
        private const int CODE_LEFT = 37;
        /// <summary>
        /// 右キー
        /// </summary>
        private const int CODE_RIGHT = 39;
        /// <summary>
        /// 上キー
        /// </summary>
        private const int CODE_UP = 38;
        /// <summary>
        /// 下キー
        /// </summary>
        private const int CODE_DOWN = 40;

        #endregion constant

        #region property

        public int Value { get; }

        #endregion property

        #region constructor

        public KeyboardCode(int code) 
        {
            this.Value = code;
        }

        public static KeyboardCode None = new KeyboardCode(CODE_NONE);

        public static KeyboardCode Left = new KeyboardCode(CODE_LEFT);

        public static KeyboardCode Right = new KeyboardCode(CODE_RIGHT);

        public static KeyboardCode Up = new KeyboardCode(CODE_UP);

        public static KeyboardCode Down = new KeyboardCode(CODE_DOWN);

        #endregion constructor

        #region method

        protected override bool EqualCore(KeyboardCode other)
        {
            return this.Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }

        #endregion method
    }
}
