using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    [XmlRoot("layouts")]
    public class ShellCollection : DbObjectCollection<Shell>
    {
        [XmlElement(Type = typeof(Shell), ElementName = "layout")]
        public override Shell[] Items { get; set; }
    }


    [XmlRoot("layout")]
    public class Shell : DbObject
    {
        #region プロパティ

        [XmlElement("height")]
        public double Height { get; set; }

        [XmlElement("width")]
        public double Width { get; set; }

        [XmlElement("startup_location")]
        public string StartupLocation { get; set; }

        #endregion

        #region メソッド

        public override string ToString() => GetString(new string[] { Id.ToString(), Code });

        public override string ToStringTable() => GetString(new string[] { Id.ToString(), Code }, 10);

        public override string ToStringTableHeader() => GetString(new string[] { "Id", "Code" }, 10);

        #endregion

    }
}
