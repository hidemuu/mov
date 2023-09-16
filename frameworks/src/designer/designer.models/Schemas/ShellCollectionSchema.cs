using Mov.Core.Repositories.Schemas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models.Schemas
{
    /// <summary>
    /// シェル（フレーム）のコレクション
    /// </summary>
    [XmlRoot("shells")]
    public class ShellCollectionSchema : DbCollectionSchemaBase<ShellSchema, Guid>
    {
        /// <inheritdoc />
        [XmlElement(Type = typeof(ShellSchema), ElementName = "shell")]
        public override ShellSchema[] Items { get; set; }
    }
}
