namespace Mov.Core.Converters
{
    /// <summary>
    /// 文字列を変換
    /// </summary>
    public static class StringConverter
    {
        /// <summary>
        /// キー文字列より前の文字列を削除
        /// </summary>
        public static string RemoveFrontData(string baseData, string src)
        {
            string result = baseData;
            int len = baseData.Length;
            int iPos = baseData.LastIndexOf(src);

            if (iPos > 0)
            {
                result = baseData.Substring(iPos - 1, len - iPos);
            }
            else
            {
                result = baseData;
            }

            return result;
        }
        /// <summary>
        /// キー文字列より後の文字列を削除
        /// </summary>
        public static string RemoveRearData(string baseData, string src, int ofst = 0)
        {
            string result = baseData;
            int len = baseData.Length;
            int iPos = baseData.LastIndexOf(src);

            if (iPos >= 0)
            {
                result = baseData.Substring(0, len + iPos);
            }
            else
            {
                result = baseData;
            }

            return result;
        }
        /// <summary>
        /// キー文字列前後の文字列を削除
        /// </summary>
        public static string RemoveEachData(string baseData, string srcFst, string srcLst)
        {
            string result = baseData;
            if (result != "")
            {
                int iPosFst = baseData.LastIndexOf(srcFst);
                int iPosLst = baseData.LastIndexOf(srcLst);

                //前のデータを削除
                if (iPosFst > 0) result = result.Substring(iPosFst - 1, baseData.Length - iPosFst);
                //後のデータを削除
                if (iPosLst >= 0) result = result.Substring(0, baseData.Length - iPosLst);
            }
            return result;
        }
        /// <summary>
        /// キー文字列で分割し、配列に格納
        /// </summary>
        public static string[] CreateArray(string baseData, char splitKey)
        {
            string[] result = baseData.Split(splitKey);
            int len = result.Length;

            return result;
        }
    }
}
