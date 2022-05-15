using Mov.Game.Models.interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Game.Service
{
    public abstract class DrawServiceBase
    {
        #region フィールド

        /// <summary>
        /// ゲームスレッド
        /// </summary>
        private Task task;
        /// <summary>
        /// スレッド継続フラグ
        /// </summary>
        protected bool isActive = true;
        /// <summary>
        /// ビットマップ画面
        /// </summary>
        private Bitmap screenBitmap;

        #endregion フィールド

        #region プロパティ

        /// <summary>
        /// リポジトリ
        /// </summary>
        protected IGameRepositoryCollection Repository { get; private set; }
        /// <summary>
        /// 画面幅
        /// </summary>
        public int FrameWidth { get; protected set; } = 600;
        /// <summary>
        /// 画面高さ
        /// </summary>
        public int FrameHeight { get; protected set; } = 600;
        /// <summary>
        /// ビットマップ画面作成中フラグ
        /// </summary>
        protected bool IsBuilding { get; private set; } = false;
        /// <summary>
        /// グラフィック
        /// </summary>
        protected Graphics ScreenGraphics { get; private set; }


        #endregion プロパティ

        #region コンストラクター

        public DrawServiceBase(IGameRepositoryCollection repository)
        {
            this.Repository = repository;
            screenBitmap = new Bitmap(FrameWidth, FrameHeight);
            ScreenGraphics = Graphics.FromImage(screenBitmap);
        }

        #endregion コンストラクター

        #region メソッド

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            if (IsBuilding) return;
            graphics.DrawImage(screenBitmap, 0, 0);
        }

        #endregion メソッド

        #region 抽象メソッド

        public virtual void Initialize()
        {
            screenBitmap = new Bitmap(FrameWidth, FrameHeight);
            ScreenGraphics = Graphics.FromImage(screenBitmap);
            isActive = true;
        }

        public virtual void Run()
        {
            //マルチスレッド処理
            task = Task.Run(() =>
            {
                var sw = Stopwatch.StartNew();
                sw.Start();
                while (isActive)
                {
                    Ready();
                    //ビットマップ画面の作成処理
                    IsBuilding = true;
                    ClearScreen();
                    DrawScreen();
                    IsBuilding = false;
                    //再描画要求
                    InvalidateScreen();
                    //速度調整
                    while (sw.ElapsedMilliseconds < 10) ;
                    sw.Restart();
                }
                DisposeScreen();
            });
        }

        protected abstract void Ready();

        /// <summary>
        /// 終了処理
        /// </summary>
        public void End()
        {
            //スレッド終了指令
            isActive = false;
            //スレッド終了待機
            task.Wait();
        }

        /// <summary>
        /// スクリーン初期化
        /// </summary>
        protected virtual void ClearScreen()
        {
            ScreenGraphics.Clear(Color.White);
        }

        protected abstract void DrawScreen();

        /// <summary>
        /// スクリーン更新
        /// </summary>
        protected virtual void InvalidateScreen()
        {
            //throw new NotImplementedException();
        }
        /// <summary>
        /// スクリーン廃棄
        /// </summary>
        protected virtual void DisposeScreen()
        {
            ScreenGraphics.Dispose();
        }

        #endregion 抽象メソッド
    }
}
