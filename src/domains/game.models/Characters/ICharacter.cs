using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mov.Game.Models
{
    public interface ICharacter
    {
        #region プロパティ

        /// <summary>
        /// 種類
        /// </summary>
        int TypeCode { get; }

        /// <summary>
        /// 速度
        /// </summary>
        int Speed { get; }

        /// <summary>
        /// ライフ
        /// </summary>
        int Life { get; }

        /// <summary>
        /// X座標
        /// </summary>
        int X { get; }

        /// <summary>
        /// Y座標
        /// </summary>
        int Y { get; }

        #endregion プロパティ

        #region メソッド

        /// <summary>
        /// 位置更新
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void SetPosition(int x, int y);

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="graphics"></param>
        void Draw(Graphics graphics);

        /// <summary>
        /// 移動処理
        /// </summary>
        bool Move();

        /// <summary>
        /// ダメージ判定
        /// </summary>
        /// <returns></returns>
        bool IsDamage();

        /// <summary>
        /// ライフ増減
        /// </summary>
        /// <param name="count"></param>
        void AddLife(int count);

        #endregion メソッド

    }
}
