using Mov.Calculators;
using Mov.Game.Models;
using Mov.Painters;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mov.Game.Service.Puzzle
{
    /// <summary>
    /// ハノイの塔のゲームサービス
    /// </summary>
    public class TowerOfHanoiGameService : GraphicControllerBase, IConsoleGameService
    {
        #region フィールド

        /// <summary>
        /// 塔
        /// </summary>
        private readonly ConsCell[] tower;
        /// <summary>
        /// 円盤数
        /// </summary>
        private readonly int n;
        /// <summary>
        /// 円盤
        /// </summary>
        private Saucer[] saucers;

        #endregion フィールド

        #region プロパティ

        public override double RefleshTime { get; set; } = 300;

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public TowerOfHanoiGameService(int n)
        {
            this.n = n;
            this.tower = new ConsCell[] { ConsCell.Range(1, n + 1), ConsCell.Nil, ConsCell.Nil };
            this.saucers = new Saucer[n];
            for (var i = 0; i < n; i++)
            {
                saucers[i] = new Saucer(i, n, FrameWidth, FrameHeight);
            }
        }

        #endregion コンストラクター

        #region 継承メソッド

        protected override void Ready()
        {
            Hanoi(this.n, 0, 2, 1);
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        protected override void DrawScreen()
        {
            foreach (var saucer in this.saucers)
            {
                saucer.Draw(ScreenGraphics);
            }
        }

        #endregion 継承メソッド

        #region メソッド

        public void Print()
        {
            Hanoi(this.n, 0, 2, 1);
        }

        #endregion メソッド

        #region 内部メソッド

        /// <summary>
        /// fromのm番目の円盤をtoへ移動、workは作業場所
        /// </summary>
        /// <param name="m"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="work"></param>
        private void Hanoi(int m, int from, int to, int work)
        {
            if(m == 1)
            {
                DisplayCanvas(from, to);
                //移動対象が1枚なら、toの先頭に fromの先頭を追加
                tower[to] = new ConsCell(tower[from].Head, tower[to]);
                tower[from] = tower[from].Tail; //fromの先頭を取り除く
                DisplayConsole();
                return;
            }
            Hanoi(m - 1, from, work, to);   //fromからworkへ移動
            Hanoi(1, from, to, work);       //fromからtoへ移動
            Hanoi(m - 1, work, to, from);   //workからtoへ移動
        }

        /// <summary>
        /// 状態の表示
        /// </summary>
        private void DisplayConsole()
        {
            var s = ConsCell.FromArray(this.tower).Map((ConsCell x) => ConsCell.Fill(0, n - x.Length()).Append(x));  //上層を0で埋める
            //上の層からループする
            while(s.Head != ConsCell.Nil)
            {
                s = s.Map((ConsCell x) => { 
                    var v = (int)x.Head;
                    Console.Write(ConsCell.Repeat("  ", n - v) + ConsCell.Repeat("■■", v) + ConsCell.Repeat("  ", n - v));
                    return x.Tail;  //残りの下層を返し新たなsにする
                });
                Console.WriteLine("");
            }
            Console.WriteLine(ConsCell.Repeat("￣", n * 2 * 3));
        }

        /// <summary>
        /// 状態の表示
        /// </summary>
        private void DisplayCanvas(int from, int to)
        {
            var saucer = saucers[(int)tower[from].Head - 1];    //移動対象の円盤
            saucer.Move(to, tower[to].Length());                //円盤の座標変更
        }

        #endregion 内部メソッド

        #region 内部クラス

        /// <summary>
        /// 円盤を表すクラス
        /// </summary>
        private class Saucer
        {

            #region フィールド

            private int idx;
            private int n;
            private int x;
            private int y;
            private int width;
            private int height;
            private double formWidth;
            private double formHeight;
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));

            #endregion フィールド

            /// <summary>
            /// コンストラクター
            /// </summary>
            /// <param name="idx"></param>
            /// <param name="n"></param>
            public Saucer(int idx, int n, double formWidth, double formHeight)
            {
                this.idx = idx;
                this.n = n;
                this.formWidth = formWidth;
                this.formHeight = formHeight;
                this.width = (int)(formWidth * (0.3 - (n - idx) * 0.2 / n));
                this.height = (int)(formHeight / Math.Max(10, n) * 0.9);
                Move(0, n - idx - 1);
            }

            #region メソッド

            /// <summary>
            /// 座標設定
            /// </summary>
            /// <param name="tower"></param>
            /// <param name="level"></param>
            public void Move(int tower, int level)
            {
                this.x = (int)(this.formWidth * 0.5 + (tower - 1) * this.formWidth * 0.3 - this.width * 0.5);
                this.y = (int)(this.formHeight - (level + 1) * this.height - 1);
            }

            /// <summary>
            /// 描画
            /// </summary>
            /// <param name="graphics"></param>
            public void Draw(Graphics graphics)
            {
                graphics.DrawRectangle(this.pen, this.x, this.y, this.width, this.height);
            }

            #endregion メソッド

        }

        #endregion 内部クラス

    }
}
