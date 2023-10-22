using Mov.Core.Attributes;
using Mov.Core.Models;
using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Mov.Analizer.Models.Schemas
{
    public class TimeTrendSchema : AnalizeContentSchemaBase<string>
	{
		[JsonProperty("timestamp")]
        public string TimeStamp { get; set; } = string.Empty;

		[JsonProperty("value")]
		public decimal Value { get; set; }
    }
}