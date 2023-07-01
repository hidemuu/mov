using Mov.Core.Models.Entities.DbObjects;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Mov.Driver.Models.Entities.Schemas
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
        /// 左辺
        /// </summary>
        [JsonProperty("left_side")]
        [XmlElement("left_side")]
        public string LeftSide = string.Empty;

        /// <summary>
        /// 等号・不等号
        /// </summary>
        [JsonProperty("sign")]
        [XmlElement("sign")]
        public string Sign = string.Empty;

        /// <summary>
        /// 右辺
        /// </summary>
        [JsonProperty("right_side")]
        [XmlElement("right_side")]
        public string RightSide = string.Empty;
    }
}