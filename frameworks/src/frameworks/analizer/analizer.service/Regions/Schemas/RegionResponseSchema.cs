using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions.Schemas
{
	public class RegionResponseSchema<T>
	{
		/// <summary>
		/// region
		/// </summary>
		[JsonProperty("region")]
		public RegionValueSchema Region { get; set; } = new RegionValueSchema();

		/// <summary>
		/// データ
		/// </summary>
		[JsonProperty("data")]
		public List<T> Data { get; set; } = new List<T>();
	}
}
