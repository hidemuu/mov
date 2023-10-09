using Mov.Core.Graphicers.Services.Controllers;
using Mov.Core.Learnings.Models;
using Mov.Game.Models.Entities;
using Mov.Game.Service;
using System;

namespace Mov.Game.Controller.Graphic
{
    /// <summary>
    /// ハノイの塔のゲームサービス
    /// </summary>
    public class TowerOfHanoiGameController : GraphicControllerBase
    {
        #region field

        private readonly IRecursiveGameClient _client;

        #endregion field

        #region property

        public override double RefleshTime { get; set; } = 300;

        #endregion property

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        public TowerOfHanoiGameController(IRecursiveGameClient client)
        {
            _client = client;
        }

        #endregion constructor

        #region method

        public void Print()
        {
            Hanoi(_client.N, 0, 2, 1);
        }

        #endregion method

        #region inner method

        protected override void Ready()
        {
            Hanoi(_client.N, 0, 2, 1);
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        protected override void DrawScreen()
        {
            foreach (var saucer in _client.Drawers)
            {
                saucer.Draw(ScreenGraphics);
            }
        }

        /// <summary>
        /// fromのm番目の円盤をtoへ移動、workは作業場所
        /// </summary>
        /// <param name="m"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="work"></param>
        private void Hanoi(int m, int from, int to, int work)
        {
            if (m == 1)
            {
                DisplayCanvas(from, to);
                //移動対象が1枚なら、toの先頭に fromの先頭を追加
                _client.Cons[to] = new ConsCell(_client.Cons[from].Head, _client.Cons[to]);
                _client.Cons[from] = _client.Cons[from].Tail; //fromの先頭を取り除く
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
            var s = ConsCell.FromArray(_client.Cons).Map((ConsCell x) => ConsCell.Fill(0, _client.N - x.Length()).Append(x));  //上層を0で埋める
            //上の層からループする
            while (s.Head != ConsCell.Nil)
            {
                s = s.Map((ConsCell x) =>
                {
                    var v = (int)x.Head;
                    Console.Write(ConsCell.Repeat("  ", _client.N - v) + ConsCell.Repeat("■■", v) + ConsCell.Repeat("  ", _client.N - v));
                    return x.Tail;  //残りの下層を返し新たなsにする
                });
                Console.WriteLine("");
            }
            Console.WriteLine(ConsCell.Repeat("￣", _client.N * 2 * 3));
        }

        /// <summary>
        /// 状態の表示
        /// </summary>
        private void DisplayCanvas(int from, int to)
        {
            var saucer = _client.Drawers[(int)_client.Cons[from].Head - 1];    //移動対象の円盤
            saucer.Move(to, _client.Cons[to].Length());                //円盤の座標変更
        }

        #endregion inner method

    }
}
