using Mov.Accessors;
using Mov.Utilities.Attributes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
        [LanguageKey("height")]
        [DisplayName("height")]
        [DisplayIndex(10)]
        public double Height { get; set; }

        /// <summary>
        /// 幅
        /// </summary>
        [XmlElement("width")]
        [LanguageKey("width")]
        [DisplayName("width")]
        [DisplayIndex(11)]
        public double Width { get; set; }

        /// <summary>
        /// 初期表示位置
        /// </summary>
        [XmlElement("startup_location")]
        [LanguageKey("startup_location")]
        [DisplayName("startup_location")]
        [DisplayIndex(12)]
        public string StartupLocation { get; set; }

        #endregion プロパティ

        #region メソッド

        /// <inheritdoc />
        public override string ToString() => GetString(new string[] { Id.ToString(), Code });

        /// <inheritdoc />
        public override string ToContentString() => GetString(new string[] { Id.ToString(), Code }, 10);

        /// <inheritdoc />
        public override string ToHeaderString() => GetString(new string[] { "Id", "Code" }, 10);

        public static IEnumerable<(PropertyInfo propertyInfo, int index, string name)> GetProperties() => GetProperties<Shell>().OrderBy(x => x.index);


        #endregion メソッド
    }
}