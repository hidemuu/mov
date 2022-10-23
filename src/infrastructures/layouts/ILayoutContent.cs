using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Layouts
{
    /// <summary>
    /// コンテンツ
    /// </summary>
    public interface ILayoutContent
    {
        /// <summary>
        /// 名称
        /// </summary>
        [XmlElement("name")]
        string Name { get; set; }

        /// <summary>
        /// カテゴリ
        /// </summary>
        [XmlElement("category")]
        string Category { get; set; }

        /// <summary>
        /// アイコン
        /// </summary>
        [XmlElement("icon")]
        string Icon { get; set; }

        /// <summary>
        /// コントロールのスキーマ
        /// </summary>
        [XmlElement("schema")]
        string Schema { get; set; }

        /// <summary>
        /// 初期値
        /// </summary>
        [XmlElement("default_value")]
        string DefaultValue { get; set; }

        /// <summary>
        /// マクロ
        /// </summary>
        [XmlElement("macro")]
        string Macro { get; set; }
    }
}
