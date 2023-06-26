using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Mov.Driver.Clients.Resas.Entities.Results
{
    public class Prefecture : IResasResult
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