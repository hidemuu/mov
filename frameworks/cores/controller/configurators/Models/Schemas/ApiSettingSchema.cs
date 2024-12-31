using Mov.Core.Attributes;
using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Core.Configurators.Models.Schemas
{
    public class ApiSettingSchema : DbSchemaBase<string>
    {
        [JsonProperty("key")]
        [XmlElement("key")]
        [LanguageKey("key")]
        [DisplayName("key")]
        [DisplayIndex(10)]
        public string Key { get; set; } = string.Empty;

        /// <summary>
        /// 設定値
        /// </summary>
        [JsonProperty("value")]
        [XmlElement("value")]
        [LanguageKey("value")]
        [DisplayName("value")]
        [DisplayIndex(11)]
        public string Value { get; set; } = string.Empty;
    }
}
