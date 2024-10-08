﻿using Mov.Game.Models.Schemas;

namespace Mov.Game.Models.Entities
{
    /// <summary>
    /// マップ生成情報
    /// </summary>
    public class Map2D
    {
        #region field

        private static string mark = LandmarkSchema.ROAD + LandmarkSchema.WALL + LandmarkSchema.PALYER + LandmarkSchema.ALIEN + LandmarkSchema.TREASURE;

        #endregion field

        #region method

        /// <summary>
        /// マップ構築
        /// </summary>
        /// <returns></returns>
        public static int[,] MakeMap(LandmarkSchema landMark)
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

        #endregion method
    }
}