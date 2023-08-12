using Mov.Core.Repositories.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Core.Configurators.Repositories.Schemas
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
