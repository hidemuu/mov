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

namespace Mov.Designer.Models.Schemas
{
    /// <summary>
    /// テーマのコレクション
    /// </summary>
    [XmlRoot("themes")]
    public class ThemeCollection : DbObjectCollection<ThemeSchema>
    {
        /// <inheritdoc />
        [XmlElement(Type = typeof(ThemeSchema), ElementName = "theme")]
        public override ThemeSchema[] Items { get; set; }
    }

    /// <summary>
    /// テーマ
    /// </summary>
    [XmlRoot("theme")]
    public class ThemeSchema : DbObject
    {
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
