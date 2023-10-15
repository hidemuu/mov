using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Schemas
{
	public class TimeLineSchema : AnalizeContentSchemaBase
	{
		[JsonProperty("start_time")]
		public string StartTime { get; set; } = string.Empty;

		[JsonProperty("end_time")]
		public string EndTime { get; set; } = string.Empty;
	}
}
