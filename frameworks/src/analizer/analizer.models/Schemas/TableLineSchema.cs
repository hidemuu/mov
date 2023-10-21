using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Schemas
{
	public class TableLineSchema : AnalizeContentSchemaBase
	{

		[JsonProperty("name")]
		public string Name { get; set; } = string.Empty;

		[JsonProperty("content")]
		public string Content { get; set; } = string.Empty;
	}
}
