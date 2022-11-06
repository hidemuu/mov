using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models
{
    /// <summary>
    /// 有限状態マシン（Finite State Machine）手法のゲームエンジン
    /// </summary>
    public interface IFsmGameEngine
    {
        #region プロパティ

        IGameService Service { get; }

        /// <summary>
        /// ユニット幅
        /// </summary>
        int UnitWidth { get; }
        /// <summary>
        /// ユニット高さ
        /// </summary>
        int UnitHeight { get; }
        /// <summary>
        /// 入力キーコード
        /// </summary>
        int KeyCode { get; set; }
        /// <summary>
        /// キャラクタ配列
        /// </summary>
        List<ICharacter> Characters { get; }
        /// <summary>
        /// 敵キャラ配列
        /// </summary>
        List<ICharacter> Aliens { get; }
        /// <summary>
        /// マップ情報
        /// </summary>
        int[,] Map { get; }
        

        #endregion プロパティ

        #region メソッド

        /// <summary>
        /// 初期化処理
        /// </summary>
        void Initialize();

        /// <summary>
        /// キャラクターソート
        /// </summary>
        /// <param name="order">描画順</param>
        void SortCharacters(int[] order);

        /// <summary>
        /// 壁判定
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool IsWall(int x, int y);

        /// <summary>
        /// 衝突検出
        /// </summary>
        /// <param name="targetCharacter">衝突判定キャラ</param>
        /// <param name="x">X位置</param>
        /// <param name="y">Y位置</param>
        /// <returns></returns>
        int GetCollision(ICharacter targetCharacter, int x, int y);

        #endregion メソッド
    }
}
