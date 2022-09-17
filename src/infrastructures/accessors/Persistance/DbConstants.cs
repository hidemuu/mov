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

        public const string PATH_EXTENSION_SQL = ".db";
    }
}
