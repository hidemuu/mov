using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Translator.Models
{
    [XmlRoot("comments")]
    public class CommentCollection : DbObjectCollection<Comment>
    {
        [XmlElement(Type = typeof(Comment), ElementName = "comment")]
        public override Comment[] Items { get; set; }
    }

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
