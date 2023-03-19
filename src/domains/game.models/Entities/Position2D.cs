using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models.Entities
{
    /// <summary>
    /// 位置クラス
    /// </summary>
    public class Position2D
    {
        #region プロパティ

        public int Row { get; private set; }
        public int Col { get; private set; }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public Position2D(int row, int col)
        {
            Row = row;
            Col = col;
        }

        #region メソッド

        /// <summary>
        /// 等価判定
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool Equals(Position2D p)
        {
            return Row == p.Row && Col == p.Col;
        }

        #endregion
    }
}
