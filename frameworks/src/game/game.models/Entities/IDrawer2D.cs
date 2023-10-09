using System.Drawing;

namespace Mov.Game.Models.Entities
{
    public interface IDrawer2D
    {
        /// <summary>
        /// 座標設定
        /// </summary>
        void Move(int x, int y);

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="graphics"></param>
        void Draw(Graphics graphics);
    }
}
