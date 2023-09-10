using Mov.Core.Repositories;
using Newtonsoft.Json;

namespace Mov.Core.Translators.Models.Schemas
{
    public sealed class TranslateSchema : IDbObject<int>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("jp")]
        public string JP { get; set; }

        [JsonProperty("en")]
        public string EN { get; set; }
    }
}