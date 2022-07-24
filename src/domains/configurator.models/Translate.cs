using Mov.Accessors;
using Mov.Utilities.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Configurator.Models
{
    /// <summary>
    /// 翻訳リスト
    /// </summary>
    [XmlRoot("translates")]
    public class TranslateCollection : DbObjectCollection<Translate>
    {
        /// <inheritdoc />
        [JsonProperty("translates")]
        [XmlElement(Type = typeof(Translate), ElementName = "translate")]
        public override Translate[] Items { get; set; }
    }

    /// <summary>
    /// 翻訳アイテム
    /// </summary>
    [XmlRoot("translate")]
    public class Translate : DbObject
    {
        /// <summary>
        /// 日本語
        /// </summary>
        [JsonProperty("jp")]
        [XmlElement("jp")]
        [LanguageKey("jp")]
        [DisplayName("jp")]
        [DisplayIndex(10)]
        public string JP { get; set; } = "";
        /// <summary>
        /// 英語
        /// </summary>
        [JsonProperty("en")]
        [XmlElement("en")]
        [LanguageKey("en")]
        [DisplayName("en")]
        [DisplayIndex(11)]
        public string EN { get; set; } = "";
        /// <summary>
        /// 中国語
        /// </summary>
        [JsonProperty("cn")]
        [XmlElement("cn")]
        [LanguageKey("cn")]
        [DisplayName("cn")]
        [DisplayIndex(12)]
        public string CN { get; set; } = "";
    }
}
