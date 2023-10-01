using CsvHelper.Configuration.Attributes;
using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace Mov.Suite.AnalizerClient.Resas.Schemas
{
    public class ResasResponse<TResult> : DbSchemaBase<string> where TResult : IResasResult
    {
        [Name("message")]
        [JsonProperty("message")]
        [DisplayName("メッセージ")]
        public override string Id { get; set; }

        [Name("result")]
        [JsonProperty("result")]
        [DisplayName("結果")]
        public List<TResult> Results { get; set; } = new List<TResult>();
    }
}