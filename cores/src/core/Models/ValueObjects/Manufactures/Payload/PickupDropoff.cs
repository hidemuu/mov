using Newtonsoft.Json;

namespace Mov.Core.Models.ValueObjects.Manufactures.Payload
{
    public class PickupDropoff : QueueObject
    {
        /// <summary>
        /// ジョブ割当用ID
        /// </summary>
        [JsonProperty("jobId")]
        public string JobId { get; set; }
        /// <summary>
        /// ピックアップゴール名称
        /// </summary>
        [JsonProperty("pickupGoal")]
        public string PickupGoal { get; set; }
        /// <summary>
        /// ピックアップ優先度
        /// </summary>
        [JsonProperty("pickupPriority")]
        public int PickupPriority { get; set; }
        /// <summary>
        /// ドロップオフゴール名称
        /// </summary>
        [JsonProperty("dropoffGoal")]
        public string DropoffGoal { get; set; }
        /// <summary>
        /// ドロップオフ優先度
        /// </summary>
        [JsonProperty("dropoffPriority")]
        public int DropoffPriority { get; set; }
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
