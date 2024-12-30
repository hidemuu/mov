using Mov.Core.Repositories.Schemas;
using System;
using System.Xml.Serialization;

namespace Mov.Designer.Models.Schemas
{
    /// <summary>
    /// コンテンツのコレクション
    /// </summary>
    [XmlRoot("contents")]
    public class ContentCollectionSchema : DbCollectionSchemaBase<ContentSchema, Guid>
    {
        /// <inheritdoc />
        [XmlElement(Type = typeof(ContentSchema), ElementName = "content")]
        public override ContentSchema[] Items { get; set; }
    }
}