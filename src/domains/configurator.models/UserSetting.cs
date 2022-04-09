using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Configurator.Models
{
    [XmlRoot("setting")]
    public class UserSetting : ConfiguratorObject
    {
        /// <summary>
        /// 初期値
        /// </summary>
        [JsonProperty("default")]
        [XmlElement("default")]
        public string Default { get; set; } = "";
        /// <summary>
        /// アクセスレベル
        /// </summary>
        [JsonProperty("access_lv")]
        [XmlElement("accesslv")]
        public int AccessLv { get; set; } = 0;

        public override string ToString() =>  GetString(new string[] { Id.ToString(), Code, Default, AccessLv.ToString() });
    }
}
