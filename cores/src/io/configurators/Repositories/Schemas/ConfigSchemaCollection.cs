using Mov.Core.Contexts.DbObjects.Entities;
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
    public class ConfigSchemaCollection : DbObjectCollection<ConfigSchema>
    {
        /// <inheritdoc />
        [JsonProperty("configs")]
        [XmlElement(Type = typeof(ConfigSchema), ElementName = "config")]
        public override ConfigSchema[] Items { get; set; }
    }
}
