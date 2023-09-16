using Mov.Core.Repositories.Schemas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models.Schemas
{
    /// <summary>
    /// テーマのコレクション
    /// </summary>
    [XmlRoot("themes")]
    public class ThemeCollectionSchema : DbCollectionSchemaBase<ThemeSchema, Guid>
    {
        /// <inheritdoc />
        [XmlElement(Type = typeof(ThemeSchema), ElementName = "theme")]
        public override ThemeSchema[] Items { get; set; }
    }
}
