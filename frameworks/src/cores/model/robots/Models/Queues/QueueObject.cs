using Newtonsoft.Json;

namespace Mov.Core.Robots.Models.Queues
{
    public class QueueObject
    {
        /// <summary>
        /// ネームキー
        /// </summary>
        [JsonProperty("namekey")]
        public string Namekey { get; set; }
    }
}
