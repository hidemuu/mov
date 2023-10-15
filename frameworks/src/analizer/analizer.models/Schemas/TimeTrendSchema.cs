using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;

namespace Mov.Analizer.Models.Schemas
{
    public class TimeTrendSchema : DbSchemaBase<Guid>
    {
		[JsonProperty("name")]
		public string Name { get; set; } = string.Empty;

		[JsonProperty("timestamp")]
        public string TimeStamp { get; set; } = string.Empty;

		
    }
}