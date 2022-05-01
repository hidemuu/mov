using Mov.Game.Models;
using Mov.Game.Models.Characters;
using Mov.Game.Models.interfaces;
using Mov.Game.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Game.Service
{
    /// <summary>
    /// ゲームサービス基本クラス
    /// </summary>
    public abstract class GameServiceBase : IGameService
    {
        #region フィールド

        /// <summary>
        /// ゲームスレッド
        /// </summary>
        private Task task;
        /// <summary>
        /// スレッド継続フラグ
        /// </summary>
        private bool isActive = true;
        /// <summary>
        /// ゲームエンジン
        /// </summary>
        private GameEngine gameEngine;
        /// <summary>
        /// ランドマークリポジトリ
        /// </summary>
        private IGameRepositoryCollection repository;
        /// <summary>
        /// ビットマップ画面
        /// </summary>
        private Bitmap screenBitmap;

        #endregion

        #region プロパティ

        /// <summary>
        /// 画面幅
        /// </summary>
        protected int FrameWidth { get; private set; }
        /// <summary>
        /// 画面高さ
        /// </summary>
        protected int FrameHeight { get; private set; }
        /// <summary>
        /// ビットマップ画面作成中フラグ
        /// </summary>
        protected bool IsBuilding { get; private set; } = false;
        /// <summary>
        /// グラフィック
        /// </summary>
        protected Graphics ScreenGraphics { get; private set; }
        /// <summary>
        /// ゲームオーバー判定
        /// </summary>
        public bool IsGameOver { get; private set; } = false;
        /// <summary>
        /// ステージクリア判定
        /// </summary>
        public bool IsStageClear { get; private set; } = false;
        /// <summary>
        /// スコア
        /// </summary>
        public int Score { get; private set; } = 0;

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="repository"></param>
        public GameServiceBase(IGameRepositoryCollection repository)
        {
            this.repository = repository;
            var maps = repository.Landmarks.Gets().ToArray();
            gameEngine = new GameEngine();
            FrameWidth = maps[0].GetCol() * gameEngine.UnitWidth;
            FrameHeight = maps[0].GetRow() * gameEngine.UnitHeight;
            screenBitmap = new Bitmap(FrameWidth, FrameHeight);
            ScreenGraphics = Graphics.FromImage(screenBitmap);
        }

        #region メソッド

        /// <summary>
        /// 初期化処理
        /// </summary>
        public virtual void Initialize()
        {
            screenBitmap = new Bitmap(FrameWidth, FrameHeight);
            ScreenGraphics = Graphics.FromImage(screenBitmap);
            gameEngine.Initialize(repository.Landmarks.Gets().ToArray()[0]);
            isActive = true;
            IsGameOver = false;
        }



        /// <summary>
        /// 起動処理
        /// </summary>
        public void Run()
        {
            Initialize();

            //マルチスレッド処理
            task = Task.Run(() =>
            {
                var sw = Stopwatch.StartNew();
                sw.Start();
                while (isActive)
                {
                    //キャラクタの移動処理
                    foreach (var character in gameEngine.Characters)
                    {
                        switch (character.TypeCode)
                        {
                            case CharacterBase.PLAYER:
                                if(character.Move()) Score++;
                                break;
                            case CharacterBase.ALIEN:
                                character.Move(); break;
                        }
                    }
                    //ゲームオーバー判定
                    foreach (var character in gameEngine.Characters)
                    {
                        switch (character.TypeCode)
                        {
                            case CharacterBase.PLAYER:
                                if (character.IsDamage()) 
                                {
                                    character.AddLife(-1);
                                }
                                if (character.Life <= 0) IsGameOver = true;
                                break;
                        }
                    }
                    //ビットマップ画面の作成処理
                    IsBuilding = true;
                    ClearScreen();
                    foreach (var character in gameEngine.Characters)
                    {
                        if (character.TypeCode != CharacterBase.ROAD) DrawCharacter(character);
                    }
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

        /// <summary>
        /// 終了処理
        /// </summary>
        public void End()
        {
            //スレッド終了指令
            isActive = false;
            //スレッド終了待機
            task.Wait();
            IsGameOver = false;
        }

        /// <summary>
        /// キーコード設定
        /// </summary>
        /// <param name="keyCode"></param>
        public void SetKeyCode(int keyCode)
        {
            gameEngine.KeyCode = keyCode;
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            if (IsBuilding) return;
            graphics.DrawImage(screenBitmap, 0, 0);
        }

        public int GetLife()
        {
            foreach (var character in gameEngine.Characters)
            {
                switch (character.TypeCode)
                {
                    case CharacterBase.PLAYER:
                        return character.Life;
                }
            }
            return -1;
        }

        #endregion

        #region 抽象メソッド - テンプレート

        /// <summary>
        /// スクリーン初期化
        /// </summary>
        protected abstract void ClearScreen();
        /// <summary>
        /// キャラクター描画
        /// </summary>
        /// <param name="character"></param>
        protected abstract void DrawCharacter(CharacterBase character);
        /// <summary>
        /// スクリーン更新
        /// </summary>
        protected abstract void InvalidateScreen();
        /// <summary>
        /// スクリーン廃棄
        /// </summary>
        protected abstract void DisposeScreen();

        #endregion

    }
}