using Mov.Core.Repositories.Entities;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Mov.Core.Errors.Schemas
{
    /// <summary>
    /// エラーのコレクション
    /// </summary>
    [XmlRoot("errors")]
    public class ErrorSchemaCollection : DbTableCollection<ErrorSchema, Guid>
    {
        /// <inheritdoc />
        [JsonProperty("errors")]
        [XmlElement(Type = typeof(ErrorSchema), ElementName = "error")]
        public override ErrorSchema[] Items { get; set; }
    }
}