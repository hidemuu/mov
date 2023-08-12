using CsvHelper.Configuration.Attributes;
using Mov.Core.Repositories.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mov.Core.Repositories.Test.Models
{
    [JsonObject]
    [XmlRoot("test")]
    public class SerializeSchema : IDbObject<int>
    {
        [JsonProperty("id")]
        [XmlElement("id")]
        [Name("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("content")]
        [XmlElement("content")]
        [Name("content")]
        public string Content { get; set; } = string.Empty;
    }
}
