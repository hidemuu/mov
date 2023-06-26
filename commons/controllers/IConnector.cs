using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Controllers
{
    public interface IConnector<TRepository>
    {
        #region プロパティ

        /// <summary>
        /// ホストIPアドレス
        /// </summary>
        string Host { get; set; }
        /// <summary>
        /// ポート番号
        /// </summary>
        string Port { get; set; }
        /// <summary>
        /// わすワード
        /// </summary>
        string Password { get; set; }
        /// <summary>
        /// プロトコル番号
        /// </summary>
        int Protocol { get; set; }

        /// <summary>
        /// コネクションハンドラ
        /// </summary>
        string Handler { get; set; }
        /// <summary>
        /// コネクション許可
        /// </summary>
        bool EnableConnect { get; set; }

        #endregion プロパティ

        #region メソッド

        /// <summary>
        /// コネクションパラメータを設定
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="password"></param>
        /// <param name="protocol"></param>
        void SetConnection(string host, string port, string password, int protocol);
        /// <summary>
        /// コネクション許可　有効・無効を設定
        /// </summary>
        /// <param name="isEnable"></param>
        void SetConnectionEnable(bool isEnable);
        /// <summary>
        /// 接続処理
        /// </summary>
        /// <param name="repos"></param>
        /// <returns></returns>
        Task<bool> MakeConnectionAsync(TRepository repos);
        /// <summary>
        /// 接続結果取得 true：接続成功
        /// </summary>
        /// <returns></returns>
        Task<bool> GetConnectedAsync();

        #endregion メソッド

    }
}
