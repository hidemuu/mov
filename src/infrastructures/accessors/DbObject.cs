using Mov.Utilities.Attributes;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Accessors
{
    /// <summary>
    /// データベースの基本オブジェクト
    /// </summary>
    public class DbObject
    {
        #region プロパティ

        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id")]
        [XmlElement("id")]
        [LanguageKey("id")]
        [DisplayName("id")]
        [DisplayIndex(0)]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// インデックス番号
        /// </summary>
        [JsonProperty("index")]
        [XmlElement("index")]
        [LanguageKey("index")]
        [DisplayName("index")]
        [DisplayIndex(1)]
        public int Index { get; set; } = 0;

        /// <summary>
        /// コード
        /// </summary>
        [JsonProperty("code")]
        [XmlElement("code")]
        [LanguageKey("code")]
        [DisplayName("code")]
        [DisplayIndex(2)]
        public string Code { get; set; } = string.Empty;

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DbObject()
        {
        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="src"></param>
        public DbObject(DbObject src)
        {
            Id = src.Id;
            Index = src.Index;
            Code = src.Code;
        }

        #endregion コンストラクター

        #region メソッド

        /// <inheritdoc />
        public override string ToString() => GetString(new string[] { Id.ToString(), Code });

        /// <summary>
        ///ヘッダー文字列取得
        /// </summary>
        /// <returns></returns>
        public virtual string ToHeaderString() => GetString(new string[] { "Id", "Code", }, 10);

        /// <summary>
        ///コンテンツ文字列取得
        /// </summary>
        /// <returns></returns>
        public virtual string ToContentString() => GetString(new string[] { Id.ToString(), Code, }, 10);

        #endregion メソッド

        #region 継承メソッド

        /// <summary>
        /// 文字列生成ロジック
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        protected static string GetString(string[] strings, int padding = 0)
        {
            var stringBuilder = new StringBuilder();
            foreach (var str in strings)
            {
                if (string.IsNullOrEmpty(str)) continue;
                stringBuilder.Append((str + " ").PadRight(padding));
            }
            return stringBuilder.ToString();
        }

        #endregion 継承メソッド
    }
}