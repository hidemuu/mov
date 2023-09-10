namespace Mov.Core.Functions.Sequences
{
    public enum SequenceResponseCode
    {
        /// <summary>
        /// 分類無し
        /// </summary>
        NONE = 0,
        /// <summary>
        /// 実行中（次も同じシーケンス継続）
        /// </summary>
        BUSY = 1,
        /// <summary>
        /// 実行完了（シーケンス終了）
        /// </summary>
        COMPLETE = 2,
        /// <summary>
        /// 次工程移行（CompShiftCodeで設定したシーケンスに移行）
        /// </summary>
        NEXT = 3,
        /// <summary>
        /// 異常シーケンス移行（FaultShiftCodeで設定したシーケンスに移行）
        /// </summary>
        FAULT = -1,
    }
}
