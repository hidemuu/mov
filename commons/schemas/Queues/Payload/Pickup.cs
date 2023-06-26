using Mov.Controllers.Models.Queue;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Models.Payload
{
    public class Pickup : QueueObject
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
        /// 優先度
        /// </summary>
        [JsonProperty("priority")]
        public int Priority { get; set; }
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
