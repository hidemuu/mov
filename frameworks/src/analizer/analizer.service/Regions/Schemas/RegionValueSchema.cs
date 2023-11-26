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
		[JsonProperty("pref")]
		public int Prefecture { get; set; }

		/// <summary>
		/// city
		/// </summary>
		[JsonProperty("city")]
		public int City { get; set; }
	}
}
