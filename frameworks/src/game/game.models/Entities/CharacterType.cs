namespace Mov.Game.Models.Entities
{
    public enum CharacterType
    {
        /// <summary>
        /// 種別無
        /// </summary>
        NONE = -9,

        /// <summary>
        /// 道
        /// </summary>
        BREAD = -1,

        /// <summary>
        /// 道
        /// </summary>
        ROAD = 0,

        /// <summary>
        /// 壁
        /// </summary>
        WALL = 1,

        /// <summary>
        /// プレイヤー
        /// </summary>
        PLAYER = 2,

        /// <summary>
        /// NPC
        /// </summary>
        ALIEN = 3,

        /// <summary>
        /// 宝
        /// </summary>
        TREASURE = 4,
    }
}