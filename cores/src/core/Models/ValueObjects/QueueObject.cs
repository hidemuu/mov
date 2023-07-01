using Newtonsoft.Json;

namespace Mov.Core.Models.ValueObjects
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
