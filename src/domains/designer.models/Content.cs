using Mov.Accessors;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    /// <summary>
    /// コンテンツのコレクション
    /// </summary>
    [XmlRoot("contents")]
    public class ContentCollection : DbObjectCollection<Content>
    {
        /// <inheritdoc />
        [XmlElement(Type = typeof(Content), ElementName = "content")]
        public override Content[] Items { get; set; }
    }

    /// <summary>
    /// コンテンツ
    /// </summary>
    [XmlRoot("content")]
    public class Content : DbObject
    {
        #region プロパティ

        /// <summary>
        /// 名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// アイコン
        /// </summary>
        [XmlElement("icon")]
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// コントロールの種類
        /// </summary>
        [XmlElement("control_type")]
        public string ControlType { get; set; } = string.Empty;

        /// <summary>
        /// コントロールのスキーマ
        /// </summary>
        [XmlElement("schema")]
        public string Schema { get; set; } = string.Empty;

        /// <summary>
        /// 初期値
        /// </summary>
        [XmlElement("default_values")]
        public List<string> DefaultValues { get; set; } = new List<string>();

        /// <summary>
        /// マクロ
        /// </summary>
        [XmlElement("macro")]
        public string Macro { get; set; } = string.Empty;

        /// <summary>
        /// 表示・非表示
        /// </summary>
        [XmlElement("visible")]
        public bool IsVisible { get; set; } = true;

        /// <summary>
        /// 活性・非活性
        /// </summary>
        [XmlElement("enable")]
        public bool IsEnable { get; set; } = true;

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
            Schema = src.Schema;
            DefaultValues = src.DefaultValues;
            Macro = src.Macro;
            IsVisible = src.IsVisible;
            IsEnable = src.IsEnable;
        }

        #endregion コンストラクター

        #region メソッド

        /// <inheritdoc />
        public override string ToString() => GetString(new string[] { Id.ToString(), Code });

        /// <inheritdoc />
        public override string ToContentString() => GetString(new string[] { Id.ToString(), Code }, 10);

        /// <inheritdoc />
        public override string ToHeaderString() => GetString(new string[] { "Id", "Code" }, 10);

        #endregion メソッド
    }
}