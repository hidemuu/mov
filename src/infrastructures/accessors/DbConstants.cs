using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    /// <summary>
    /// データベースの定数
    /// </summary>
    public static class DbConstants
    {
        /// <summary>
        /// エンコード名
        /// </summary>
        public const string ENCODE_NAME_UTF8 = "utf-8";
        /// <summary>
        /// エンコード名
        /// </summary>
        private const string ENC_NAME_SHIFT_JIS = "Shift_JIS";
        /// <summary>
        /// スペース
        /// </summary>
        public const string SPACE = " ";
        /// <summary>
        /// デリミタ
        /// </summary>
        public const char DELIMITER = ',';
        /// <summary>
        /// エスケープ文字
        /// </summary>
        public const string ESCAPE = "/";
        /// <summary>
        /// 日付フォーマット
        /// </summary>
        public const string DATE_FORMAT = "yyyy/MM/dd HH:mm:ss.fff";

        public const string PATH_EXTENSION_JSON = ".json";

        public const string PATH_EXTENSION_XML = ".xml";

        public const string PATH_EXTENSION_CSV = ".csv";

        public const string PATH_EXTENSION_SQL = ".db";
    }
}
