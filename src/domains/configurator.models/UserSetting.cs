using Mov.Accessors;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Mov.Configurator.Models
{
    /// <summary>
    /// ユーザー設定のコレクション
    /// </summary>
    [XmlRoot("settings")]
    public class UserSettingCollection : DbObjectCollection<UserSetting>
    {
        [JsonProperty("settings")]
        [XmlElement(Type = typeof(UserSetting), ElementName = "setting")]
        public override UserSetting[] Items { get; set; }
    }

    /// <summary>
    /// ユーザー設定
    /// </summary>
    [XmlRoot("setting")]
    public class UserSetting : DbObject
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

        /// <summary>
        /// 初期値
        /// </summary>
        [JsonProperty("default")]
        [XmlElement("default")]
        public string Default { get; set; } = string.Empty;

        /// <summary>
        /// アクセスレベル
        /// </summary>
        [JsonProperty("access_lv")]
        [XmlElement("accesslv")]
        public int AccessLv { get; set; } = 0;

        #endregion プロパティ

        #region メソッド

        public override string ToString() => GetString(new string[] { Id.ToString(), Code, Category, Name, Value, Description });

        public override string ToStringTable() => GetString(new string[] { Id.ToString(), Code, Category, Name, Value, Description }, 10);

        public override string ToStringTableHeader() => GetString(new string[] { "Id", "Code", "Category", "Name", "Value", "Description" }, 10);

        #endregion メソッド
    }
}