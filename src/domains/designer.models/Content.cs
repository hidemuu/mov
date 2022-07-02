using Mov.Accessors;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    [XmlRoot("tables")]
    public class ContentCollection : DbObjectCollection<Content>
    {
        [XmlElement(Type = typeof(Content), ElementName = "table")]
        public override Content[] Items { get; set; }
    }

    [XmlRoot("table")]
    public class Content : DbObject
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
        [XmlElement("control_schema")]
        public ControlSchemaType ControlSchema { get; set; } = ControlSchemaType.None;

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("default_values")]
        public List<string> DefaultValues { get; set; } = new List<string>();

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
        public Content()
        {

        }

        /// <summary>
        /// コンストラクター（ディープコピー）
        /// </summary>
        /// <param name="src"></param>
        public Content(Content src) : base(src)
        {
            Name = src.Name;
            Icon = src.Icon;
            ControlType = src.ControlType;
            ControlStyle = src.ControlStyle;
            ControlSchema = src.ControlSchema;
            DefaultValues = src.DefaultValues;
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