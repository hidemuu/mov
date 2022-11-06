using Mov.Game.Models;
using System;

namespace Mov.Game.Models.Maps
{
    /// <summary>
    /// マップ生成情報
    /// </summary>
    public class Map2D
    {
        
        #region フィールド

        private static string mark = Landmark.ROAD + Landmark.WALL + Landmark.PALYER + Landmark.ALIEN + Landmark.TREASURE;

        #endregion フィールド

        #region メソッド

        /// <summary>
        /// マップ構築
        /// </summary>
        /// <returns></returns>
        public static int[,] MakeMap(Landmark landMark)
        {
            var row = landMark.GetRow();
            var col = landMark.GetCol();
            var map = new int[row, col];
            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < col; j++)
                {
                    map[i, j] = mark.IndexOf(landMark.MarkRows[i][j]);
                }
            }
            return map;
        }
        #endregion メソッド
    }
}
