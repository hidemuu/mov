using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Mov.Suite.AnalizerClient.Resas.Schemas.Results
{
    public class CityResultSchema : IResasResultSchema
    {
        #region constants

        public const string URI = "cities";

        #endregion constants

        #region property

        [Name("cityCode")]
        [JsonProperty("cityCode")]
        [DisplayName("市区町村コード")]
        public int Code { get; set; }

        [Name("cityName")]
        [JsonProperty("cityName")]
        [DisplayName("都道府県名")]
        public string Name { get; set; }

        [Name("bigCityFlag")]
        [JsonProperty("bigCityFlag")]
        [DisplayName("特別区・行政区フラグ（0:一般の市区町村、1:政令指定都市の区、2:政令指定都市の市、3:東京都23区）")]
        public int Flag { get; set; }

        #endregion property

        #region method

        public override string ToString()
        {
            return $"{Code} {Name}";
        }

        #endregion method
    }
}
