using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Mov.Suite.AnalizerClient.Resas.Schemas.Results
{
    public sealed class PrefectureResultSchema : IResasResultSchema
    {
        #region constants

        public const string URI = "prefectures";

        #endregion constants

        #region property

        [Name("prefCode")]
        [JsonProperty("prefCode")]
        [DisplayName("都道府県コード")]
        public int Code { get; set; }

        [Name("prefName")]
        [JsonProperty("prefName")]
        [DisplayName("都道府県名")]
        public string Name { get; set; }

        #endregion property

        #region method

        public override string ToString()
        {
            return $"{Code} {Name}";
        }

        #endregion method
    }
}