using System.Drawing;

namespace Mov.Core.Graphicers.Services.Controllers
{
    public interface IGraphicController
    {
        #region property

        /// <summary>
        /// 画面幅
        /// </summary>
        int FrameWidth { get; set; }

        /// <summary>
        /// 画面高さ
        /// </summary>
        int FrameHeight { get; set; }

        /// <summary>
        /// 更新周期
        /// </summary>
        double RefleshTime { get; set; }

        /// <summary>
        /// スレッド継続フラグ
        /// </summary>
        bool IsActive { get; set; }

        #endregion property

        #region method

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="graphics"></param>
        void Draw(Graphics graphics);

        /// <summary>
        /// 初期化処理
        /// </summary>
        void Initialize();

        /// <summary>
        /// 起動処理
        /// </summary>
        void Run();

        /// <summary>
        /// 停止処理
        /// </summary>
        void Wait();

        /// <summary>
        /// 終了処理
        /// </summary>
        void End();

        #endregion method

    }
}
