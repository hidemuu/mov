using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;

namespace Mov.Analizer.Models.Schemas
{
    public class TimeTrendSchema : AnalizeContentSchemaBase
	{
		[JsonProperty("timestamp")]
        public string TimeStamp { get; set; } = string.Empty;

		
    }
}