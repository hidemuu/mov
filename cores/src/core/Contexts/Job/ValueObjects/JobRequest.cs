using Mov.Core.Models;
using Newtonsoft.Json;

namespace Mov.Core.Contexts.Job.ValueObjects
{
    public class JobRequest : QueueObject
    {
        /// <summary>
        /// ジョブ割当用ID
        /// </summary>
        [JsonProperty("jobId")]
        public string JobId { get; set; }
        /// <summary>
        /// ゴール名称
        /// </summary>
        [JsonProperty("goal")]
        public string Goal { get; set; }
        /// <summary>
        /// 初期設定優先順位
        /// </summary>
        [JsonProperty("defaultPriority")]
        public bool DefaultPriority { get; set; }
        /// <summary>
        /// 優先度
        /// </summary>
        [JsonProperty("priority")]
        public int Priority { get; set; }
        /// <summary>
        /// セグメントタイプ
        /// </summary>
        [JsonProperty("segmentType")]
        public string SegmentType { get; set; }
        /// <summary>
        /// 割当られたジョブID
        /// </summary>
        [JsonProperty("assignedJobId")]
        public string AssignedJobId { get; set; }
        /// <summary>
        /// キューイングマネージャからの成功失敗レスポンス
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
