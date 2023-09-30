using Mov.Core.Attributes;
using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Mov.Core.Configurators.Models.Schemas
{
    /// <summary>
    /// 設定
    /// </summary>
    [XmlRoot("config")]
    public class UserSettingSchema : DbSchemaBase<Guid>
    {
        #region peoperty

        /// <summary>
        /// Index
        /// </summary>
        [XmlElement("index")]
        [LanguageKey("index")]
        [DisplayName("index")]
        [DisplayIndex(5)]
        public int Index { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        [XmlElement("code")]
        [LanguageKey("code")]
        [DisplayName("code")]
        [DisplayIndex(6)]
        public string Code { get; set; }

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

        #endregion peoperty

        #region method

        public override string ToString()
        {
            return $"{base.ToString()} {Index} {Code} {Name} {Value}";
        }

        public static IEnumerable<(PropertyInfo propertyInfo, int index, string name)> GetProperties() => GetProperties<UserSettingSchema>().OrderBy(x => x.index);

        #endregion method
    }
}