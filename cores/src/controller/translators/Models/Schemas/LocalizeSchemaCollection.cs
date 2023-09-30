using Mov.Core.Repositories;
using Newtonsoft.Json;

namespace Mov.Core.Translators.Models.Schemas
{
    public sealed class LocalizeSchemaCollection : IDbCollectionSchema<LocalizeSchema, int>
    {
        [JsonProperty("translates")]
        public LocalizeSchema[] Items { get; set; }
    }
}