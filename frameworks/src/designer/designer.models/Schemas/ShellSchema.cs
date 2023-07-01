using Mov.Core.Attributes;
using Mov.Core.Layouts.Models.Shells.ValueObjects;
using Mov.Core.Repositories.Models.Entities.DbObjects;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Mov.Designer.Models.Schemas
{
    /// <summary>
    /// シェル（フレーム）のコレクション
    /// </summary>
    [XmlRoot("shells")]
    public class ShellCollection : DbObjectCollection<ShellSchema>
    {
        /// <inheritdoc />
        [XmlElement(Type = typeof(ShellSchema), ElementName = "shell")]
        public override ShellSchema[] Items { get; set; }
    }

    /// <summary>
    /// シェル（フレーム）
    /// </summary>
    [XmlRoot("shell")]
    public class ShellSchema : DbObject
    {
        #region プロパティ

        /// <summary>
        /// 高さ
        /// </summary>
        [XmlElement("height")]
        [LanguageKey("height")]
        [DisplayName("height")]
        [DisplayIndex(10)]
        public double Height { get; set; } = 100.0;

        /// <summary>
        /// 幅
        /// </summary>
        [XmlElement("width")]
        [LanguageKey("width")]
        [DisplayName("width")]
        [DisplayIndex(11)]
        public double Width { get; set; } = 50.0;

        /// <summary>
        /// 表示位置
        /// </summary>
        [XmlElement("location")]
        [LanguageKey("location")]
        [DisplayName("location")]
        [DisplayIndex(12)]
        public string Location { get; set; } = RegionStyle.Center.Value;

        /// <summary>
        /// 背景色
        /// </summary>
        [XmlElement("background_color")]
        [LanguageKey("background_color")]
        [DisplayName("background_color")]
        [DisplayIndex(13)]
        public string BackgroundColor { get; set; } = "Transparent";

        /// <summary>
        /// ボーダー色
        /// </summary>
        [XmlElement("border_color")]
        [LanguageKey("border_color")]
        [DisplayName("border_color")]
        [DisplayIndex(14)]
        public string BorderColor { get; set; } = "Transparent";

        /// <summary>
        /// ボーダー太さ
        /// </summary>
        [XmlElement("border_thickness")]
        [LanguageKey("border_thickness")]
        [DisplayName("border_thickness")]
        [DisplayIndex(15)]
        public double BorderThickness { get; set; } = 1;

        #endregion プロパティ

        #region メソッド

        public static IEnumerable<(PropertyInfo propertyInfo, int index, string name)> GetProperties() => GetProperties<ShellSchema>().OrderBy(x => x.index);

        #endregion メソッド
    }
}