using Mov.Controllers.Models.Queue;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Store
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
