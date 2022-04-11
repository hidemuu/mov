using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models.Maps
{
    public class LandmarkCollection : DbObjectCollection<Landmark>
    {
        public override Landmark[] Items { get; set; }
    }

    public class Landmark : DbObject
    {
        #region 定数
        /// <summary>
        /// 道
        /// </summary>
        public const string ROAD = "＿";
        /// <summary>
        /// 壁
        /// </summary>
        public const string WALL = "＃";
        /// <summary>
        /// プレイヤー
        /// </summary>
        public const string PALYER = "○";
        /// <summary>
        /// NPC
        /// </summary>
        public const string ALIEN = "＠";
        #endregion

        #region プロパティ
        /// <summary>
        /// ランドマーク行文字列群
        /// </summary>
        public string[] MarkRows { get; set; }
        #endregion

        #region メソッド
        /// <summary>
        /// 行サイズ
        /// </summary>
        public int GetRow() => MarkRows.Length;
        /// <summary>
        /// 列サイズ
        /// </summary>
        public int GetCol() => MarkRows[0].Length;
        #endregion
    }
}
