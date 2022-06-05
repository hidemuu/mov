using Mov.Accessors;
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

        [XmlElement("name")]
        public string Name { get; set; } = string.Empty;

        [XmlElement("icon")]
        public string Icon { get; set; } = string.Empty;

        [XmlElement("control_type")]
        public string ControlType { get; set; } = string.Empty;

        [XmlElement("control_style")]
        public string ControlStyle { get; set; } = string.Empty;

        [XmlElement("command")]
        public string Command { get; set; } = string.Empty;

        [XmlElement("macro")]
        public string Macro { get; set; } = string.Empty;

        [XmlElement("visible")]
        public bool IsVisible { get; set; } = true;

        [XmlElement("enable")]
        public bool IsEnable { get; set; } = true;

        [XmlElement("parameter")]
        public string Parameter { get; set; } = string.Empty;

        #endregion プロパティ

        #region メソッド

        public override string ToString() => GetString(new string[] { Id.ToString(), Code });

        public override string ToStringTable() => GetString(new string[] { Id.ToString(), Code }, 10);

        public override string ToStringTableHeader() => GetString(new string[] { "Id", "Code" }, 10);

        #endregion メソッド
    }
}