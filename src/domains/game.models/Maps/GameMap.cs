using System;

namespace Mov.Game.Models.Maps
{
    /// <summary>
    /// マップ生成情報
    /// </summary>
    public class GameMap
    {
        #region 定数

        /// <summary>
        /// 種別無
        /// </summary>
        public const int NONE = -9;
        /// <summary>
        /// 道
        /// </summary>
        public const int BREAD = -1;
        /// <summary>
        /// 道
        /// </summary>
        public const int ROAD = 0;
        /// <summary>
        /// 壁
        /// </summary>
        public const int WALL = 1;
        /// <summary>
        /// プレイヤー
        /// </summary>
        public const int PLAYER = 2;
        /// <summary>
        /// NPC
        /// </summary>
        public const int ALIEN = 3;
        /// <summary>
        /// 宝
        /// </summary>
        public const int TREASURE = 4;

        #endregion

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
