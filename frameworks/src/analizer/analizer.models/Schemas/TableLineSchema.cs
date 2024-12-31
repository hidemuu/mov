using Mov.Core.Attributes;
using Mov.Core.Models;
using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Analizer.Models.Schemas
{
	public class TableLineSchema : AnalizeContentSchemaBase<int>
	{

		[JsonProperty("name")]
		public string Name { get; set; } = string.Empty;

		[JsonProperty("content")]
		public string Content { get; set; } = string.Empty;
	}
}
