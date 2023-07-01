using Newtonsoft.Json;

namespace Mov.Core.Models.ValueObjects.Job
{
    public class JobSegment : QueueObject
    {
        /// <summary>
        /// セグメントID
        /// </summary>
        [JsonProperty("segmentId")]
        public string SegmentId { get; set; }
        /// <summary>
        /// セグメントタイプ
        /// </summary>
        [JsonProperty("segmentType")]
        public string SegmentType { get; set; }

        /// <summary>
        /// Pending Inprogress等
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// Unlocated等
        /// </summary>
        [JsonProperty("subStatus")]
        public string SubStatus { get; set; }
        /// <summary>
        /// ジョブID
        /// </summary>
        [JsonProperty("job")]
        public string Job { get; set; }
        /// <summary>
        /// ロボット名称
        /// </summary>
        [JsonProperty("robot")]
        public string Robot { get; set; }
        /// <summary>
        /// 前のジョブセグメントID
        /// </summary>
        [JsonProperty("linkedJobSegment")]
        public string LinkedJobSegment { get; set; }
        /// <summary>
        /// 優先度
        /// </summary>
        [JsonProperty("priority")]
        public int Priority { get; set; }
        /// <summary>
        /// ゴール名
        /// </summary>
        [JsonProperty("goalName")]
        public string GoalName { get; set; }
        /// <summary>
        /// キャンセル理由
        /// </summary>
        [JsonProperty("cancelReason")]
        public string CancelReason { get; set; }
    }
}
