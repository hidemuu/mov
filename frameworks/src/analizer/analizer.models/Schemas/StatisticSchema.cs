using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;

namespace Mov.Analizer.Models.Schemas
{
    public class StatisticSchema : DbSchemaBase<Guid>
    {
        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; } = string.Empty;

		[JsonProperty("name")]
		public string Name { get; set; } = string.Empty;
    }
}