using Mov.Core.Contexts.DbObjects.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Mov.Configurator.Models.Entities
{
    /// <summary>
    /// スキーマのコレクション
    /// </summary>
    [XmlRoot("parameters")]
    public class ParameterSchemaCollection : DbObjectCollection<ParameterSchema>
    {
        /// <inheritdoc />
        [JsonProperty("parameters")]
        [XmlElement(Type = typeof(ParameterSchema), ElementName = "parameter")]
        public override ParameterSchema[] Items { get; set; }
    }

    /// <summary>
    /// スキーマ
    /// </summary>
    [XmlRoot("parameter")]
    public class ParameterSchema : DbObject
    {
        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty("name")]
        [XmlElement("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// スキーマタイプ
        /// </summary>
        [JsonProperty("schema_type")]
        [XmlElement("schema_type")]
        public SchemaType SchemaType { get; set; } = SchemaType.None;

        /// <summary>
        /// 設定項目リスト
        /// </summary>
        [JsonProperty("selections")]
        [XmlElement("selections")]
        public List<string> Selections { get; set; } = new List<string>();

        /// <summary>
        /// 初期値
        /// </summary>
        [JsonProperty("default_value")]
        [XmlElement("default_value")]
        public string DefaultValue { get; set; } = string.Empty;

        /// <summary>
        /// 参照可否
        /// </summary>
        [JsonProperty("referencable")]
        [XmlElement("referencable")]
        public bool Referencable { get; set; } = true;

        /// <summary>
        /// 読出/書込 (R:読出専用 W:書込専用 それ以外:読書可能
        /// </summary>
        [JsonProperty("read_write")]
        [DisplayName("読み書き")]
        public string ReadWrite { get; set; } = string.Empty;

        /// <summary>
        /// 内容説明
        /// </summary>
        [StringLength(100)]
        [JsonProperty("description")]
        [XmlElement("description")]
        public string Description { get; set; } = string.Empty;
    }
}