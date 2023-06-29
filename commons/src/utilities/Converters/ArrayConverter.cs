namespace Mov.Core.Converters
{
    public static class ArrayConverter
    {
        /// <summary>
        /// 任意型配列を文字列情報に変換し出力
        /// </summary>
        /// <param name="items">変換元任意型文字列</param>
        /// <param name="delimiter">区切り文字</param>
        /// <returns>変換結果文字列</returns>
        public static string ConvertObjArrayToString(object[] items, string delimiter = " ")
        {
            string result = "";
            foreach (var item in items)
            {
                if (result != "") result += delimiter + item.ToString();
                else result = item.ToString();
            }
            return result;
        }
        /// <summary>
        /// 文字列配列を文字列情報に変換し出力
        /// </summary>
        /// <param name="items">変換元任意型文字列</param>
        /// <param name="delimiter">区切り文字</param>
        /// <returns>変換結果文字列</returns>
        public static string ConvertStrArrayToString(string[] items, string delimiter = " ")
        {
            string result = "";
            foreach (var item in items)
            {
                if (result != "") result += delimiter + item.ToString();
                else result = item.ToString();
            }
            return result;
        }
        /// <summary>
        /// bool型配列を文字列情報に変換し出力
        /// </summary>
        /// <param name="items">変換元bool型配列</param>
        /// <param name="delimiter">区切り文字</param>
        /// <returns>変換結果文字列</returns>
        public static string ConvertBoolArrayToString(bool[] items, string delimiter = " ")
        {
            string result = "";
            foreach (var item in items)
            {
                if (result != "") result += delimiter + item.ToString();
                else result = item.ToString();
            }
            return result;
        }

        /// <summary>
        /// int型配列を文字列情報に変換し出力
        /// </summary>
        /// <param name="items">変換元int型文字列</param>
        /// <param name="delimiter">区切り文字</param>
        /// <returns>変換結果文字列</returns>
        public static string ConvertIntArrayToString(int[] items, string delimiter = " ")
        {
            string result = "";
            foreach (var item in items)
            {
                if (result != "") result += delimiter + item.ToString();
                else result = item.ToString();
            }
            return result;
        }

    }
}
