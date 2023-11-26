using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions.Schemas
{
	public class RegionResponseSchema<T>
	{
		/// <summary>
		/// prefecture
		/// </summary>
		[JsonProperty("prefecture")]
		public string Prefecture { get; set; } = string.Empty;

		/// <summary>
		/// city
		/// </summary>
		[JsonProperty("city")]
		public string City { get; set; } = string.Empty;

		/// <summary>
		/// データ
		/// </summary>
		[JsonProperty("data")]
		public List<T> Data { get; set; } = new List<T>();
	}
}
