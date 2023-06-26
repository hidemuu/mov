using Mov.Utilities.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Shields.Models.Entities.Job
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
