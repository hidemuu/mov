using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    [XmlRoot("themes")]
    public class ThemeCollection : DbObjectCollection<Theme>
    {
        [XmlElement(Type = typeof(Theme), ElementName = "theme")]
        public override Theme[] Items { get; set; }
    }

    [XmlRoot("theme")]
    public class Theme : DbObject
    {
        [JsonProperty("color")]
        [XmlElement("color")]
        public string Color { get; set; }
    }
}
