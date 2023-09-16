using Mov.Core.Repositories;
using Newtonsoft.Json;

namespace Mov.Core.Translators.Models.Schemas
{
    public sealed class TranslateSchemaCollection : IDbCollectionSchema<TranslateSchema, int>
    {
        [JsonProperty("translates")]
        public TranslateSchema[] Items { get; set; }
    }
}