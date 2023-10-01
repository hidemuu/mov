using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Mov.Suite.AnalizerClient.Resas.Schemas.Results
{
    public class PrefectureResultSchema : IResasResultSchema
    {
        public const string URI = "prefectures";

        [Name("prefCode")]
        [JsonProperty("prefCode")]
        [DisplayName("都道府県コード")]
        public int Code { get; set; }

        [Name("prefName")]
        [JsonProperty("prefName")]
        [DisplayName("都道府県名")]
        public string Name { get; set; }
    }
}