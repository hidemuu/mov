using Mov.Core.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Core.Repositories.Schemas
{
    /// <summary>
    /// データベースの基本オブジェクト
    /// </summary>
    public class DbTableSchema : IDbSchema<Guid>
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
        public DbTableSchema()
        {
        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="src"></param>
        public DbTableSchema(DbTableSchema src)
        {
            Id = src.Id;
            Index = src.Index;
            Code = src.Code;
        }

        #endregion コンストラクター

        #region メソッド

        public virtual string[] GetContentStrings() => new string[] { Code };

        public virtual string[] GetHeaderStrings() => new string[] { "Code" };

        /// <summary>
        ///ヘッダー文字列取得
        /// </summary>
        /// <returns></returns>
        public string ToHeaderString() => GetString(GetHeaderStrings(), 10);

        /// <summary>
        ///コンテンツ文字列取得
        /// </summary>
        /// <returns></returns>
        public string ToContentString() => GetString(GetContentStrings(), 10);

        #endregion メソッド

        #region オーバーライドメソッド

        /// <inheritdoc />
        public override string ToString() => GetString(GetContentStrings());

        #endregion オーバーライドメソッド

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

        /// <summary>
        /// プロパティを取得
        /// </summary>
        /// <returns></returns>
        protected static IEnumerable<(PropertyInfo propertyInfo, int index, string name)> GetProperties<T>()
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var index = AttributeHelper.GetAttribute<DisplayIndexAttribute>(property).Index;
                var name = AttributeHelper.GetAttribute<DisplayNameAttribute>(property).DisplayName;
                yield return (property, index, name);
            }
        }

        #endregion 継承メソッド
    }
}