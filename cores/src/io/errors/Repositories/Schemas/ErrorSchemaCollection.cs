using Mov.Core.Models.DbObjects.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Core.Errors.Repositories.Schemas
{
    /// <summary>
    /// エラーのコレクション
    /// </summary>
    [XmlRoot("errors")]
    public class ErrorSchemaCollection : DbObjectCollection<ErrorSchema>
    {
        /// <inheritdoc />
        [JsonProperty("errors")]
        [XmlElement(Type = typeof(ErrorSchema), ElementName = "error")]
        public override ErrorSchema[] Items { get; set; }
    }
}
