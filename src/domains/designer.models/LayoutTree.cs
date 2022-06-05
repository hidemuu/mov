using Mov.Accessors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    [XmlRoot("layouts")]
    public class LayoutTreeCollection : DbObjectCollection<LayoutTree>
    {
        [XmlElement(Type = typeof(LayoutTree), ElementName = "layout")]
        public override LayoutTree[] Items { get; set; }
    }

    [XmlRoot("layout")]
    public class LayoutTree : DbObjectNode<LayoutTree>
    {
        #region プロパティ

        [XmlElement("node_type")]
        public LayoutNodeType LayoutNodeType { get; set; } = LayoutNodeType.Content;

        [XmlElement("style")]
        public string LayoutStyle { get; set; }

        [XmlElement("parameter")]
        public string LayoutParameter { get; set; }

        [XmlElement("expand")]
        public bool IsExpand { get; set; } = true;

        [XmlArray("children")]
        [XmlArrayItem("layout")]
        public override List<LayoutTree> Children { get; set; } = new List<LayoutTree>();

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutTree()
        {

        }

        #endregion コンストラクター

        #region メソッド

        public override string ToString() => GetString(new string[] { Id.ToString(), Code, LayoutNodeType.ToString() });

        public override string ToStringTable() => GetString(new string[] { Id.ToString(), Code, LayoutNodeType.ToString() }, 10);

        public override string ToStringTableHeader() => GetString(new string[] { "Id", "Code", "LayoutType" }, 10);

        #endregion メソッド


    }
}
