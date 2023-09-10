namespace Mov.Core.Functions.Sequences
{
    public class SequenserStatus
    {
        #region プロパティ
        /// <summary>
        /// シーケンサ番号
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// シーケンサ名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// シーケンス番号
        /// </summary>
        public int SequenceCode { get; set; }
        /// <summary>
        /// レスポンスコード
        /// </summary>
        public SequenceResponseCode ResponseCode { get; set; }
        /// <summary>
        /// エラーレコード
        /// </summary>
        public SequenceErrorCode ErrorCode { get; set; }
        /// <summary>
        /// エラー情報
        /// </summary>
        public string ErrorInfo { get; set; }

        #endregion プロパティ
    }
}
