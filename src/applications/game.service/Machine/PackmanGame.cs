using Mov.Accessors.Repository;
using Mov.Game.Models;
using Mov.Game.Models.Characters;
using Mov.Game.Models.Engines;
using Mov.Game.Models.Maps;
using Mov.Game.Repository;
using Mov.Painters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Game.Service.Machine
{
    /// <summary>
    /// パックマンっぽいゲームサービス
    /// </summary>
    public class PackmanGame : GraphicControllerBase, IActionGame
    {
        #region フィールド

        /// <summary>
        /// リポジトリ
        /// </summary>
        protected IGameRepository Repository { get; private set; }

        /// <summary>
        /// ゲームエンジン
        /// </summary>
        private FsmGameEngine gameEngine;
        
        #endregion フィールド

        #region プロパティ

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
        public PackmanGame(IDomainRepositoryCollection<IGameRepository> database) : base()
        {
            this.Repository = database.GetRepository("");
            var map = GetLandmark();
            gameEngine = new FsmGameEngine();
            FrameWidth = map.GetCol() * gameEngine.UnitWidth;
            FrameHeight = map.GetRow() * gameEngine.UnitHeight;
        }

        #endregion コンストラクター

        #region メソッド

        /// <summary>
        /// 初期化処理
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            Score = 0;
            gameEngine.Initialize(GetLandmark());
            IsGameOver = false;
            IsStageClear = false;
        }

        public void Next()
        {
            Level++;
            TotalScore += Score;
            Score = 0;
            gameEngine.Initialize(GetLandmark());
            IsActive = true;
            IsStageClear = false;
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
            return Repository.Landmarks.Get().Select(x => x.Lv);
        }

        public Landmark GetLandmark()
        {
            return Repository.Landmarks.Get().FirstOrDefault(x => x.Lv == Level);
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

        protected override void Ready()
        {
            foreach (var character in gameEngine.Characters)
            {
                switch (character.TypeCode)
                {
                    //プレイヤー
                    case GameMap.PLAYER:
                        //移動処理
                        if (character.Move()) Score++;
                        //ダメージ判定
                        if (character.IsDamage()) character.AddLife(-1);
                        //ゲームオーバー判定
                        if (character.Life <= 0) IsGameOver = true;
                        //ステージクリア判定
                        if (Score >= GetLandmark().ClearScore) IsStageClear = true;
                        break;
                    //敵
                    case GameMap.ALIEN:
                        //移動処理
                        character.Move();
                        break;
                }
            }
        }

        protected override void DrawScreen()
        {
            foreach (var character in gameEngine.Characters)
            {
                if (character.TypeCode != GameMap.ROAD) DrawCharacter(character);
            }
        }

        /// <summary>
        /// キャラクター描画
        /// </summary>
        /// <param name="character"></param>
        protected virtual void DrawCharacter(CharacterBase character)
        {
            character.Draw(ScreenGraphics);
        }
        
        #endregion 抽象メソッド

    }
}