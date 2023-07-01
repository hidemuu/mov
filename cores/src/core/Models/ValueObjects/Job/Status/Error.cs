using System;

namespace Mov.Core.Models.ValueObjects.Job.Status
{
    /// <summary>
    /// エラー１点分の情報
    /// </summary>
    public class Error : ICloneable
    {
        #region 定数

        /// <summary>
        /// エラーレベル判定文字コード：レベル１
        /// </summary>
        public const string C_AMR_APP_ERROR_LV1 = "Driving";
        /// <summary>
        /// エラーレベル判定文字コード：レベル２
        /// </summary>
        public const string C_AMR_APP_ERROR_LV2 = "Critical";
        /// <summary>
        /// エラーレベル判定文字コード：レベル３
        /// </summary>
        public const string C_AMR_APP_ERROR_LV3 = "";

        /// <summary>
        /// エラーカテゴリ判定文字コード：アプリケーションエラー
        /// </summary>
        public const string C_AMR_CATEGORY_APP = "App";
        /// <summary>
        /// エラーカテゴリ判定文字コード：ロボット機器エラー
        /// </summary>
        public const string C_AMR_CATEGORY_ROBOT = "Robot";
        /// <summary>
        /// エラーカテゴリ判定文字コード：ロボットキュー（動作）エラー
        /// </summary>
        public const string C_AMR_CATEGORY_QUEUE = "Queue";
        /// <summary>
        /// エラーカテゴリ判定文字コード：ペイロードエラー
        /// </summary>
        public const string C_AMR_CATEGORY_PAYLOAD = "Payload";

        #endregion 定数

        #region プロパティ

        /// <summary>
        /// エラー番号
        /// </summary>
        public int Number { get; set; } = 0;
        /// <summary>
        /// エラーカテゴリ | 
        /// カテゴリ名は、ユニット毎に規定し、
        /// 同クラス内定数　C_(ユニット）_CATEGORY_***　から設定する
        /// </summary>
        public string Category { get; set; } = "";
        /// <summary>
        /// エラーLv | 1:重故障 / 2:軽故障 / 3:警告
        /// </summary>
        public int Lv { get; set; } = 0;
        /// <summary>
        /// エラーコード
        /// </summary>
        public string Code { get; set; } = "";
        /// <summary>
        /// エラー名称
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// エラー情報
        /// </summary>
        public string Info { get; set; } = "";
        /// <summary>
        /// 解除可否
        /// </summary>
        public bool Clearable { get; set; } = true;

        /// <summary>
        /// 内容説明
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// 登録日時
        /// </summary>
        public DateTime ResisterDate { get; set; } = DateTime.Now;

        #endregion プロパティ

        #region メソッド

        /// <summary>
        /// クローン生成
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Error(); //同じものを複製する
        }

        #endregion メソッド

    }
}
