using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Driver.Models.Entities.Schemas
{
    /// <summary>
    /// 値のコレクション
    /// </summary>
    [XmlRoot("variables")]
    public class VariableCollection : DbObjectCollection<Variable>
    {
        /// <inheritdoc />
        [JsonProperty("variables")]
        [XmlElement(Type = typeof(Variable), ElementName = "variable")]
        public override Variable[] Items { get; set; }
    }

    /// <summary>
    /// 値
    /// </summary>
    [XmlRoot("variable")]
    public class Variable : DbObject
    {
        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty("name")]
        [XmlElement("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// スキーマ名
        /// </summary>
        [JsonProperty("schema")]
        [XmlElement("schema")]
        public string Schema { get; set; } = string.Empty;

        /// <summary>
        /// 設定値
        /// </summary>
        [JsonProperty("value")]
        [XmlElement("value")]
        public string Value { get; set; } = string.Empty;
    }
}
