using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Driver.Models
{
    /// <summary>
    /// スキーマのコレクション
    /// </summary>
    [XmlRoot("schemas")]
    public class SchemaCollection : DbObjectCollection<Schema>
    {
        /// <summary>
        /// コレクション
        /// </summary>
        [JsonProperty("schemas")]
        [XmlElement(Type = typeof(Schema), ElementName = "schema")]
        public override Schema[] Items { get; set; }
    }

    [XmlRoot("schema")]
    public class Schema : DbObject
    {
    }
}
