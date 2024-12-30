using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Mov.Core.Accessors.Test.Models
{
    [JsonObject]
    [XmlRoot("test")]
    public class SerializeSchema
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
