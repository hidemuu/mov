using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public static class AccessConstants
    {
        /// <summary>
        /// エンコード名
        /// </summary>
        public const string ENCODE_NAME_UTF8 = "utf-8";
        /// <summary>
        /// エンコード名
        /// </summary>
        private const string ENC_NAME_SHIFT_JIS = "Shift_JIS";

        public const string PATH_EXTENSION = ".";

        public const string DELIMITER = ",";
        
        public const string ESCAPE = "/";

        public const string PATH_JSON = "json";

        public const string PATH_XML = "xml";

        public const string PATH_CSV = "csv";

        public const string PATH_EXTENSION_JSON = PATH_EXTENSION + PATH_JSON;

        public const string PATH_EXTENSION_XML = PATH_EXTENSION + PATH_XML;

        public const string PATH_EXTENSION_CSV = PATH_EXTENSION + PATH_CSV;
    }
}
