using Mov.Accessors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    /// <summary>
    /// レイアウトノードのコレクション
    /// </summary>
    [XmlRoot("layouts")]
    public class LayoutNodeCollection : DbObjectCollection<LayoutNode>
    {
        /// <inheritdoc />
        [XmlElement(Type = typeof(LayoutNode), ElementName = "layout")]
        public override LayoutNode[] Items { get; set; }
    }

    /// <summary>
    /// レイアウトノード
    /// </summary>
    [XmlRoot("layout")]
    public class LayoutNode : DbObjectNode<LayoutNode>
    {
        #region プロパティ
        /// <summary>
        /// ノード種別
        /// </summary>
        [XmlElement("node_type")]
        public LayoutNodeType LayoutNodeType { get; set; } = LayoutNodeType.Content;
        /// <summary>
        /// 表示方向
        /// </summary>
        [XmlElement("orientation")]
        public OrientationType OrientationType { get; set; } = OrientationType.Horizontal;
        /// <summary>
        /// スタイル
        /// </summary>
        [XmlElement("style")]
        public string Style { get; set; }
        
        /// <summary>
        /// 展開・非展開
        /// </summary>
        [XmlElement("expand")]
        public bool IsExpand { get; set; } = true;

        /// <summary>
        /// 表示・非表示
        /// </summary>
        [XmlElement("visible")]
        public bool IsVisible { get; set; } = true;

        /// <summary>
        /// 活性・非活性
        /// </summary>
        [XmlElement("enable")]
        public bool IsEnable { get; set; } = true;

        /// <summary>
        /// パラメータ
        /// </summary>
        [XmlElement("parameter")]
        public string Parameter { get; set; }

        /// <summary>
        /// 子階層
        /// </summary>
        [XmlArray("children")]
        [XmlArrayItem("layout")]
        public override List<LayoutNode> Children { get; set; } = new List<LayoutNode>();

        #endregion プロパティ

        #region メソッド

        /// <inheritdoc />
        public override string ToString() => GetString(new string[] { Id.ToString(), Code, LayoutNodeType.ToString() });

        /// <inheritdoc />
        public override string ToContentString() => GetString(new string[] { Id.ToString(), Code, LayoutNodeType.ToString() }, 10);

        /// <inheritdoc />
        public override string ToHeaderString() => GetString(new string[] { "Id", "Code", "LayoutType" }, 10);

        #endregion メソッド


    }
}
