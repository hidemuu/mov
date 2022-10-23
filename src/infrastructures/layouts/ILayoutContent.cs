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
        string Name { get; }

        /// <summary>
        /// アイコン
        /// </summary>
        [XmlElement("icon")]
        string Icon { get; }

        /// <summary>
        /// 幅
        /// </summary>
        [XmlElement("width")]
        double Width { get; }

        /// <summary>
        /// 水平位置
        /// </summary>
        [XmlElement("horizontal_alignment")]
        string HorizontalAlignment { get; }

        /// <summary>
        /// 垂直位置
        /// </summary>
        [XmlElement("vertical_alignment")]
        string VerticalAlignment { get; }


        /// <summary>
        /// 高さ
        /// </summary>
        [XmlElement("height")]
        double Height { get; }

        /// <summary>
        /// コントロールのスキーマ
        /// </summary>
        [XmlElement("schema")]
        string Schema { get; }

        /// <summary>
        /// 初期値
        /// </summary>
        [XmlElement("default_value")]
        string DefaultValue { get; }

        /// <summary>
        /// マクロ
        /// </summary>
        [XmlElement("macro")]
        string Macro { get; }
    }
}
