﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Drawer.Service
{
    public abstract class DrawServiceBase
    {
        #region フィールド

        /// <summary>
        /// ゲームスレッド
        /// </summary>
        private Task task;
        /// <summary>
        /// ビットマップ画面
        /// </summary>
        private Bitmap screenBitmap;

        #endregion フィールド

        #region プロパティ

        /// <summary>
        /// 画面幅
        /// </summary>
        public virtual int FrameWidth { get; set; } = 600;
        /// <summary>
        /// 画面高さ
        /// </summary>
        public virtual int FrameHeight { get; set; } = 600;
        /// <summary>
        /// 更新周期
        /// </summary>
        public virtual double RefleshTime { get; set; } = 10;

        /// <summary>
        /// スレッド継続フラグ
        /// </summary>
        protected bool IsActive { get; set; } = true;
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

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DrawServiceBase()
        {
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

        /// <summary>
        /// 初期化処理
        /// </summary>
        public virtual void Initialize()
        {
            screenBitmap = new Bitmap(FrameWidth, FrameHeight);
            ScreenGraphics = Graphics.FromImage(screenBitmap);
            IsActive = true;
        }

        /// <summary>
        /// 起動処理
        /// </summary>
        public void Run()
        {
            //マルチスレッド処理
            task = Task.Run(() =>
            {
                var sw = Stopwatch.StartNew();
                sw.Start();
                while (IsActive)
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
                    while (sw.ElapsedMilliseconds < RefleshTime) ;
                    sw.Restart();
                }
                DisposeScreen();
            });
        }

        /// <summary>
        /// 停止処理
        /// </summary>
        public void Wait()
        {
            //スレッド終了指令
            IsActive = false;
            //スレッド終了待機
            task.Wait();
            DisposeScreen();
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void End()
        {
            //スレッド終了指令
            IsActive = false;
            //スレッド終了待機
            task.Dispose();
            DisposeScreen();
        }

        #endregion メソッド

        #region 抽象メソッド

        /// <summary>
        /// 描画準備
        /// </summary>
        protected abstract void Ready();

        /// <summary>
        /// スクリーン初期化
        /// </summary>
        protected virtual void ClearScreen()
        {
            ScreenGraphics.Clear(Color.White);
        }

        /// <summary>
        /// スクリーン描画
        /// </summary>
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