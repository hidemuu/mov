using Mov.Core.Graphicers.Services.Controllers;
using Mov.Game.Models;
using Mov.Game.Models.Entities;

namespace Mov.Game.Controller.Graphic
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
            foreach (var character in engine.Characters)
            {
                switch (character.Type)
                {
                    //プレイヤー
                    case CharacterType.PLAYER:
                        //移動処理
                        if (character.Move()) engine.Score++;
                        //ダメージ判定
                        if (character.IsDamage()) character.AddLife(-1);
                        //ゲームオーバー判定
                        if (character.Life <= 0) engine.IsGameOver = true;
                        //ステージクリア判定
                        if (engine.Score >= engine.GetLandmark().ClearScore) engine.IsStageClear = true;
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
            foreach (var character in engine.Characters)
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
            engine.Score = 0;
            engine.Initialize();
            engine.IsGameOver = false;
            engine.IsStageClear = false;
        }

        public void Next()
        {
            engine.Level++;
            engine.Score = 0;
            engine.Initialize();
            IsActive = true;
            engine.IsStageClear = false;
        }

        #endregion メソッド
    }
}