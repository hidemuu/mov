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
    [XmlRoot("settings")]
    public class AppSettingCollection : DbObjectCollection<AppSetting>
    {
        [JsonProperty("settings")]
        [XmlElement(Type = typeof(AppSetting), ElementName = "setting")]
        public override AppSetting[] Items { get; set; }
    }

    [XmlRoot("setting")]
    public class AppSetting : DbObject
    {
        #region プロパティ

        /// <summary>
        /// カテゴリー
        /// </summary>
        [DisplayName("カテゴリ")]
        [JsonProperty("category")]
        [XmlElement("category")]
        public string Category { get; set; } = "";
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

        #endregion

        #region メソッド
        public override string ToString() => GetString(new string[] { Id.ToString(), Code, Category, Name, Value, Description });

        public override string ToStringTable() => GetString(new string[] { Id.ToString(), Code, Category, Name, Value, Description }, 10);

        public override string ToStringTableHeader() => GetString(new string[] { "Id", "Code", "Category", "Name", "Value", "Description" }, 10);


        #endregion
    }
}
