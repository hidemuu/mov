using Mov.Utilities.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Shields.Models.Entities.Payload
{
    public class Dropoff : QueueObject
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
        /// ジョブを実行するAMR名称
        /// </summary>
        [JsonProperty("robot")]
        public string Robot { get; set; }
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
