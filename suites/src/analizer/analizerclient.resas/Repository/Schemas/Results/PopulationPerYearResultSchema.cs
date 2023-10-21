using Mov.Suite.AnalizerClient.Resas.Repository.Schemas.Results.Compositions.PopulationPerYears;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mov.Suite.AnalizerClient.Resas.Repository.Schemas.Results
{
    public sealed class PopulationPerYearResultSchema : IResasResultSchema
    {
        #region constants

        public const string URI = @"population/composition/perYear";

		#endregion constants

		#region property

		[JsonProperty("boundaryYear")]
		[DisplayName("実績値と推計値の区切り年")]
		public string BoundaryYear { get; set; }

        [JsonProperty("data")]
        [DisplayName("データ")]
        public List<PopulationPerYearTypeResultSchema> Datas { get; set; } = new List<PopulationPerYearTypeResultSchema>();

		#endregion property

		#region method

		public override string ToString()
		{
			var response = BoundaryYear;
			foreach (var data in Datas)
			{
				response += $"{data}{Environment.NewLine}";
			}
			return response;
		}

		#endregion method
	}
}
