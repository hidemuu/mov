using System.Collections.Generic;

namespace Mov.Core.Extensions
{
    /// <summary>
    /// List型の拡張処理
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// 重複している要素を抽出して配列で返します
        /// </summary>
        public static T[] GetDistinctToArray<T>(this IList<T> self)
        {
            var uniqueList = new List<T>();
            var result = new List<T>();

            foreach (var n in self)
            {
                if (uniqueList.Contains(n))
                {
                    result.Add(n);
                }
                else
                {
                    uniqueList.Add(n);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// 重複している要素を抽出してリストで返します
        /// </summary>
        public static IEnumerable<T> GetDistinctToList<T>(this IList<T> self)
        {
            var uniqueList = new List<T>();
            var result = new List<T>();

            foreach (var n in self)
            {
                if (uniqueList.Contains(n))
                {
                    result.Add(n);
                }
                else
                {
                    uniqueList.Add(n);
                }
            }

            return result;
        }
    }
}
