using Mov.Accessors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    [XmlRoot("layouts")]
    public class LayoutNodeCollection : DbObjectCollection<LayoutNode>
    {
        [XmlElement(Type = typeof(LayoutNode), ElementName = "layout")]
        public override LayoutNode[] Items { get; set; }
    }

    [XmlRoot("layout")]
    public class LayoutNode : DbObjectNode<LayoutNode>
    {
        #region プロパティ

        [XmlElement("node_type")]
        public LayoutNodeType LayoutNodeType { get; set; } = LayoutNodeType.Content;

        [XmlElement("orientation")]
        public OrientationType OrientationType { get; set; } = OrientationType.Horizontal;

        [XmlElement("style")]
        public string LayoutStyle { get; set; }

        [XmlElement("parameter")]
        public string LayoutParameter { get; set; }

        [XmlElement("expand")]
        public bool IsExpand { get; set; } = true;

        [XmlArray("children")]
        [XmlArrayItem("layout")]
        public override List<LayoutNode> Children { get; set; } = new List<LayoutNode>();

        #endregion プロパティ

        #region メソッド

        public override string ToString() => GetString(new string[] { Id.ToString(), Code, LayoutNodeType.ToString() });

        public override string ToStringTable() => GetString(new string[] { Id.ToString(), Code, LayoutNodeType.ToString() }, 10);

        public override string ToStringTableHeader() => GetString(new string[] { "Id", "Code", "LayoutType" }, 10);

        #endregion メソッド


    }
}
