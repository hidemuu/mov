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

		[JsonProperty("data")]
        [DisplayName("データ")]
        public List<PopulationPerYearTypeDataResultSchema> Datas { get; set; } = new List<PopulationPerYearTypeDataResultSchema>();

		#endregion property

		#region method

		public override string ToString()
		{
			var response = string.Empty;
			foreach (var data in Datas)
			{
				response += $"{data}{Environment.NewLine}";
			}
			return response;
		}

		#endregion method
	}
}
