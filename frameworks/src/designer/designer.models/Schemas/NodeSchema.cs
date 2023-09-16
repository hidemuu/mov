using Mov.Core.Attributes;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas;
using Mov.Core.Styles.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Mov.Designer.Models.Schemas
{
    /// <summary>
    /// レイアウトノード
    /// </summary>
    [XmlRoot("node")]
    public class NodeSchema : DbNodeSchemaBase<NodeSchema, Guid>
    {
        #region プロパティ

        [XmlElement("index")]
        [LanguageKey("index")]
        [DisplayName("index")]
        [DisplayIndex(5)]
        public int Index { get; set; }

        [XmlElement("code")]
        [LanguageKey("code")]
        [DisplayName("code")]
        [DisplayIndex(6)]
        public string Code { get; set; }

        /// <summary>
        /// ノード種別
        /// </summary>
        [XmlElement("node_type")]
        [LanguageKey("node_type")]
        [DisplayName("node_type")]
        [DisplayIndex(10)]
        public string NodeType { get; set; } = "Content";

        /// <summary>
        /// 表示方向
        /// </summary>
        [XmlElement("orientation")]
        [LanguageKey("orientation")]
        [DisplayName("orientation")]
        [DisplayIndex(11)]
        public string OrientationType { get; set; } = OrientationStyle.Horizontal.Value;

        /// <summary>
        /// スタイル
        /// </summary>
        [XmlElement("style")]
        [LanguageKey("style")]
        [DisplayName("style")]
        [DisplayIndex(12)]
        public string Style { get; set; }

        /// <summary>
        /// 展開・非展開
        /// </summary>
        [XmlElement("expand")]
        [LanguageKey("expand")]
        [DisplayName("expand")]
        [DisplayIndex(13)]
        public bool IsExpand { get; set; } = true;

        /// <summary>
        /// 表示・非表示
        /// </summary>
        [XmlElement("visible")]
        [LanguageKey("visible")]
        [DisplayName("visible")]
        [DisplayIndex(14)]
        public bool IsVisible { get; set; } = true;

        /// <summary>
        /// 活性・非活性
        /// </summary>
        [XmlElement("enable")]
        [LanguageKey("enable")]
        [DisplayName("enable")]
        [DisplayIndex(15)]
        public bool IsEnable { get; set; } = true;

        /// <summary>
        /// パラメータ
        /// </summary>
        [XmlElement("parameter")]
        [LanguageKey("parameter")]
        [DisplayName("parameter")]
        [DisplayIndex(16)]
        public string Parameter { get; set; }

        /// <summary>
        /// 子階層
        /// </summary>
        [XmlArray("children")]
        [XmlArrayItem("node")]
        [LanguageKey("children")]
        [DisplayName("children")]
        [DisplayIndex(17)]
        public override List<NodeSchema> Children { get; set; } = new List<NodeSchema>();

        #endregion プロパティ

        #region メソッド

        public static IEnumerable<(PropertyInfo propertyInfo, int index, string name)> GetProperties() => GetProperties<NodeSchema>().OrderBy(x => x.index);

        #endregion メソッド
    }
}