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
    public class UserSettingCollection : DbObjectCollection<UserSetting>
    {
        [JsonProperty("settings")]
        [XmlElement(Type = typeof(UserSetting), ElementName = "setting")]
        public override UserSetting[] Items { get; set; }
    }

    [XmlRoot("setting")]
    public class UserSetting : AppSetting
    {
        #region プロパティ

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

        #endregion

        #region メソッド
        public override string ToString() => GetString(new string[] { Id.ToString(), Code, Category, Name, Value, Description });

        public override string ToStringTable() => GetString(new string[] { Id.ToString(), Code, Category, Name, Value, Description }, 10);

        public override string ToStringTableHeader() => GetString(new string[] { "Id", "Code", "Category", "Name", "Value", "Description" }, 10);


        #endregion
    }
}
