using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mov.Suite.AnalizerClient.Resas.Repository.Schemas.Results.Compositions.PopulationPerYears
{
    public sealed class PopulationPerYearTypeDataResultSchema
    {
		#region property

		[JsonProperty("year")]
        [DisplayName("年")]
        public int Year { get; set; }

        [JsonProperty("value")]
        [DisplayName("人口")]
        public int Value { get; set; }

		[JsonProperty("rate")]
		[DisplayName("割合")]
		public double Rate { get; set; }

		#endregion property

		#region method

		public override string ToString()
		{
			return $"{Year} {Value}";
		}

		#endregion method
	}
}
