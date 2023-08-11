using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mov.Core.Accessors.Test.Models
{
    [XmlRoot("tests")]
    public class SerializeSchemaCollection
    {
        [JsonProperty("tests")]
        [XmlElement(Type = typeof(SerializeSchema), ElementName = "test")]
        public SerializeSchema[] Schemas { get; set; }
    }
}
