namespace Mov.Core.Models.Entities.Counter
{
    /// <summary>
    /// 時刻カウンタ
    /// </summary>
    public class CycleCounter
    {
        /// <summary>
        /// サイクルタイム
        /// </summary>
        public double CycleTime { get; set; } = 0;
        /// <summary>
        /// 停止時間
        /// </summary>
        public double StopTime { get; set; } = 0;
        /// <summary>
        /// エラー時間
        /// </summary>
        public double ErrorTime { get; set; } = 0;
    }
}
