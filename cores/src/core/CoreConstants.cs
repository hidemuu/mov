﻿namespace Mov.Core
{
    public static class CoreConstants
    {
        #region string code

        /// <summary>
        /// 改行コード
        /// </summary>
        public const string NewLine = @"\r\n";
        /// <summary>
        /// エンコード名
        /// </summary>
        public const string ENCODE_NAME_UTF8 = "utf-8";
        /// <summary>
        /// エンコード名
        /// </summary>
        private const string ENC_NAME_SHIFT_JIS = "Shift_JIS";

        #endregion string code

        #region hash code

        /// <summary>
        /// 素数
        /// </summary>
        public const int HASH_PRIME_NUMBER = 397;

        #endregion hash code

        #region keyboard code

        /// <summary>
        /// キー指定無
        /// </summary>
        public const int KEY_CODE_NONE = 0;
        /// <summary>
        /// 左キー
        /// </summary>
        public const int KEY_CODE_LEFT = 37;
        /// <summary>
        /// 右キー
        /// </summary>
        public const int KEY_CODE_RIGHT = 39;
        /// <summary>
        /// 上キー
        /// </summary>
        public const int KEY_CODE_UP = 38;
        /// <summary>
        /// 下キー
        /// </summary>
        public const int KEY_CODE_DOWN = 40;

        #endregion keyboard code
    }
}