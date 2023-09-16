using Mov.Core.Repositories.Schemas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models.Schemas
{
    /// <summary>
    /// レイアウトノードのコレクション
    /// </summary>
    [XmlRoot("nodes")]
    public class NodeCollectionSchema : DbCollectionSchemaBase<NodeSchema, Guid>
    {
        /// <inheritdoc />
        [XmlElement(Type = typeof(NodeSchema), ElementName = "node")]
        public override NodeSchema[] Items { get; set; }
    }
}
