using Mov.Game.Engine;
using Mov.Game.Models;
using Mov.Game.Models.Maps;
using Mov.Painters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Game.Service.Implements
{
    public class FiniteStateMachineGameGraphicController : GraphicControllerBase
    {
        #region フィールド

        /// <summary>
        /// ゲームエンジン
        /// </summary>
        private IFiniteStateMachineGameEngine engine;

        #endregion フィールド

        #region コンストラクター

        public FiniteStateMachineGameGraphicController(IFiniteStateMachineGameEngine engine) : base()
        {
            this.engine = engine;
            FrameWidth = engine.MapWidth;
            FrameHeight = engine.MapHeight;
        }

        #endregion コンストラクター

        #region 抽象メソッド

        protected override void Ready()
        {
            foreach (var character in this.engine.Characters)
            {
                switch (character.Type)
                {
                    //プレイヤー
                    case CharacterType.PLAYER:
                        //移動処理
                        if (character.Move()) this.engine.Score++;
                        //ダメージ判定
                        if (character.IsDamage()) character.AddLife(-1);
                        //ゲームオーバー判定
                        if (character.Life <= 0) this.engine.IsGameOver = true;
                        //ステージクリア判定
                        if (this.engine.Score >= this.engine.GetLandmark().ClearScore) this.engine.IsStageClear = true;
                        break;
                    //敵
                    case CharacterType.ALIEN:
                        //移動処理
                        character.Move();
                        break;
                }
            }
        }

        protected override void DrawScreen()
        {
            foreach (var character in this.engine.Characters)
            {
                if (character.Type != CharacterType.ROAD) DrawCharacter(character);
            }
        }

        /// <summary>
        /// キャラクター描画
        /// </summary>
        /// <param name="character"></param>
        protected virtual void DrawCharacter(ICharacter character)
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
            this.engine.Score = 0;
            this.engine.Initialize();
            this.engine.IsGameOver = false;
            this.engine.IsStageClear = false;
        }

        public void Next()
        {
            this.engine.Level++;
            this.engine.Score = 0;
            this.engine.Initialize();
            this.IsActive = true;
            this.engine.IsStageClear = false;
        }

        #endregion メソッド
    }
}
