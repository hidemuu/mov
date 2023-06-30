using Mov.Core.Models.Entities;
using Newtonsoft.Json;

namespace Mov.Core.Shields.Models.Entities.Robot
{
    public class Robot : QueueObject
    {
        /// <summary>
        /// Available等
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// Unlocated等
        /// </summary>
        [JsonProperty("subStatus")]
        public string SubStatus { get; set; }
    }
}
