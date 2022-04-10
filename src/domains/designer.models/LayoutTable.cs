using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    [XmlRoot("tables")]
    public class LayoutTableCollection : DbObjectCollection<LayoutTable>
    {
        [XmlElement(Type = typeof(LayoutTable), ElementName = "table")]
        public override LayoutTable[] Items { get; set; }

    }

    [XmlRoot("table")]
    public class LayoutTable : DbObject
    {
        #region プロパティ


        
        #endregion

        #region メソッド

        public override string ToString() => GetString(new string[] { Id.ToString(), Code });

        public override string ToStringTable() => GetString(new string[] { Id.ToString(), Code }, 10);

        public override string ToStringTableHeader() => GetString(new string[] { "Id", "Code" }, 10);


        #endregion
    }
}
