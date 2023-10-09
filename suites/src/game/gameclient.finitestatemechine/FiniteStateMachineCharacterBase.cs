using Mov.Game.Models;
using Mov.Game.Models.Entities;
using System.Drawing;

namespace Mov.Suite.GameClient.FiniteStateMechine
{
    /// <summary>
    /// キャラクター基本クラス
    /// </summary>
    public abstract class FiniteStateMachineCharacterBase : ICharacter
    {

        #region property

        /// <summary>
        /// 種類
        /// </summary>
        public abstract CharacterType Type { get; protected set; }

        /// <summary>
        /// 速度
        /// </summary>
        public abstract int Speed { get; protected set; }

        /// <summary>
        /// ライフ
        /// </summary>
        public abstract int Life { get; protected set; }

        /// <summary>
        /// キャラクター色
        /// </summary>
        protected abstract Brush BodyBrush { get; set; }

        /// <summary>
        /// X座標
        /// </summary>
        public int X { get; protected set; }

        /// <summary>
        /// Y座標
        /// </summary>
        public int Y { get; protected set; }

        /// <summary>
        /// ゲームエンジン
        /// </summary>
        protected IFiniteStateMachineGameClient Engine { get; private set; }

        /// <summary>
        /// 方向
        /// </summary>
        protected int Direction { get; set; }

        /// <summary>
        /// 行
        /// </summary>
        protected int Row { get; private set; }

        /// <summary>
        /// 列
        /// </summary>
        protected int Col { get; private set; }

        /// <summary>
        /// ユニット接触フラグ
        /// </summary>
        protected bool Reached { get; private set; } = false;

        #endregion property

        #region constructor

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="engine"></param>
        public FiniteStateMachineCharacterBase(IFiniteStateMachineGameClient engine)
        {
            Engine = engine;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// 位置更新
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
            Row = Y / Engine.UnitHeight;
            Col = X / Engine.UnitWidth;
            Reached = Y % Engine.UnitHeight == 0 && X % Engine.UnitWidth == 0;
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="graphics"></param>
        public abstract void Draw(Graphics graphics);

        /// <summary>
        /// 移動処理
        /// </summary>
        public abstract bool Move();

        /// <summary>
        /// ダメージ判定
        /// </summary>
        /// <returns></returns>
        public abstract bool IsDamage();

        /// <summary>
        /// ライフ増減
        /// </summary>
        /// <param name="count"></param>
        public void AddLife(int count)
        {
            Life += count;
        }

        #endregion method
    }
}