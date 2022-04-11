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

        [XmlElement("layouttype")]
        public string LayoutType { get; set; }

        public string LayoutStyle { get; set; }

        public string LayoutParameter { get; set; }

        public bool IsExpand { get; set; }

        [XmlArray("children")]
        [XmlArrayItem("layout")]
        public override List<LayoutTree> Children { get; set; }

        #endregion

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutTree()
        {

        }

        #region メソッド

        public override string ToString() => GetString(new string[] { Id.ToString(), Code, LayoutType });

        public override string ToStringTable() => GetString(new string[] { Id.ToString(), Code, LayoutType }, 10);

        public override string ToStringTableHeader() => GetString(new string[] { "Id", "Code", "LayoutType" }, 10);

        #endregion


    }
}
