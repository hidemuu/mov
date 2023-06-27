using Mov.Repositories.Models.EntityObjects.DbObjects;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Mov.Driver.Models.Entities.Schemas
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