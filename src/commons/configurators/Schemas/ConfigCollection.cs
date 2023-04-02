using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Configurators.Schemas
{
    /// <summary>
    /// 設定のコレクション
    /// </summary>
    [XmlRoot("configs")]
    public class ConfigCollection : DbObjectCollection<Config>
    {
        /// <inheritdoc />
        [JsonProperty("configs")]
        [XmlElement(Type = typeof(Config), ElementName = "config")]
        public override Config[] Items { get; set; }
    }
}
