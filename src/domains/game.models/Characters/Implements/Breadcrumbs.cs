using Mov.Game.Models;
using Mov.Game.Models.Characters.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Game.Models.Characters
{
    /// <summary>
    /// パンくず拾いクラス
    /// </summary>
    public class Breadcrumbs
    {
      
        #region フィールド

        private int len;
        private IFsmGameEngine engine;
        private int[,] map;
        private LinkedList<Position2D> positions = new LinkedList<Position2D>();
        private int[,] dirOffset = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
        private int[] tryPlan = { 0, 1, 3, 2 };

        #endregion

        #region プロパティ

        public Bread[] breads;

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="len"></param>
        /// <param name="engine"></param>
        /// <param name="mapRow"></param>
        /// <param name="mapCol"></param>
        public Breadcrumbs(int len, IFsmGameEngine engine, int mapRow, int mapCol)
        {
            this.len = len;
            this.engine = engine;
            breads = new Bread[len];
            for (var i = 0; i < len; i++) breads[i] = new Bread(engine);
            this.map = new int[mapRow, mapCol];
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
                this.map[pos.Row, pos.Col] = 0;
            }
            var p = new Position2D(row, col);
            if (this.map[row, col] != 0)
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
            this.map[row, col] = 1;
            PlotBread();
        }

        public int Trail(int row, int col, int dir)
        {
            for (var i = 0; i < 3; i++)
            {
                var tryDir = (dir + tryPlan[i]) % 4;
                if (this.map[row + dirOffset[tryDir, 1], col + dirOffset[tryDir, 0]] == 1)
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
                var x = (int)((p.Col + 0.5) * this.engine.UnitWidth);
                var y = (int)((p.Row + 0.5) * this.engine.UnitHeight);
                breads[i++].SetPosition(x, y);
            }
        }

        #endregion

    }
}
