using Newtonsoft.Json;

namespace Mov.Core.Models
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
