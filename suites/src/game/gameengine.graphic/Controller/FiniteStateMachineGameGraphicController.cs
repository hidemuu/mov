using Mov.Core.Graphicers.Services.Controllers;
using Mov.Game.Models;
using Mov.Game.Models.Entities;

namespace Mov.Suite.GameEngine.Graphic.Controller
{
    public class FiniteStateMachineGameGraphicController : GraphicControllerBase
    {
        #region field

        /// <summary>
        /// ゲームエンジン
        /// </summary>
        private IFiniteStateMachineGameClient client;

        #endregion field

        #region constructor

        public FiniteStateMachineGameGraphicController(IFiniteStateMachineGameClient client) : base()
        {
            this.client = client;
            FrameWidth = client.MapWidth;
            FrameHeight = client.MapHeight;
        }

        #endregion constructor

        #region inner method

        protected override void Ready()
        {
            foreach (var character in client.Characters)
            {
                switch (character.Type)
                {
                    //プレイヤー
                    case CharacterType.PLAYER:
                        //移動処理
                        if (character.Move()) client.Score++;
                        //ダメージ判定
                        if (character.IsDamage()) character.AddLife(-1);
                        //ゲームオーバー判定
                        if (character.Life <= 0) client.IsGameOver = true;
                        //ステージクリア判定
                        if (client.Score >= client.GetLandmark().ClearScore) client.IsStageClear = true;
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
            foreach (var character in client.Characters)
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

        #endregion inner method

        #region method

        /// <summary>
        /// 初期化処理
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            client.Score = 0;
            client.Initialize();
            client.IsGameOver = false;
            client.IsStageClear = false;
        }

        public void Next()
        {
            client.Level++;
            client.Score = 0;
            client.Initialize();
            IsActive = true;
            client.IsStageClear = false;
        }

        #endregion method
    }
}
