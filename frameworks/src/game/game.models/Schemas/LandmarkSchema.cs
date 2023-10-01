using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;

namespace Mov.Game.Models.Schemas
{
    public class LandmarkSchemaCollection : DbCollectionSchemaBase<LandmarkSchema, Guid>
    {
        [JsonProperty("landmarks")]
        public override LandmarkSchema[] Items { get; set; }
    }

    public sealed class LandmarkSchema : DbSchemaBase<Guid>
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
        public const string PALYER = "◯";

        /// <summary>
        /// NPC
        /// </summary>
        public const string ALIEN = "＠";

        /// <summary>
        /// 宝
        /// </summary>
        public const string TREASURE = "☆";

        #endregion 定数

        #region プロパティ

        [JsonProperty("lv")]
        public int Lv { get; set; }

        [JsonProperty("clear_score")]
        public int ClearScore { get; set; }

        /// <summary>
        /// ランドマーク行文字列群
        /// </summary>
        [JsonProperty("mark_rows")]
        public string[] MarkRows { get; set; }

        #endregion プロパティ

        #region メソッド

        /// <summary>
        /// 行サイズ
        /// </summary>
        public int GetRow() => MarkRows.Length;

        /// <summary>
        /// 列サイズ
        /// </summary>
        public int GetCol() => MarkRows[0].Length;

        #endregion メソッド
    }
}