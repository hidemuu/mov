using Mov.Core.Repositories.Entities;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Mov.Core.Configurators.Models.Schemas
{
    /// <summary>
    /// 設定のコレクション
    /// </summary>
    [XmlRoot("configs")]
    public class ConfigSchemaCollection : DbTableCollection<ConfigSchema, Guid>
    {
        /// <inheritdoc />
        [JsonProperty("configs")]
        [XmlElement(Type = typeof(ConfigSchema), ElementName = "config")]
        public override ConfigSchema[] Items { get; set; }
    }
}
