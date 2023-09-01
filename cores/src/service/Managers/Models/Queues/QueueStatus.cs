namespace Mov.Core.Robots.Models.Queues
{
    /// <summary>
    /// オーダーステータスキーコード
    /// </summary>
    public enum QueueStatus
    {
        /// <summary>
        /// 分類なし
        /// </summary>
        Nothing = 0,
        /// <summary>
        /// 要求中
        /// </summary>
        Required = 1,
        /// <summary>
        /// 実行完了
        /// </summary>
        Finished = 2,
        /// <summary>
        /// 実行キャンセル
        /// </summary>
        Cancelled = 3,
    }
}
