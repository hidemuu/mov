using Mov.Accessors;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    /// <summary>
    /// コンテンツのコレクション
    /// </summary>
    [XmlRoot("contents")]
    public class LayoutContentCollection : DbObjectCollection<LayoutContent>
    {
        /// <inheritdoc />
        [XmlElement(Type = typeof(LayoutContent), ElementName = "content")]
        public override LayoutContent[] Items { get; set; }
    }

    /// <summary>
    /// コンテンツ
    /// </summary>
    [XmlRoot("content")]
    public class LayoutContent : DbObject
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

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutContent()
        {

        }

        /// <summary>
        /// コンストラクター（ディープコピー）
        /// </summary>
        /// <param name="src"></param>
        public LayoutContent(LayoutContent src) : base(src)
        {
            Name = src.Name;
            Icon = src.Icon;
            ControlType = src.ControlType;
            Schema = src.Schema;
            DefaultValues = src.DefaultValues;
            Macro = src.Macro;
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