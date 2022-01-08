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
    [XmlRoot("table")]
    public class UserSettingTable : ITable<UserSetting>
    {
        [XmlArray("settings")]
        [XmlArrayItem("setting")]
        public List<UserSetting> Items { get; set; }
    }

    [XmlRoot("setting")]
    public class UserSetting : DbObject
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
    }
}
