using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Translator.Models
{
    [XmlRoot("table")]
    public class CommentTable : ITable<Comment>
    {
        [XmlArray("comments")]
        [XmlArrayItem("comment")]
        public List<Comment> Items { get; set; }
    }

    [XmlRoot("comment")]
    public class Comment : DbObject
    {
        /// <summary>
        /// カテゴリー
        /// </summary>
        [JsonProperty("category")]
        [XmlElement("category")]
        public string Category { get; set; } = "";
        /// <summary>
        /// キーコード
        /// </summary>
        [JsonProperty("code")]
        [XmlElement("code")]
        public string Code { get; set; } = "";
    }
}
