﻿using Mov.Core.Contexts.DbObjects.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Mov.Configurator.Models.Entities
{
    /// <summary>
    /// エラーのコレクション
    /// </summary>
    [XmlRoot("errors")]
    public class ErrorCollection : DbObjectCollection<ErrorSchema>
    {
        /// <inheritdoc />
        [JsonProperty("errors")]
        [XmlElement(Type = typeof(ErrorSchema), ElementName = "error")]
        public override ErrorSchema[] Items { get; set; }
    }

    /// <summary>
    /// エラー
    /// </summary>
    [XmlRoot("error")]
    public class ErrorSchema : DbObject
    {
        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty("name")]
        [XmlElement("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// レベル
        /// </summary>
        [JsonProperty("lv")]
        [XmlElement("lv")]
        public int Lv { get; set; } = 0;

        /// <summary>
        /// 解除可否
        /// </summary>
        [JsonProperty("clearable")]
        [XmlElement("clearable")]
        public bool Clearable { get; set; } = true;

        /// <summary>
        /// 内容説明
        /// </summary>
        [StringLength(100)]
        [JsonProperty("description")]
        [XmlElement("description")]
        public string Description { get; set; } = string.Empty;
    }
}