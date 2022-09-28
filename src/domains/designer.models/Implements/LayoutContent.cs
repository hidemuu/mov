using Mov.Accessors;
using Mov.BaseModel;
using Mov.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    /// <summary>
    /// コンテンツのコレクション
    /// </summary>
    [XmlRoot("contents")]
    public class LayoutContentCollection : DbObjectCollection<LayoutContent>
    {
        /// <inheritdoc />
        [XmlElement(Type = typeof(LayoutContent), ElementName = "content")]
        public override LayoutContent[] Items { get; set; }
    }

    /// <summary>
    /// コンテンツ
    /// </summary>
    [XmlRoot("content")]
    public class LayoutContent : DbObject
    {
        #region プロパティ

        /// <summary>
        /// 名称
        /// </summary>
        [XmlElement("name")]
        [LanguageKey("name")]
        [DisplayName("name")]
        [DisplayIndex(10)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// カテゴリ
        /// </summary>
        [XmlElement("category")]
        [LanguageKey("category")]
        [DisplayName("category")]
        [DisplayIndex(11)]
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// アイコン
        /// </summary>
        [XmlElement("icon")]
        [LanguageKey("icon")]
        [DisplayName("icon")]
        [DisplayIndex(12)]
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// コントロールの種類
        /// </summary>
        [XmlElement("control_type")]
        [LanguageKey("control_type")]
        [DisplayName("control_type")]
        [DisplayIndex(13)]
        public ControlType ControlType { get; set; } = ControlType.Label;

        /// <summary>
        /// コントロールのスキーマ
        /// </summary>
        [XmlElement("schema")]
        [LanguageKey("schema")]
        [DisplayName("schema")]
        [DisplayIndex(14)]
        public string Schema { get; set; } = string.Empty;

        /// <summary>
        /// 初期値
        /// </summary>
        [XmlElement("default_value")]
        [LanguageKey("default_value")]
        [DisplayName("default_value")]
        [DisplayIndex(15)]
        public string DefaultValue { get; set; } = string.Empty;

        /// <summary>
        /// マクロ
        /// </summary>
        [XmlElement("macro")]
        [LanguageKey("macro")]
        [DisplayName("macro")]
        [DisplayIndex(16)]
        public string Macro { get; set; } = string.Empty;

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutContent()
        {

        }

        /// <summary>
        /// コンストラクター（ディープコピー）
        /// </summary>
        /// <param name="src"></param>
        public LayoutContent(LayoutContent src) : base(src)
        {
            Name = src.Name;
            Icon = src.Icon;
            ControlType = src.ControlType;
            Schema = src.Schema;
            DefaultValue = src.DefaultValue;
            Macro = src.Macro;
        }

        #endregion コンストラクター

        #region メソッド

        public static ControlType[] GetControlTypes => (ControlType[])Enum.GetValues(typeof(ControlType));

        public static IEnumerable<(PropertyInfo propertyInfo, int index, string name)> GetProperties() => GetProperties<LayoutContent>().OrderBy(x => x.index);


        #endregion メソッド
    }
}