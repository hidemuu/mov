using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mov.Core.Accessors.Test
{
    [JsonObject]
    [XmlRoot("object")]
    public class SerializeObject
    {
        [JsonProperty("id")]
        [XmlElement("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("content")]
        [XmlElement("content")]
        public string Content { get; set; } = string.Empty;
    }
}
