using Newtonsoft.Json;

namespace Mov.Core.Models.ValueObjects.Job.Status
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
