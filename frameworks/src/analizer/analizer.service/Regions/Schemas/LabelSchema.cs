using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions.Schemas
{
	public class LabelSchema
	{
		[JsonProperty("category")]
		public string Category { get; set; } = string.Empty;

		[JsonProperty("label")]
		public string Label { get; set; } = string.Empty;
	}
}
