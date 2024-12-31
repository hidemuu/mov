using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Mov.Core.Errors.Schemas
{
    /// <summary>
    /// エラーのコレクション
    /// </summary>
    [XmlRoot("errors")]
    public class ErrorSchemaCollection : DbTableCollectionSchema<ErrorSchema, Guid>
    {
        /// <inheritdoc />
        [JsonProperty("errors")]
        [XmlElement(Type = typeof(ErrorSchema), ElementName = "error")]
        public override ErrorSchema[] Items { get; set; }
    }
}