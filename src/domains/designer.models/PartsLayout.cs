using Mov.Accessors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    [XmlRoot("layouts")]
    public class PartsLayoutCollection : DbObjectCollection<PartsLayout>
    {
        [XmlElement(Type = typeof(PartsLayout), ElementName = "layout")]
        public override PartsLayout[] Items { get; set; }
    }

    [XmlRoot("layout")]
    public class PartsLayout : DbObjectNode<PartsLayout>
    {
        #region プロパティ

        [XmlElement("nodetype")]
        public string NodeType { get; set; }

        [XmlArray("children")]
        [XmlArrayItem("layout")]
        public override List<PartsLayout> Children { get; set; }

        #endregion

        /// <summary>
        /// コンストラクター
        /// </summary>
        public PartsLayout()
        {

        }

        #region メソッド

        public override string ToString() => GetString(new string[] { Id.ToString(), Code, NodeType });

        public override string ToStringTable() => GetString(new string[] { Id.ToString(), Code, NodeType }, 10);

        public override string ToStringTableHeader() => GetString(new string[] { "Id", "Code", "NodeType" }, 10);

        #endregion


    }
}
