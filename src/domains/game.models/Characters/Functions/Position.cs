using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models.Characters.Functions
{
    /// <summary>
    /// 位置クラス
    /// </summary>
    public class Position
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
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        #region メソッド

        /// <summary>
        /// 等価判定
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool Equals(Position p)
        {
            return this.Row == p.Row && this.Col == p.Col;
        }

        #endregion
    }
}
