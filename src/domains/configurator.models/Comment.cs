using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Configurator.Models
{
    [XmlRoot("comments")]
    public class CommentCollection : DbObjectCollection<Comment>
    {
        [XmlElement(Type = typeof(Comment), ElementName = "language")]
        public override Comment[] Items { get; set; }
    }

    [XmlRoot("comment")]
    public class Comment : DbObject
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
