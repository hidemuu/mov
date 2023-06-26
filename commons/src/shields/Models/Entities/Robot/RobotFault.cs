using Mov.Utilities.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Shields.Models.Entities.Robot
{
    public class RobotFault : QueueObject
    {
        /// <summary>
        /// 最終更新時刻
        /// </summary>
        [JsonProperty("upd")]
        public UpdateDate Upd { get; set; }
        /// <summary>
        /// 異常ロボット名
        /// </summary>
        [JsonProperty("robot")]
        public string Robot { get; set; }
        /// <summary>
        /// 異常状態
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }
        /// <summary>
        /// 運転ブロック異常
        /// </summary>
        [JsonProperty("blockDriving")]
        public bool BlockDriving { get; set; }
        /// <summary>
        /// 運転異常
        /// </summary>
        [JsonProperty("driving")]
        public bool Driving { get; set; }
        /// <summary>
        /// 重大な異常
        /// </summary>
        [JsonProperty("critical")]
        public bool Critical { get; set; }
        /// <summary>
        /// Goでクリア可能
        /// </summary>
        [JsonProperty("clearedOnGo")]
        public bool ClearedOnGo { get; set; }
        /// <summary>
        /// 通知でクリア可能
        /// </summary>
        [JsonProperty("clearedOnAck")]
        public bool ClearedOnAck { get; set; }
        /// <summary>
        /// アプリケーションエラー
        /// </summary>
        [JsonProperty("application")]
        public bool Application { get; set; }
        /// <summary>
        /// 異常名
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 異常種類
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
        /// <summary>
        /// 短い説明
        /// </summary>
        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }
        /// <summary>
        /// 長い説明
        /// </summary>
        [JsonProperty("longDescription")]
        public string LongDescription { get; set; }
    }
}
