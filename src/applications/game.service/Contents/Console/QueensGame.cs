using Mov.Calculators;
using Mov.Game.Models;
using Mov.Schemas.Elements.Members.Learnings;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Service.Tracking
{
    /// <summary>
    /// Nクイーン問題クラス
    /// </summary>
    public class QueensGame : ITrackingGame, IConsoleGame
    {
        #region フィールド 

        /// <summary>
        /// クイーン数
        /// </summary>
        private int n;

        /// <summary>
        /// 再帰レベル
        /// </summary>
        private int level = 0;

        #endregion フィールド

        /// <summary>
        /// コンストラクター
        /// </summary>
        public QueensGame()
        {

        }

        #region メソッド

        /// <summary>
        /// 問題を解いて各配置リストを表示
        /// </summary>
        /// <param name="n"></param>
        public void Start(int n)
        {
            this.n = n;
            Queen(n).Foreach((ConsCell pat) =>
            {
                Console.WriteLine();
                pat.Foreach((ConsCell p) => 
                    Console.WriteLine(ConsCell.Repeat("＋", p.GetToInt(1) - 1) + "Ｑ" + 
                    ConsCell.Repeat("＋", n - p.GetToInt(1)))
                );
            });
        }

        public void Print()
        {

        }

        #endregion メソッド

        #region 内部メソッド

        /// <summary>
        /// 縦と斜めに重複しないかチェック
        /// </summary>
        /// <returns></returns>
        private bool Check(int r, int c, ConsCell pat)
        {
            return pat.Forall((ConsCell p) => 
                c != p.GetToInt(1) && r - p.GetToInt(0) != Math.Abs(c - p.GetToInt(1)));
        }

        /// <summary>
        /// 配置リストを複数返す
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        private ConsCell Queen(int r)
        {
            return TraceHelper.Trace("Queen", new string[] { r.ToString() }, () => {
                if (r == 0) return ConsCell.Of(ConsCell.Nil);
                return Queen(r - 1).FlatMap((ConsCell p) =>
                    ConsCell.Range(1, n + 1).Filter((int c) =>
                    Check(r, c, p)).Map((int c) => new ConsCell(ConsCell.Of(r, c), p)));
            });
        }

        #endregion 内部メソッド

    }
}
