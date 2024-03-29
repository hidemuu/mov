﻿using Newtonsoft.Json;

namespace Mov.Core.Robots.Models.Queues.Jobs
{
    public class JobCancel : QueueObject
    {
        /// <summary>
        /// キャンセルタイプ
        /// </summary>
        [JsonProperty("cancelType")]
        public string CancelType { get; set; }
        /// <summary>
        /// キャンセル値
        /// </summary>
        [JsonProperty("cancelValue")]
        public string CancelValue { get; set; }
        /// <summary>
        /// キャンセル理由
        /// </summary>
        [JsonProperty("cancelReason")]
        public string CancelReason { get; set; }
        /// <summary>
        /// ステータス
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
