using System;
using System.Drawing;

namespace Mov.Game.Models.Characters
{
    /// <summary>
    /// キャラクター基本クラス
    /// </summary>
    public abstract class CharacterBase
    {
        
        #region 抽象プロパティ

        /// <summary>
        /// 種類
        /// </summary>
        public abstract int TypeCode { get; protected set; }
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
        
        #endregion

        #region プロパティ

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
        protected GameEngine GameEngine { get; private set; }
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

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="gameEngine"></param>
        public CharacterBase(GameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }

        #region メソッド

        /// <summary>
        /// 位置更新
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
            Row = Y / GameEngine.UnitHeight;
            Col = X / GameEngine.UnitWidth;
            Reached = Y % GameEngine.UnitHeight == 0 && X % GameEngine.UnitWidth == 0;
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

        #endregion

    }
}
