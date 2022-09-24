using Mov.Accessors;
using Mov.BaseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Driver.Models
{
    /// <summary>
    /// クエリのコレクション
    /// </summary>
    [XmlRoot("querys")]
    public class QueryCollection : DbObjectCollection<Query>
    {
        /// <inheritdoc />
        [JsonProperty("querys")]
        [XmlElement(Type = typeof(Query), ElementName = "query")]
        public override Query[] Items { get; set; }
    }
    /// <summary>
    /// クエリ
    /// </summary>
    [XmlRoot("query")]
    public class Query : DbObject
    {
    }
}
