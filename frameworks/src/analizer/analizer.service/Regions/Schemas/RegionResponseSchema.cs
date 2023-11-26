using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions.Schemas
{
	public class RegionResponseSchema<T>
	{
		/// <summary>
		/// カテゴリ
		/// </summary>
		[JsonProperty("category")]
		public string Category { get; set; } = string.Empty;

		/// <summary>
		/// ラベル
		/// </summary>
		[JsonProperty("label")]
		public string Label { get; set; } = string.Empty;

		/// <summary>
		/// データ
		/// </summary>
		[JsonProperty("data")]
		public List<T> Data { get; set; } = new List<T>();
	}
}
