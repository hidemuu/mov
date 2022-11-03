using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Models.Queue
{
    /// <summary>
    /// 更新記録
    /// </summary>
    public class UpdateDate
    {
        /// <summary>
        /// 更新日時（ミリ秒）
        /// </summary>
        [JsonProperty("millis")]
        public long Millis { get; set; }
    }
}
