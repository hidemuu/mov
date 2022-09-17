using Mov.Accessors;
using Mov.BaseModel;
using Mov.Utilities.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Mov.Configurator.Models
{
    /// <summary>
    /// 設定のコレクション
    /// </summary>
    [XmlRoot("user_settings")]
    public class ConfigCollection : DbObjectCollection<Config>
    {
        /// <inheritdoc />
        [JsonProperty("user_settings")]
        [XmlElement(Type = typeof(Config), ElementName = "user_setting")]
        public override Config[] Items { get; set; }
    }

    /// <summary>
    /// 設定
    /// </summary>
    [XmlRoot("user_setting")]
    public class Config : DbObject
    {
        #region プロパティ

        /// <summary>
        /// カテゴリー
        /// </summary>
        [JsonProperty("category")]
        [XmlElement("category")]
        [LanguageKey("category")]
        [DisplayName("category")]
        [DisplayIndex(10)]
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty("name")]
        [XmlElement("name")]
        [LanguageKey("name")]
        [DisplayName("name")]
        [DisplayIndex(11)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 設定値
        /// </summary>
        [JsonProperty("value")]
        [XmlElement("value")]
        [LanguageKey("value")]
        [DisplayName("value")]
        [DisplayIndex(12)]
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// 初期値
        /// </summary>
        [JsonProperty("default")]
        [XmlElement("default")]
        [LanguageKey("default")]
        [DisplayName("default")]
        [DisplayIndex(13)]
        public string Default { get; set; } = string.Empty;

        /// <summary>
        /// 内容説明
        /// </summary>
        [StringLength(100)]
        [JsonProperty("description")]
        [XmlElement("description")]
        [LanguageKey("description")]
        [DisplayName("description")]
        [DisplayIndex(14)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// アクセスレベル
        /// </summary>
        [JsonProperty("access_lv")]
        [XmlElement("accesslv")]
        [LanguageKey("accesslv")]
        [DisplayName("access_lv")]
        [DisplayIndex(15)]
        public int AccessLv { get; set; } = 0;

        #endregion プロパティ

        #region メソッド

        /// <inheritdoc />
        public override string ToString() => GetString(new string[] { Id.ToString(), Code, Category, Name, Value, Description });

        /// <inheritdoc />
        public override string ToContentString() => GetString(new string[] { Id.ToString(), Code, Category, Name, Value, Description }, 10);

        /// <inheritdoc />
        public override string ToHeaderString() => GetString(new string[] { "Id", "Code", "Category", "Name", "Value", "Description" }, 10);

        public static IEnumerable<(PropertyInfo propertyInfo, int index, string name)> GetProperties() => GetProperties<Config>().OrderBy(x => x.index);

        #endregion メソッド
    }
}