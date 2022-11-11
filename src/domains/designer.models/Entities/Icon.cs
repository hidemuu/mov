using Mov.Accessors;
using Mov.Utilities.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    /// <summary>
    /// アイコンリスト
    /// </summary>
    [XmlRoot("icons")]
    public class IconCollection : DbObjectCollection<Icon>
    {
        /// <inheritdoc />
        [JsonProperty("icons")]
        public override Icon[] Items { get; set; }
    }

    /// <summary>
    /// アイコン
    /// </summary>
    [XmlRoot("icon")]
    public class Icon : DbObject
    {
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
        /// パス
        /// </summary>
        [JsonProperty("path")]
        [XmlElement("path")]
        [LanguageKey("path")]
        [DisplayName("path")]
        [DisplayIndex(12)]
        public string Path { get; set; } = string.Empty;

        public static IEnumerable<(PropertyInfo propertyInfo, int index, string name)> GetProperties() => GetProperties<Icon>().OrderBy(x => x.index);
    }
}
