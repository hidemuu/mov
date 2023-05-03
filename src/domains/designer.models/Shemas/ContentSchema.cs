using Mov.Accessors;
using Mov.Layouts;
using Mov.Schemas.Layouts.Styles;
using Mov.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Mov.Designer.Models.Schemas
{
    /// <summary>
    /// コンテンツのコレクション
    /// </summary>
    [XmlRoot("contents")]
    public class ContentCollection : DbObjectCollection<ContentSchema>
    {
        /// <inheritdoc />
        [XmlElement(Type = typeof(ContentSchema), ElementName = "content")]
        public override ContentSchema[] Items { get; set; }
    }

    /// <summary>
    /// コンテンツ
    /// </summary>
    [XmlRoot("content")]
    public class ContentSchema : DbObject
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
        public string ControlType { get; set; } = ControlStyle.Label.Value;

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

        /// <summary>
        /// 高さ
        /// </summary>
        [XmlElement("height")]
        [LanguageKey("height")]
        [DisplayName("height")]
        [DisplayIndex(17)]
        public double Height { get; set; } = 32;

        /// <summary>
        /// 幅
        /// </summary>
        [XmlElement("width")]
        [LanguageKey("width")]
        [DisplayName("width")]
        [DisplayIndex(18)]
        public double Width { get; set; } = 100;

        /// <summary>
        /// 水平位置
        /// </summary>
        [XmlElement("horizontal_alignment")]
        [LanguageKey("horizontal_alignment")]
        [DisplayName("horizontal_alignment")]
        [DisplayIndex(19)]
        public string HorizontalAlignment { get; set; } = HorizontalAlignmentStyle.Left.Value;

        /// <summary>
        /// 垂直位置
        /// </summary>
        [XmlElement("vertical_alignment")]
        [LanguageKey("vertical_alignment")]
        [DisplayName("vertical_alignment")]
        [DisplayIndex(20)]
        public string VerticalAlignment { get; set; } = VerticalAlignmentStyle.Center.Value;

        /// <summary>
        /// パラメータ
        /// </summary>
        [XmlElement("parameter")]
        [LanguageKey("parameter")]
        [DisplayName("parameter")]
        [DisplayIndex(21)]
        public string Parameter { get; set; } = string.Empty;

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ContentSchema()
        {

        }

        /// <summary>
        /// コンストラクター（ディープコピー）
        /// </summary>
        /// <param name="src"></param>
        public ContentSchema(ContentSchema src) : base(src)
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

        public static IEnumerable<(PropertyInfo propertyInfo, int index, string name)> GetProperties() => GetProperties<ContentSchema>().OrderBy(x => x.index);

        #endregion メソッド
    }
}