using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Translator.Models
{
    public class DbObject
    {
        [JsonProperty("id")]
        [XmlElement("id")]
        public int Id { get; set; }
        /// <summary>
        /// 日本語
        /// </summary>
        [JsonProperty("jp")]
        [XmlElement("jp")]
        public string JP { get; set; } = "";
        /// <summary>
        /// 英語
        /// </summary>
        [JsonProperty("en")]
        [XmlElement("en")]
        public string EN { get; set; } = "";
        /// <summary>
        /// 中国語
        /// </summary>
        [JsonProperty("cn")]
        [XmlElement("cn")]
        public string CN { get; set; } = "";
    }
}
