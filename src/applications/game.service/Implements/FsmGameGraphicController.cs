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
    public class FsmGameGraphicController : GraphicControllerBase
    {
        #region フィールド

        /// <summary>
        /// ゲームエンジン
        /// </summary>
        private IFsmGameEngine engine;

        #endregion フィールド

        #region コンストラクター

        public FsmGameGraphicController(IFsmGameEngine engine) : base()
        {
            this.engine = engine;
            var map = engine.Service.GetLandmark();
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
                        if (character.Move()) this.engine.Service.Score++;
                        //ダメージ判定
                        if (character.IsDamage()) character.AddLife(-1);
                        //ゲームオーバー判定
                        if (character.Life <= 0) this.engine.Service.IsGameOver = true;
                        //ステージクリア判定
                        if (this.engine.Service.Score >= this.engine.Service.GetLandmark().ClearScore) this.engine.Service.IsStageClear = true;
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
            foreach (var character in this.engine.Characters)
            {
                if (character.TypeCode != GameMap.ROAD) DrawCharacter(character);
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
            this.engine.Service.Score = 0;
            this.engine.Initialize();
            this.engine.Service.IsGameOver = false;
            this.engine.Service.IsStageClear = false;
        }

        public void Next()
        {
            this.engine.Service.Level++;
            this.engine.Service.Score = 0;
            this.engine.Initialize();
            this.IsActive = true;
            this.engine.Service.IsStageClear = false;
        }

        #endregion メソッド
    }
}
