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
		public int PrefCode { get; set; }

		[JsonProperty("city_code")]
		public int CityCode { get; set; }

		[JsonProperty("category")]
		public string Category { get; set;  } = string.Empty;

		[JsonProperty("label")]
		public string Label { get; set; } = string.Empty;

		#endregion property
	}
}
