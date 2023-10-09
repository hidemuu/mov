using Mov.Game.Models;
using Mov.Game.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Mov.Suite.GameClient.FiniteStateMechine.Entities
{
    /// <summary>
    /// パンくず拾いクラス
    /// </summary>
    public class Breadcrumbs
    {
        #region フィールド

        private int len;
        private IFiniteStateMachineGameClient engine;
        private int[,] map;
        private LinkedList<Position2D> positions = new LinkedList<Position2D>();
        private int[,] dirOffset = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
        private int[] tryPlan = { 0, 1, 3, 2 };

        #endregion フィールド

        #region プロパティ

        public Bread[] breads;

        #endregion プロパティ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="len"></param>
        /// <param name="engine"></param>
        /// <param name="mapRow"></param>
        /// <param name="mapCol"></param>
        public Breadcrumbs(int len, IFiniteStateMachineGameClient engine, int mapRow, int mapCol)
        {
            this.len = len;
            this.engine = engine;
            breads = new Bread[len];
            for (var i = 0; i < len; i++) breads[i] = new Bread(engine);
            map = new int[mapRow, mapCol];
        }

        #region メソッド

        public void Drop(int row, int col)
        {
            if (positions.Count > 0)
            {
                var last = positions.Last();
                if (row == last.Row && col == last.Col) return;
            }
            if (positions.Count >= len)
            {
                var pos = positions.First();
                positions.RemoveFirst();
                map[pos.Row, pos.Col] = 0;
            }
            var p = new Position2D(row, col);
            if (map[row, col] != 0)
            {
                var idx = -1;
                for (var i = 0; i < positions.Count; i++)
                {
                    if (positions.ElementAt(i).Equals(p)) idx = i;
                }
                if (idx != -1)
                {
                    positions.Remove(positions.ElementAt(idx));
                }
            }
            positions.AddLast(p);
            map[row, col] = 1;
            PlotBread();
        }

        public int Trail(int row, int col, int dir)
        {
            for (var i = 0; i < 3; i++)
            {
                var tryDir = (dir + tryPlan[i]) % 4;
                if (map[row + dirOffset[tryDir, 1], col + dirOffset[tryDir, 0]] == 1)
                {
                    return tryDir;
                }
            }
            return -1;
        }

        private void PlotBread()
        {
            var i = 0;
            foreach (var p in positions)
            {
                var x = (int)((p.Col + 0.5) * engine.UnitWidth);
                var y = (int)((p.Row + 0.5) * engine.UnitHeight);
                breads[i++].SetPosition(x, y);
            }
        }

        #endregion メソッド
    }
}