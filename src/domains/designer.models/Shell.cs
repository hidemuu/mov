using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    /// <summary>
    /// シェル（フレーム）のコレクション
    /// </summary>
    [XmlRoot("shells")]
    public class ShellCollection : DbObjectCollection<Shell>
    {
        /// <inheritdoc />
        [XmlElement(Type = typeof(Shell), ElementName = "shell")]
        public override Shell[] Items { get; set; }
    }

    /// <summary>
    /// シェル（フレーム）
    /// </summary>
    [XmlRoot("shell")]
    public class Shell : DbObject
    {
        #region プロパティ
        /// <summary>
        /// 高さ
        /// </summary>
        [XmlElement("height")]
        public double Height { get; set; }
        /// <summary>
        /// 幅
        /// </summary>
        [XmlElement("width")]
        public double Width { get; set; }
        /// <summary>
        /// 初期表示位置
        /// </summary>
        [XmlElement("startup_location")]
        public string StartupLocation { get; set; }

        #endregion

        #region メソッド

        /// <inheritdoc />
        public override string ToString() => GetString(new string[] { Id.ToString(), Code });

        /// <inheritdoc />
        public override string ToContentString() => GetString(new string[] { Id.ToString(), Code }, 10);

        /// <inheritdoc />
        public override string ToHeaderString() => GetString(new string[] { "Id", "Code" }, 10);

        #endregion

    }
}
