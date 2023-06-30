namespace Mov.Core.Templates.Sequences
{
    /// <summary>
    /// シーケンスエラーコード
    /// </summary>
    public enum SequenceErrorCode
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 0,
        /// <summary>
        /// レスポンス無し
        /// </summary>
        No_Response = -1,
        /// <summary>
        /// 不使用
        /// </summary>
        NotUse = -2,
        /// <summary>
        /// データ型異常
        /// </summary>
        DataType_Fault = -9,
    }
}
