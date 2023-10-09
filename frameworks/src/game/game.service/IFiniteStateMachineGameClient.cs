using Mov.Game.Models.Entities;
using Mov.Game.Models.Schemas;
using System.Collections.Generic;

namespace Mov.Game.Service
{
    /// <summary>
    /// 有限状態マシン（Finite State Machine）手法のゲームエンジン
    /// </summary>
    public interface IFiniteStateMachineGameClient
    {
        #region property

        /// <summary>
        /// ゲームオーバー判定
        /// </summary>
        bool IsGameOver { get; set; }

        /// <summary>
        /// ステージクリア判定
        /// </summary>
        bool IsStageClear { get; set; }

        /// <summary>
        /// スコア
        /// </summary>
        int Score { get; set; }

        /// <summary>
        /// レベル
        /// </summary>
        int Level { get; set; }

        /// <summary>
        /// 画面幅
        /// </summary>
        int MapWidth { get; }

        /// <summary>
        /// 画面高さ
        /// </summary>
        int MapHeight { get; }

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

        #endregion property

        #region method

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

        /// <summary>
        /// ライフ取得
        /// </summary>
        /// <returns></returns>
        int GetPlayerLife();

        IEnumerable<int> GetLevels();

        LandmarkSchema GetLandmark();

        #endregion method
    }
}