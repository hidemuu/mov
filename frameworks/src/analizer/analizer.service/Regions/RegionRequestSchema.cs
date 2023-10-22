using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions
{
	public class RegionRequestSchema
	{
		#region property

		[JsonProperty("pref_code")]
		public int PrefCode { get; }

		[JsonProperty("city_code")]
		public int CityCode { get; }

		[JsonProperty("category")]
		public string Category { get; } = string.Empty;

		[JsonProperty("label")]
		public string Label { get; } = string.Empty;

		#endregion property
	}
}
