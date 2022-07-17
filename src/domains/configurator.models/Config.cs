using Mov.Accessors;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Mov.Configurator.Models
{
    /// <summary>
    /// 設定のコレクション
    /// </summary>
    [XmlRoot("configs")]
    public class ConfigCollection : DbObjectCollection<Config>
    {
        /// <inheritdoc />
        [JsonProperty("configs")]
        [XmlElement(Type = typeof(Config), ElementName = "config")]
        public override Config[] Items { get; set; }
    }

    /// <summary>
    /// 設定
    /// </summary>
    [XmlRoot("config")]
    public class Config : DbObject
    {
        #region プロパティ

        /// <summary>
        /// カテゴリー
        /// </summary>
        [DisplayName("カテゴリ")]
        [JsonProperty("category")]
        [XmlElement("category")]
        public string Category { get; set; } = "";

        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty("name")]
        [XmlElement("name")]
        public string Name { get; set; } = "";

        /// <summary>
        /// 設定値
        /// </summary>
        [JsonProperty("value")]
        [XmlElement("value")]
        public string Value { get; set; } = "";

        /// <summary>
        /// 内容説明
        /// </summary>
        [StringLength(100)]
        [JsonProperty("description")]
        [XmlElement("description")]
        public string Description { get; set; } = "";

        /// <summary>
        /// 初期値
        /// </summary>
        [JsonProperty("default")]
        [XmlElement("default")]
        public string Default { get; set; } = string.Empty;

        /// <summary>
        /// アクセスレベル
        /// </summary>
        [JsonProperty("access_lv")]
        [XmlElement("accesslv")]
        public int AccessLv { get; set; } = 0;

        #endregion プロパティ

        #region メソッド

        /// <inheritdoc />
        public override string ToString() => GetString(new string[] { Id.ToString(), Code, Category, Name, Value, Description });

        /// <inheritdoc />
        public override string ToContentString() => GetString(new string[] { Id.ToString(), Code, Category, Name, Value, Description }, 10);

        /// <inheritdoc />
        public override string ToHeaderString() => GetString(new string[] { "Id", "Code", "Category", "Name", "Value", "Description" }, 10);

        #endregion メソッド
    }
}