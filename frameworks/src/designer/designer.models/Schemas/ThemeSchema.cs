using Mov.Core.Attributes;
using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Mov.Designer.Models.Schemas
{
    /// <summary>
    /// テーマ
    /// </summary>
    [XmlRoot("theme")]
    public class ThemeSchema : DbSchemaBase<Guid>
    {
        [XmlElement("index")]
        [LanguageKey("index")]
        [DisplayName("index")]
        [DisplayIndex(5)]
        public int Index { get; set; }

        [XmlElement("code")]
        [LanguageKey("code")]
        [DisplayName("code")]
        [DisplayIndex(6)]
        public string Code { get; set; }

        /// <summary>
        /// 色
        /// </summary>
        [JsonProperty("color")]
        [XmlElement("color")]
        [LanguageKey("color")]
        [DisplayName("color")]
        [DisplayIndex(10)]
        public string Color { get; set; }

        public static IEnumerable<(PropertyInfo propertyInfo, int index, string name)> GetProperties() => GetProperties<ThemeSchema>().OrderBy(x => x.index);
    }
}