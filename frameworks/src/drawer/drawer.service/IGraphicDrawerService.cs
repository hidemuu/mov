using System.Drawing;

namespace Mov.Drawer.Service
{
    public interface IGraphicDrawerService
    {
        #region プロパティ

        /// <summary>
        /// 画面幅
        /// </summary>
        int FrameWidth { get; }

        /// <summary>
        /// 画面高さ
        /// </summary>
        int FrameHeight { get; }

        #endregion プロパティ

        #region メソッド

        void Initialize();

        void Run();

        void Draw(Graphics graphics);

        #endregion メソッド
    }
}