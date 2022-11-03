using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Job
{
    /// <summary>
    /// ジョブ情報
    /// </summary>
    public class Job : ICloneable
    {
        #region 定数

        /// <summary>
        /// ジョブ判定キーコード
        /// </summary>
        public const string C_JOB_KEYCODE = "Job";
        /// <summary>
        /// ジョブステータス：分類無し
        /// </summary>
        public const string C_STATUS_NOTHING = "Nothing";
        /// <summary>
        /// ジョブステータス：起動待機
        /// </summary>
        public const string C_STATUS_STANDBY = "Standby";
        /// <summary>
        /// ジョブステータス：運転準備完了
        /// </summary>
        public const string C_STATUS_READY = "Ready";
        /// <summary>
        /// ジョブステータス：運行中
        /// </summary>
        public const string C_STATUS_RUN = "Running";
        /// <summary>
        /// ジョブステータス：ジョブ完了
        /// </summary>
        public const string C_STATUS_FINISH = "Finished";
        /// <summary>
        /// ジョブステータス：ジョブキャンセル
        /// </summary>
        public const string C_STATUS_CANCEL = "Canceled";
        /// <summary>
        /// ジョブステータス：ジョブジャンプ
        /// </summary>
        public const string C_STATUS_JUMP = "Jumped";
        /// <summary>
        /// ジョブステータス：休憩
        /// </summary>
        public const string C_STATUS_REST = "Rest";
        /// <summary>
        /// ジョブステータス：停止
        /// </summary>
        public const string C_STATUS_STOP = "Stop";
        /// <summary>
        /// ジョブステータス：不使用
        /// </summary>
        public const string C_STATUS_NOUSE = "NoUse";

        #endregion 定数

        #region プロパティ

        /// <summary>
        /// ジョブ番号
        /// </summary>
        public int Number { get; set; } = -1;
        /// <summary>
        /// タスク番号
        /// </summary>
        public int TaskNumber { get; set; } = -1;
        /// <summary>
        /// ジョブ名称
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// ジョブステータス
        /// </summary>
        public string Status { get; set; } = "Nothing";
        /// <summary>
        /// タスクコード
        /// </summary>
        public string TaskCode { get; set; } = "Dropoff";
        /// <summary>
        /// タスク見込み実行時間（sec）
        /// </summary>
        public int TaskSec { get; set; } = 0;

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
