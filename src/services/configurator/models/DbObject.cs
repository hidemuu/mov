using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Configurator.Models
{
    public class DbObject
    {
        [JsonProperty("id")]
        [XmlElement("id")]
        public int Id { get; set; }
        /// <summary>
        /// カテゴリー
        /// </summary>
        [DisplayName("カテゴリ")]
        [JsonProperty("category")]
        [XmlElement("category")]
        public string Category { get; set; } = "";
        /// <summary>
        /// キーコード
        /// </summary>
        [JsonProperty("code")]
        [XmlElement("code")]
        public string Code { get; set; } = "";
        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty("name")]
        [XmlElement("name")]
        public string Name { get; set; } = "";
        /// <summary>
        /// 設定値
        /// </summary>
        [JsonProperty("value")]
        [XmlElement("value")]
        public string Value { get; set; } = "";
        /// <summary>
        /// 内容説明
        /// </summary>
        [StringLength(100)]
        [JsonProperty("description")]
        [XmlElement("description")]
        public string Description { get; set; } = "";
    }
}
