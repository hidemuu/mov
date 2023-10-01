using Mov.Core.Learnings.Models;
using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Suite.GameClient.Tracking.KnightsTour
{
    /// <summary>
    /// 騎士の巡回問題
    /// </summary>
    public class KnightsTourGameClient : ITrackingGameClient
    {
        #region フィールド

        /// <summary>
        /// チェス盤サイズ
        /// </summary>
        private int n;

        /// <summary>
        /// n×nチェス盤 ２次元配列
        /// </summary>
        private int[,] bd;

        /// <summary>
        /// ナイトの移動パターン生成
        /// </summary>
        private ConsCell[] pat;

        #endregion フィールド

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="n"></param>
        public KnightsTourGameClient(int n)
        {
            this.n = n;
            bd = ConsCell.MakeIntArray2(n, n, 0);
            pat = new ConsCell[]
            {
                ConsCell.Of(1, 2), ConsCell.Of(1, -2), ConsCell.Of(-1, 2), ConsCell.Of(-1, 2),
                ConsCell.Of(2, 1), ConsCell.Of(2, -1), ConsCell.Of(-2, 1), ConsCell.Of(-2, -1)
            };
        }

        #region メソッド

        /// <summary>
        /// r,cから開始してルートとチェス盤表示
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        public void Start(int r, int c)
        {
            Console.WriteLine(Knight(r, c, 1, ConsCell.Nil));
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    Console.Write("{0,2:d} ", bd[i, j]);
                }
                Console.Write("\n");
            }
        }

        #endregion メソッド

        #region 内部メソッド

        /// <summary>
        /// r, cへの移動を試す
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <param name="cnt"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        private ConsCell Knight(int r, int c, int cnt, ConsCell route)
        {
            if (r >= 0 && r < n && c >= 0 && c < n && bd[r, c] == 0)
            {
                bd[r, c] = cnt;
                if (cnt == n * n) return new ConsCell(ConsCell.Of(r, c), route);    //最終位置到達
                foreach (var p in pat)
                {
                    ConsCell rt = Knight(r + p.GetToInt(0), c + p.GetToInt(1), cnt + 1, new ConsCell(ConsCell.Of(r, c), route));    //次の移動を試す
                    if (rt != ConsCell.Nil) return rt;  //ルート探索成功、結果を返す
                }
                bd[r, c] = 0;   //失敗したのでマスを空に戻す
            }
            return ConsCell.Nil;
        }

        #endregion 内部メソッド
    }
}
