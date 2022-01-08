using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Authorizer.Models
{
    public class DbObject
    {
        [JsonProperty("id")]
        [XmlElement("id")]
        public int Id { get; set; }
    }
}
