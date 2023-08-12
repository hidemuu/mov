using Mov.Core.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using System.Linq;
using Mov.Core.Repositories.Models.Entities;
using Mov.Core.Repositories.Models;

namespace Mov.Core.Configurators.Repositories.Schemas
{
    /// <summary>
    /// 設定
    /// </summary>
    [XmlRoot("config")]
    public class ConfigSchema : DbObjectBase<Guid>
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

        public static IEnumerable<(PropertyInfo propertyInfo, int index, string name)> GetProperties() => GetProperties<ConfigSchema>().OrderBy(x => x.index);

        #endregion メソッド
    }
}
