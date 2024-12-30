using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions.Schemas
{
	public class RegionValueSchema
	{
		/// <summary>
		/// prefecture
		/// </summary>
		[JsonProperty("pref_code")]
		public int PrefCode { get; set; }

		[JsonProperty("pref_name")]
		public string PrefName { get; set; }

		/// <summary>
		/// city
		/// </summary>
		[JsonProperty("city_code")]
		public int CityCode { get; set; }

		[JsonProperty("city_name")]
		public string CityName { get; set; }
	}
}
