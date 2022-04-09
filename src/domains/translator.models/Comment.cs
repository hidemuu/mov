using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Translator.Models
{
    [XmlRoot("comment")]
    public class Comment : TranslatorObject
    {
        /// <summary>
        /// カテゴリー
        /// </summary>
        [JsonProperty("category")]
        [XmlElement("category")]
        public string Category { get; set; } = "";
    }
}
