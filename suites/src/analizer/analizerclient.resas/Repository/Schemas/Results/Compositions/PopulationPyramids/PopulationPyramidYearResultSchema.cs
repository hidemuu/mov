using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mov.Suite.AnalizerClient.Resas.Repository.Schemas.Results.Compositions.PopulationPyramids
{
    public sealed class PopulationPyramidYearResultSchema
    {
		#region property

		[JsonProperty("year")]
        [DisplayName("年")]
        public int Year { get; set; }

        [JsonProperty("oldAgeCount")]
        [DisplayName("65歳以上の老年人口(人)")]
        public int OldAgeCount { get; set; }

        [JsonProperty("oldAgePercent")]
        [DisplayName("65歳以上の老年人口(パーセント)")]
        public double OldAgePercent { get; set; }

        [JsonProperty("middleAgeCount")]
        [DisplayName("15歳～64歳の生産年齢人口(人)")]
        public int MiddleAgeCount { get; set; }

        [JsonProperty("middleAgePercent")]
        [DisplayName("15歳～64歳の生産年齢人口(パーセント)")]
        public double MiddleAgePercent { get; set; }

        [JsonProperty("newAgeCount")]
        [DisplayName("0歳～14歳の年少人口(人)")]
        public int NewAgeCount { get; set; }

        [JsonProperty("newAgePercent")]
        [DisplayName("0歳～14歳の年少人口(パーセント)")]
        public double NewAgePercent { get; set; }

		[JsonProperty("data")]
        [DisplayName("データ")]
        public List<PopulationPyramidYearDataResultSchema> Datas { get; set; } = new List<PopulationPyramidYearDataResultSchema>();

		#endregion property

		#region method

		public override string ToString()
		{
			var response = $"{Year} {OldAgeCount} {OldAgePercent} {MiddleAgeCount} {MiddleAgePercent} {NewAgeCount} {NewAgePercent}";
			foreach (var data in Datas)
			{
				response += $"{data}{Environment.NewLine}";
			}
			return response;
		}

		#endregion method
	}
}
