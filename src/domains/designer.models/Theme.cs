using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models
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
        public string Color { get; set; }
    }
}
