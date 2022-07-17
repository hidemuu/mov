using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Driver.Models
{
    /// <summary>
    /// マクロのコレクション
    /// </summary>
    [XmlRoot("macros")]
    public class MacroCollection : DbObjectCollection<Macro>
    {
        /// <inheritdoc />
        [JsonProperty("macros")]
        [XmlElement(Type = typeof(Macro), ElementName = "macro")]
        public override Macro[] Items { get; set; }
    }

    /// <summary>
    /// マクロ
    /// </summary>
    [XmlRoot("macro")]
    public class Macro : DbObject
    {
        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty("name")]
        [XmlElement("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 条件式のリスト
        /// </summary>
        [JsonProperty("expressions")]
        [XmlElement("expressions")]
        public List<Expression> Expressions = new List<Expression>();

        /// <summary>
        /// 内容説明
        /// </summary>
        [StringLength(100)]
        [JsonProperty("description")]
        [XmlElement("description")]
        public string Description { get; set; } = string.Empty;
    }

    /// <summary>
    /// 条件式
    /// </summary>
    [XmlRoot("expression")]
    public class Expression
    {
        /// <summary>
        /// スキーマ
        /// </summary>
        [JsonProperty("schema")]
        [XmlElement("schema")]
        public string Schema = string.Empty;

        /// <summary>
        /// 適用値
        /// </summary>
        [JsonProperty("value")]
        [XmlElement("value")]
        public string Value = string.Empty;
    }
}
