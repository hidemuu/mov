using Mov.Accessors;
using System.Collections.Generic;
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

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("icon")]
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("control_type")]
        public string ControlType { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("control_style")]
        public string ControlStyle { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("schema_type")]
        public string SchemaType { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("default_values")]
        public List<string> DefaultValues { get; set; } = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("command")]
        public string Command { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("macro")]
        public string Macro { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("visible")]
        public bool IsVisible { get; set; } = true;

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("enable")]
        public bool IsEnable { get; set; } = true;

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("parameter")]
        public string Parameter { get; set; } = string.Empty;

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ContentTable()
        {

        }

        /// <summary>
        /// コンストラクター（ディープコピー）
        /// </summary>
        /// <param name="src"></param>
        public ContentTable(ContentTable src) : base(src)
        {
            Name = src.Name;
            Icon = src.Icon;
            ControlType = src.ControlType;
            ControlStyle = src.ControlStyle;
            SchemaType = src.SchemaType;
            DefaultValues = src.DefaultValues;
            Command = src.Command;
            Macro = src.Macro;
            IsVisible = src.IsVisible;
            IsEnable = src.IsEnable;
            Parameter = src.Parameter;
        }

        #endregion コンストラクター

        #region メソッド

        public override string ToString() => GetString(new string[] { Id.ToString(), Code });

        public override string ToStringTable() => GetString(new string[] { Id.ToString(), Code }, 10);

        public override string ToStringTableHeader() => GetString(new string[] { "Id", "Code" }, 10);

        #endregion メソッド
    }
}