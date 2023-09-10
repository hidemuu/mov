using System;
using System.Threading.Tasks;

namespace Mov.Core.Functions.Sequences
{
    /// <summary>
    /// シーケンス制御コード
    /// </summary>
    public class SequenceItem<TRepository>
    {
        /// <summary>
        /// シーケンス番号
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// シーケンス名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// シーケンスで実行するメソッド
        /// </summary>
        public Func<TRepository, Task<SequenceResponseCode>> Command { get; set; }
        /// <summary>
        /// シーケンス結果のResponseが「Fault」の時のエラー処理メソッド
        /// </summary>
        public Func<Task<SequenceErrorCode>> Error { get; set; }
        /// <summary>
        /// シーケンスレスポンス完了時の次工程シーケンス番号
        /// </summary>
        public int CompShiftCode { get; set; }
        /// <summary>
        /// シーケンスレスポンス異常時の次工程シーケンス番号
        /// </summary>
        public int FaultShiftCode { get; set; }
    }
}
