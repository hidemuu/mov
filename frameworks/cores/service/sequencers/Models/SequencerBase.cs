using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Core.Sequencers.Models
{
    /// <summary>
    /// シーケンス制御基底クラス
    /// </summary>
    public abstract class SequencerBase<TRepository>
    {
        #region プロパティ
        /// <summary>
        /// ステータス
        /// </summary>
        public abstract SequenserStatus Status { get; set; }

        /// <summary>
        /// シーケンスアイテム
        /// </summary>
        public abstract IEnumerable<SequenceItem<TRepository>> Sequences { get; set; }

        #endregion プロパティ

        #region 静的メソッド

        /// <summary>
        /// 継承クラスのインスタンスを生成し、
        /// 指定したシーケンスコードのメソッドを実行する
        /// </summary>
        /// <typeparam name="T">継承クラス</typeparam>
        /// <param name="sequenceItems"></param>
        /// <param name="sequenceCode"></param>
        /// <param name="repos"></param>
        /// <returns></returns>
        public static async Task<T> RunAsync<T>(IEnumerable<SequenceItem<TRepository>> sequenceItems,
            int sequenceCode, TRepository repos)
            where T : SequencerBase<TRepository>, new()
        {
            //継承クラスのインスタンス生成
            var self = new T();
            self.Status.SequenceCode = sequenceCode;

            //対応シーケンス番号のメソッド実行
            var responseCode = await Task.Run(() =>
            sequenceItems.FirstOrDefault(x => x.Code == sequenceCode).Command(repos));
            var errorCode = SequenceErrorCode.Normal;
            var nextSequenceCode = sequenceCode;

            //レスポンスコードにより次工程判定
            if (responseCode == SequenceResponseCode.COMPLETE)
            {
                nextSequenceCode = await Task.Run(() =>
                sequenceItems.FirstOrDefault(x => x.Code == sequenceCode).CompShiftCode);
                responseCode = SequenceResponseCode.NEXT;
            }
            else if (responseCode == SequenceResponseCode.FAULT)
            {
                //エラー時はエラーコード判定
                errorCode = await Task.Run(() =>
                sequenceItems.FirstOrDefault(x => x.Code == sequenceCode).Error());
                nextSequenceCode = await Task.Run(() =>
                sequenceItems.FirstOrDefault(x => x.Code == sequenceCode).FaultShiftCode);
            }

            //アンサバック
            self.Status.SequenceCode = nextSequenceCode;
            self.Status.ResponseCode = responseCode;
            self.Status.ErrorCode = errorCode;

            return self;
        }

        /// <summary>
        /// 現在レスポンスコード文字列を取得
        /// </summary>
        /// <param name="responseCode"></param>
        /// <returns></returns>
        public static string DispCurrentResponse(SequenceResponseCode responseCode)
        {
            switch (responseCode)
            {
                case SequenceResponseCode.BUSY: return "BUSY";
                case SequenceResponseCode.COMPLETE: return "COMP";
                case SequenceResponseCode.FAULT: return "FAULT";
                case SequenceResponseCode.NEXT: return "NEXT";
                case SequenceResponseCode.NONE: return "NONE";
                default: return "";
            }
        }
        /// <summary>
        /// 指定シーケンスコード文字列を取得
        /// </summary>
        /// <param name="sequenceItems"></param>
        /// <param name="sequenceCode"></param>
        /// <returns></returns>
        public static string DispCurrentSequence(IEnumerable<SequenceItem<TRepository>> sequenceItems, int sequenceCode)
        {
            return sequenceItems.ToList().Find(x => x.Code == sequenceCode).Name;
        }

        #endregion 静的メソッド

        #region メソッド

        /// <summary>
        /// 現在工程完了後の次工程シーケンスコードを変更する
        /// </summary>
        /// <param name="shiftCode"></param>
        /// <returns></returns>
        public bool ChangeCompShiftCode(int shiftCode)
        {
            var s = Sequences.FirstOrDefault(x => x.Code == Status.SequenceCode);
            if (s != null)
            {
                s.CompShiftCode = shiftCode;
                return true;
            }
            return false;
        }
        /// <summary>
        /// 現在工程異常終了時の移行シーケンスコードを変更する
        /// </summary>
        /// <param name="shiftCode"></param>
        /// <returns></returns>
        public bool ChangeFaultShiftCode(int shiftCode)
        {
            var s = Sequences.FirstOrDefault(x => x.Code == Status.SequenceCode);
            if (s != null)
            {
                s.FaultShiftCode = shiftCode;
                return true;
            }
            return false;
        }

        #endregion メソッド

    }
}
