using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions.Schemas
{
	public class CountrySchema
	{
		[JsonProperty("country_code")]
		public int CountryCode { get; set; }

		[JsonProperty("pref_code")]
		public List<int> PrefCodes { get; set; } = new List<int>();
	}
}
