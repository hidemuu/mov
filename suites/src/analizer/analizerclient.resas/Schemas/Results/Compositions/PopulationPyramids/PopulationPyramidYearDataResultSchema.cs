using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mov.Suite.AnalizerClient.Resas.Schemas.Results.Compositions.PopulationPyramids
{
    public sealed class PopulationPyramidYearDataResultSchema
    {
		[JsonProperty("class")]
		[DisplayName("歳")]
		public string Class { get; set; }

		[JsonProperty("man")]
		[DisplayName("男性人口")]
		public int Man { get; set; }

		[JsonProperty("manPercent")]
		[DisplayName("男性比率")]
		public double ManPercent { get; set; }

		[JsonProperty("woman")]
		[DisplayName("女性人口")]
		public int Woman { get; set; }

		[JsonProperty("womanPercent")]
		[DisplayName("女性比率")]
		public double WomanPercent { get; set; }
	}
}
