using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    [XmlRoot("layouts")]
    public class ShellLayoutCollection : DbObjectCollection<ShellLayout>
    {
        [XmlElement(Type = typeof(ShellLayout), ElementName = "layout")]
        public override ShellLayout[] Items { get; set; }
    }


    [XmlRoot("layout")]
    public class ShellLayout : DbObject
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
