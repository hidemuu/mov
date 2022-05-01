using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    [XmlRoot("tables")]
    public class ContentTableCollection : DbObjectCollection<ContentTable>
    {
        [XmlElement(Type = typeof(ContentTable), ElementName = "table")]
        public override ContentTable[] Items { get; set; }

    }

    [XmlRoot("table")]
    public class ContentTable : DbObject
    {
        #region プロパティ

        public string Name { get; set; }

        public string Icon { get; set; }

        public string ControlType { get; set; }

        public string ControlStyle { get; set; }

        public string Command { get; set; }
        
        public string Macro { get; set; }

        public bool IsVisible { get; set; }

        public bool IsEnable { get; set; }

        public string Parameter { get; set; }

        #endregion

        #region メソッド

        public override string ToString() => GetString(new string[] { Id.ToString(), Code });

        public override string ToStringTable() => GetString(new string[] { Id.ToString(), Code }, 10);

        public override string ToStringTableHeader() => GetString(new string[] { "Id", "Code" }, 10);


        #endregion
    }
}
