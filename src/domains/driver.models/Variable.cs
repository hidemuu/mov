using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Driver.Models
{
    /// <summary>
    /// 変数のコレクション
    /// </summary>
    [XmlRoot("variables")]
    public class VariableCollection : DbObjectCollection<Variable>
    {
        /// <summary>
        /// コレクション
        /// </summary>
        [JsonProperty("variables")]
        [XmlElement(Type = typeof(Variable), ElementName = "variable")]
        public override Variable[] Items { get; set; }
    }

    /// <summary>
    /// 変数
    /// </summary>
    [XmlRoot("variable")]
    public class Variable : DbObject
    {
        #region プロパティ

        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty("name")]
        [XmlElement("name")]
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// 設定値
        /// </summary>
        [JsonProperty("value")]
        [XmlElement("value")]
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// データタイプ
        /// </summary>
        [JsonProperty("data_type")]
        [XmlElement("data_type")]
        public string DataType { get; set; } = string.Empty;
        
        /// <summary>
        /// 内容説明
        /// </summary>
        [StringLength(100)]
        [JsonProperty("description")]
        [XmlElement("description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 読出/書込 (R:読出専用 W:書込専用 それ以外:読書可能
        /// </summary>
        [JsonProperty("readwrite")]
        [DisplayName("読み書き")]
        public string RW { get; set; } = string.Empty;

        #endregion

    }
}
