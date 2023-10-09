using Mov.Core.Graphicers.Services.Controllers;
using Mov.Game.Models.Entities;
using Mov.Game.Models.ValueObjects;
using Mov.Game.Service;

namespace Mov.Suite.GameEngine.Graphic.Controller
{
    public class FiniteStateMachineGameGraphicController : GraphicControllerBase
    {
        #region field

        /// <summary>
        /// ゲームクライアント
        /// </summary>
        private IFiniteStateMachineGameClient _client;

        #endregion field

        #region constructor

        public FiniteStateMachineGameGraphicController(IFiniteStateMachineGameClient client) : base()
        {
            this._client = client;
            FrameWidth = client.MapWidth;
            FrameHeight = client.MapHeight;
        }

        #endregion constructor

        #region inner method

        protected override void Ready()
        {
            foreach (var character in _client.Characters)
            {
                switch (character.Type)
                {
                    //プレイヤー
                    case CharacterType.PLAYER:
                        //移動処理
                        if (character.Move()) _client.Score++;
                        //ダメージ判定
                        if (character.IsDamage()) character.AddLife(-1);
                        //ゲームオーバー判定
                        if (character.Life <= 0) _client.IsGameOver = true;
                        //ステージクリア判定
                        if (_client.Score >= _client.GetLandmark().ClearScore) _client.IsStageClear = true;
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
            foreach (var character in _client.Characters)
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
            _client.Score = 0;
            _client.Initialize();
            _client.IsGameOver = false;
            _client.IsStageClear = false;
        }

        public void Next()
        {
            _client.Level++;
            _client.Score = 0;
            _client.Initialize();
            IsActive = true;
            _client.IsStageClear = false;
        }

        #endregion method
    }
}
