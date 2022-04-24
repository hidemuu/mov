using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    public class ThemeCollection : DbObjectCollection<Theme>
    {
        public override Theme[] Items { get; set; }
    }

    public class Theme : DbObject
    {
        [JsonProperty("color")]
        [XmlElement("color")]
        public string Color { get; set; }
    }
}
