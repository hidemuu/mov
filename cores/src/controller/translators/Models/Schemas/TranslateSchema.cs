using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;

namespace Mov.Core.Translators.Models.Schemas
{
    public sealed class TranslateSchema : DbSchemaBase<int>
    {
        [JsonProperty("jp")]
        public string JP { get; set; }

        [JsonProperty("en")]
        public string EN { get; set; }
    }
}