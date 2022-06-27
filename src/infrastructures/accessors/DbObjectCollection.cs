using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Accessors
{
    /// <summary>
    /// データベースオブジェクトのコレクション
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DbObjectCollection<T> where T : DbObject
    {
        #region プロパティ

        /// <summary>
        /// コレクション
        /// </summary>
        [XmlIgnore]
        public abstract T[] Items { get; set; }

        #endregion プロパティ

        #region メソッド

        /// <summary>
        /// 文字列生成
        /// </summary>
        /// <returns></returns>
        public string ToStrings()
        {
            var stringBuilder = new StringBuilder();
            GetStrings(Items, stringBuilder, 0);
            return stringBuilder.ToString();
        }

        #endregion メソッド

        #region 内部メソッド

        /// <summary>
        /// 文字列生成
        /// </summary>
        /// <param name="items"></param>
        /// <param name="stringBuilder"></param>
        /// <param name="hierarchy"></param>
        private void GetStrings(IEnumerable<T> items, StringBuilder stringBuilder, int hierarchy)
        {
            foreach (var item in items)
            {
                for (var i = 0; i < hierarchy; i++)
                {
                    stringBuilder.Append("  ");
                }
                stringBuilder.AppendLine(item.ToString());
            }
        }

        #endregion 内部メソッド
    }
}