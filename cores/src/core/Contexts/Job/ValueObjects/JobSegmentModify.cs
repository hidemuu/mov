using Mov.Core.Models;
using Newtonsoft.Json;

namespace Mov.Core.Contexts.Job.ValueObjects
{
    public class JobSegmentModify : QueueObject
    {
        /// <summary>
        /// セグメントネームキー
        /// </summary>
        [JsonProperty("segmentNamekey")]
        public string SegmentNamekey { get; set; }
        /// <summary>
        /// セグメントID
        /// </summary>
        [JsonProperty("segmentId")]
        public string SegmentId { get; set; }
        /// <summary>
        /// ゴール名
        /// </summary>
        [JsonProperty("goal")]
        public string Goal { get; set; }
        /// <summary>
        /// 優先順位
        /// </summary>
        [JsonProperty("priority")]
        public int Priority { get; set; }
        /// <summary>
        /// ステータス
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
