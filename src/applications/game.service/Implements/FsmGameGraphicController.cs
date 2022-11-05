using Mov.Game.Engine;
using Mov.Game.Models.Maps;
using Mov.Painters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Game.Service.Implements
{
    public class FsmGameGraphicController : GraphicControllerBase
    {
        #region フィールド

        /// <summary>
        /// ゲームエンジン
        /// </summary>
        private IFsmGameEngine engine;

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

        #endregion プロパティ

        #region コンストラクター

        public FsmGameGraphicController(IFsmGameEngine engine) : base()
        {
            this.engine = engine;
            var map = engine.GetLandmark(Level);
            FrameWidth = map.GetCol() * engine.UnitWidth;
            FrameHeight = map.GetRow() * engine.UnitHeight;
        }

        #endregion コンストラクター

        #region 抽象メソッド

        protected override void Ready()
        {
            foreach (var character in this.engine.Characters)
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
                        if (Score >= this.engine.GetLandmark(Level).ClearScore) IsStageClear = true;
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
            foreach (var character in engine.Characters)
            {
                if (character.TypeCode != GameMap.ROAD) DrawCharacter(character);
            }
        }

        /// <summary>
        /// キャラクター描画
        /// </summary>
        /// <param name="character"></param>
        protected virtual void DrawCharacter(IFsmCharacter character)
        {
            character.Draw(ScreenGraphics);
        }

        #endregion 抽象メソッド

        #region メソッド

        /// <summary>
        /// 初期化処理
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            Score = 0;
            engine.Initialize(this.engine.GetLandmark(Level));
            IsGameOver = false;
            IsStageClear = false;
        }

        public void Next()
        {
            Level++;
            TotalScore += Score;
            Score = 0;
            engine.Initialize(this.engine.GetLandmark(Level));
            IsActive = true;
            IsStageClear = false;
        }

        #endregion メソッド
    }
}
