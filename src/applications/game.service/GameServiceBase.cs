using Mov.Game.Models;
using Mov.Game.Models.Characters;
using Mov.Game.Models.interfaces;
using Mov.Game.Models.Maps;
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

        #endregion フィールド

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
        /// <summary>
        /// トータルスコア
        /// </summary>
        public int TotalScore { get; private set; } = 0;
        /// <summary>
        /// レベル
        /// </summary>
        public int Level { get; private set; } = 1;

        #endregion フィールド

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="repository"></param>
        public GameServiceBase(IGameRepositoryCollection repository)
        {
            this.repository = repository;
            var map = GetLandmark();
            gameEngine = new GameEngine();
            FrameWidth = map.GetCol() * gameEngine.UnitWidth;
            FrameHeight = map.GetRow() * gameEngine.UnitHeight;
            screenBitmap = new Bitmap(FrameWidth, FrameHeight);
            ScreenGraphics = Graphics.FromImage(screenBitmap);
        }

        #endregion コンストラクター

        #region メソッド

        /// <summary>
        /// 初期化処理
        /// </summary>
        public virtual void Initialize()
        {
            Score = 0;
            screenBitmap = new Bitmap(FrameWidth, FrameHeight);
            ScreenGraphics = Graphics.FromImage(screenBitmap);
            gameEngine.Initialize(GetLandmark());
            isActive = true;
            IsGameOver = false;
            IsStageClear = false;
        }

        public void Next()
        {
            Level++;
            TotalScore += Score;
            Score = 0;
            gameEngine.Initialize(GetLandmark());
            isActive = true;
            IsStageClear = false;
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
                while (isActive)
                {
                    //キャラクタ毎の処理
                    foreach (var character in gameEngine.Characters)
                    {
                        switch (character.TypeCode)
                        {
                            //プレイヤー
                            case GameMap.PLAYER:
                                //移動処理
                                if(character.Move()) Score++;
                                //ダメージ判定
                                if (character.IsDamage()) character.AddLife(-1);
                                //ゲームオーバー判定
                                if (character.Life <= 0) IsGameOver = true;
                                //ステージクリア判定
                                if(Score >= GetLandmark().ClearScore) IsStageClear = true;
                                break;
                            //敵
                            case GameMap.ALIEN:
                                //移動処理
                                character.Move(); 
                                break;
                        }
                    }
                    //ビットマップ画面の作成処理
                    IsBuilding = true;
                    ClearScreen();
                    foreach (var character in gameEngine.Characters)
                    {
                        if (character.TypeCode != GameMap.ROAD) DrawCharacter(character);
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

        public void SetLevel(int lv)
        {
            Level = lv;
        }

        public IEnumerable<int> GetLevels()
        {
            return repository.Landmarks.Gets().Select(x => x.Lv);
        }

        public Landmark GetLandmark()
        {
            return repository.Landmarks.Gets().FirstOrDefault(x => x.Lv == Level);
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

        /// <summary>
        /// ライフ取得
        /// </summary>
        /// <returns></returns>
        public int GetLife()
        {
            foreach (var character in gameEngine.Characters)
            {
                switch (character.TypeCode)
                {
                    case GameMap.PLAYER:
                        return character.Life;
                }
            }
            return -1;
        }

        #endregion メソッド

        #region 抽象メソッド

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

        #endregion 抽象メソッド

    }
}