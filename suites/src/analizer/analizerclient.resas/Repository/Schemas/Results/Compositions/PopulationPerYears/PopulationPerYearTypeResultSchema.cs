using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mov.Suite.AnalizerClient.Resas.Repository.Schemas.Results.Compositions.PopulationPerYears
{
    public sealed class PopulationPerYearTypeResultSchema
    {
		#region property

		/// <summary>ラベル</summary>
		/// <remarks>総人口 / 年少人口 / 生産年齢人口 / 老年人口</remarks>
		[JsonProperty("label")]
		[DisplayName("ラベル")]
		public string Label { get; set; }

		[JsonProperty("data")]
        [DisplayName("データ")]
        public List<PopulationPerYearTypeDataResultSchema> Datas { get; set; } = new List<PopulationPerYearTypeDataResultSchema>();

		#endregion property

		#region method

		public bool IsAll() => Label.Equals("総人口", StringComparison.Ordinal);

		public bool IsYoung() => Label.Equals("年少人口", StringComparison.Ordinal);

		public bool IsSenior() => Label.Equals("生産年齢人口", StringComparison.Ordinal);

		public bool IsOld() => Label.Equals("老年人口", StringComparison.Ordinal);


		public override string ToString()
		{
			var response = $"{Label}{Environment.NewLine}";
			foreach (var data in Datas)
			{
				response += $"{data}{Environment.NewLine}";
			}
			return response;
		}

		#endregion method
	}
}
