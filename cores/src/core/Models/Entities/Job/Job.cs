using Newtonsoft.Json;
using System;

namespace Mov.Core.Models.Entities.Job
{
    /// <summary>
    /// ジョブ情報
    /// </summary>
    public class Job : QueueObject, ICloneable
    {

        #region プロパティ

        /// <summary>
        /// ジョブ割当用ID
        /// </summary>
        [JsonProperty("jobId")]
        public string JobId { get; set; }
        /// <summary>
        /// ジョブがキューされた時刻
        /// </summary>
        [JsonProperty("queuedTimestamp")]
        public long QueuedTimestamp { get; set; }
        /// <summary>
        /// ジョブタイプ
        /// </summary>
        [JsonProperty("jobType")]
        public string JobType { get; set; }
        /// <summary>
        /// 最後に割り当てられたAMR名称
        /// </summary>
        [JsonProperty("lastAssignedRobot")]
        public string LastAssignedRobot { get; set; }
        /// <summary>
        /// キャンセル理由（クライアントからキャンセル要求があった場合）
        /// </summary>
        [JsonProperty("cancelReason")]
        public string CancelReason { get; set; }
        /// <summary>
        /// キューイングマネージャからの成功失敗レスポンス
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// ジョブが完了した時刻
        /// </summary>
        [JsonProperty("completedTimestamp")]
        public long CompletedTimestamp { get; set; }
        /// <summary>
        /// 将来拡張用
        /// </summary>
        [JsonProperty("linkedJob")]
        public string LinkedJob { get; set; }
        /// <summary>
        /// ジョブ失敗回数
        /// </summary>
        [JsonProperty("failCount")]
        public int FailCount { get; set; }

        #endregion プロパティ

        #region メソッド

        /// <summary>
        /// クローン生成
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Job(); //同じものを複製する
        }

        #endregion メソッド

    }
}
