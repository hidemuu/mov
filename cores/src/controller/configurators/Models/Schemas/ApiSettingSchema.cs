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

        /// <summary>
        /// 設定値
        /// </summary>
        [JsonProperty("value")]
        [XmlElement("value")]
        [LanguageKey("value")]
        [DisplayName("value")]
        [DisplayIndex(10)]
        public string Value { get; set; } = string.Empty;
    }
}
