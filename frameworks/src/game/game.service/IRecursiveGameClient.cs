using Mov.Core.Learnings.Models;
using Mov.Game.Models.Entities;

namespace Mov.Game.Service
{
    /// <summary>
    /// 再起問題解決ゲームクライアント
    /// </summary>
    public interface IRecursiveGameClient
    {
        /// <summary>
        /// 再起セル
        /// </summary>
        ConsCell[] Cons { get; }

        /// <summary>
        /// 再帰数
        /// </summary>
        int N { get; }

        /// <summary>
        /// 描画オブジェクト
        /// </summary>
        IDrawer2D[] Drawers { get; }
    }
}
