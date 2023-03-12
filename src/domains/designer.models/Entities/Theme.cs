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

namespace Mov.Designer.Models.Entities
{
    /// <summary>
    /// テーマのコレクション
    /// </summary>
    [XmlRoot("themes")]
    public class ThemeCollection : DbObjectCollection<Theme>
    {
        /// <inheritdoc />
        [XmlElement(Type = typeof(Theme), ElementName = "theme")]
        public override Theme[] Items { get; set; }
    }

    /// <summary>
    /// テーマ
    /// </summary>
    [XmlRoot("theme")]
    public class Theme : DbObject
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

        public static IEnumerable<(PropertyInfo propertyInfo, int index, string name)> GetProperties() => GetProperties<Theme>().OrderBy(x => x.index);

    }

}
