﻿using Newtonsoft.Json;

namespace Mov.Core.Robots.Models.Queues.Stores
{
    public class StoreValue : QueueObject
    {
        /// <summary>
        /// 更新日時
        /// </summary>
        [JsonProperty("upd")]
        public UpdateDate Upd { get; set; }
        /// <summary>
        /// 設定値
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
