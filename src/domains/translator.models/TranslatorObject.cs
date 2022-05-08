using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Translator.Models
{
    [XmlRoot("translators")]
    public class TranslatorObjectCollection : DbObjectCollection<TranslatorObject>
    {
        [XmlElement(Type = typeof(TranslatorObject), ElementName = "translator")]
        public override TranslatorObject[] Items { get; set; }
    }

    [XmlRoot("translator")]
    public class TranslatorObject : DbObject
    {
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
