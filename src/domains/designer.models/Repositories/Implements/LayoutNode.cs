using Mov.Accessors;
using Mov.BaseModel;
using Mov.Utilities.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    /// <summary>
    /// レイアウトノードのコレクション
    /// </summary>
    [XmlRoot("nodes")]
    public class LayoutNodeCollection : DbObjectCollection<LayoutNode>
    {
        /// <inheritdoc />
        [XmlElement(Type = typeof(LayoutNode), ElementName = "node")]
        public override LayoutNode[] Items { get; set; }
    }

    /// <summary>
    /// レイアウトノード
    /// </summary>
    [XmlRoot("node")]
    public class LayoutNode : DbObjectNode<LayoutNode>
    {
        #region プロパティ
        /// <summary>
        /// ノード種別
        /// </summary>
        [XmlElement("node_type")]
        [LanguageKey("node_type")]
        [DisplayName("node_type")]
        [DisplayIndex(10)]
        public NodeType NodeType { get; set; } = NodeType.Content;
        /// <summary>
        /// 表示方向
        /// </summary>
        [XmlElement("orientation")]
        [LanguageKey("orientation")]
        [DisplayName("orientation")]
        [DisplayIndex(11)]
        public OrientationType OrientationType { get; set; } = OrientationType.Horizontal;
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
        public override List<LayoutNode> Children { get; set; } = new List<LayoutNode>();

        #endregion プロパティ

        #region メソッド

        /// <inheritdoc />
        public override string[] GetContentStrings() => new string[] { Code, NodeType.ToString() };

        /// <inheritdoc />
        public override string[] GetHeaderStrings() => new string[] { "Code", "LayoutType" };

        public static NodeType[] GetNodeTypes => (NodeType[])Enum.GetValues(typeof(NodeType));

        public static OrientationType[] GetOrientationTypes => (OrientationType[])Enum.GetValues(typeof(OrientationType));

        public static IEnumerable<(PropertyInfo propertyInfo, int index, string name)> GetProperties() => GetProperties<LayoutNode>().OrderBy(x => x.index);


        #endregion メソッド


    }
}
