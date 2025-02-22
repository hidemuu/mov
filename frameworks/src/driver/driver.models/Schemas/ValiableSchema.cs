﻿using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Mov.Driver.Models.Schemas
{
    /// <summary>
    /// 値
    /// </summary>
    [XmlRoot("variable")]
    public class VariableSchema : DbSchemaBase<Guid>
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
