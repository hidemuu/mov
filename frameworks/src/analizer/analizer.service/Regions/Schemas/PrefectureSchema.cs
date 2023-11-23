using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions.Schemas
{
	public class PrefectureSchema
	{
		[JsonProperty("pref_code")]
		public int PrefCode { get; set; }

		[JsonProperty("city_code")]
		public List<int> CityCodes { get; set; } = new List<int>();
	}
}
