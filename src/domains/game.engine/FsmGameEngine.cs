using Mov.Game.Engine.Characters;
using Mov.Game.Models;
using Mov.Game.Models.Maps;
using System;
using System.Collections.Generic;

namespace Mov.Game.Engine
{
    /// <summary>
    /// 有限状態マシン（Finite State Machine）手法のゲームエンジン
    /// </summary>
    public class FsmGameEngine
    {
        #region 定数
        /// <summary>
        /// キー指定無
        /// </summary>
        public const int KEY_CODE_NONE = 0;
        /// <summary>
        /// 左キー
        /// </summary>
        public const int KEY_CODE_LEFT = 37;
        /// <summary>
        /// 右キー
        /// </summary>
        public const int KEY_CODE_RIGHT = 39;
        /// <summary>
        /// 上キー
        /// </summary>
        public const int KEY_CODE_UP = 38;
        /// <summary>
        /// 下キー
        /// </summary>
        public const int KEY_CODE_DOWN = 40;

        #endregion 定数

        #region フィールド

        /// <summary>
        /// 追跡パンくず
        /// </summary>
        private Breadcrumbs breadcrumbs;
        /// <summary>
        /// パンくず追跡使用
        /// </summary>
        private static bool isUseBreadcrumbs = true;

        #endregion フィールド

        #region プロパティ
        /// <summary>
        /// ユニット幅
        /// </summary>
        public int UnitWidth { get; private set; } = 40;
        /// <summary>
        /// ユニット高さ
        /// </summary>
        public int UnitHeight { get; private set; } = 40;
        /// <summary>
        /// 入力キーコード
        /// </summary>
        public int KeyCode { get; set; } = KEY_CODE_NONE;
        /// <summary>
        /// キャラクタ配列
        /// </summary>
        public List<CharacterBase> Characters { get; private set; }
        /// <summary>
        /// 敵キャラ配列
        /// </summary>
        public List<Alien> Aliens { get; private set; }
        /// <summary>
        /// マップ情報
        /// </summary>
        public int[,] Map { get; private set; }
        
        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public FsmGameEngine()
        {
            Characters = new List<CharacterBase>();
            Aliens = new List<Alien>();
        }

        #endregion コンストラクター

        #region メソッド

        /// <summary>
        /// 初期化処理
        /// </summary>
        public virtual void Initialize(Landmark landMark)
        {
            Map = GameMap.MakeMap(landMark);
            breadcrumbs = new Breadcrumbs(15, this, landMark.GetRow(), landMark.GetCol());
            Characters.Clear();
            Aliens.Clear();
            KeyCode = KEY_CODE_NONE;
            AddCharacters(Characters, Map);
            AddCharacters(Characters, breadcrumbs.breads);
            SortCharacters(new int[] { GameMap.WALL, GameMap.BREAD, GameMap.ALIEN, GameMap.PLAYER, GameMap.TREASURE });
        }

        /// <summary>
        /// キャラクターソート
        /// </summary>
        /// <param name="order">描画順</param>
        public void SortCharacters(int[] order)
        {
            var dic = new Dictionary<int, int>();
            var val = 0;
            foreach (var t in order)
            {
                dic.Add(t, val++);
            }
            Characters.Sort(delegate (CharacterBase x, CharacterBase y)
            {
                var dif = dic[x.TypeCode] - dic[y.TypeCode];
                if (dif > 0) return 1;
                else if (dif < 0) return -1;
                return 0;
            });
        }

        /// <summary>
        /// マップからキャラクターを追加
        /// </summary>
        /// <param name="characters"></param>
        /// <param name="map"></param>
        protected void AddCharacters(List<CharacterBase> characters, int[,] map)
        {
            var row = map.GetLength(0);
            var col = map.GetLength(1);
            for (var r = 0; r < row; r++)
            {
                for (var c = 0; c < col; c++)
                {
                    var type = map[r, c];
                    if (type != GameMap.ROAD)
                    {
                        var character = MakeCharacter(type);
                        character.SetPosition(c * UnitWidth, r * UnitHeight);
                        characters.Add(character);
                        if (type == GameMap.ALIEN)
                        {
                            Aliens.Add((Alien)character);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// キャラクターを追加
        /// </summary>
        /// <param name="characters"></param>
        /// <param name="targets"></param>
        protected void AddCharacters(List<CharacterBase> characters, CharacterBase[] targets)
        {
            foreach (var target in targets)
            {
                characters.Add(target);
            }
        }
        /// <summary>
        /// キャラクターを追加
        /// </summary>
        /// <param name="characters"></param>
        /// <param name="character"></param>
        protected void AddCharacters(List<CharacterBase> characters, CharacterBase character)
        {
            characters.Add(character);
        }
        /// <summary>
        /// キャラクターを生成
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected virtual CharacterBase MakeCharacter(int type)
        {
            switch (type)
            {
                case GameMap.WALL: return new Wall(this);
                case GameMap.PLAYER:
                    if (isUseBreadcrumbs) return new BreadPlayer(this, breadcrumbs);
                    else return new Player(this);
                case GameMap.ALIEN:
                    if (isUseBreadcrumbs) return new BreadAlien(this, breadcrumbs);
                    else return new Alien(this);
                case GameMap.TREASURE:
                    return new Treasure(this);
                default: return null;
            }
        }
        /// <summary>
        /// 壁判定
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsWall(int x, int y)
        {
            var row1 = y / UnitHeight;
            var col1 = x / UnitWidth;
            var row2 = (y + UnitHeight - 1) / UnitHeight;
            var col2 = (x + UnitWidth - 1) / UnitWidth;
            return Map[row1, col1] == GameMap.WALL ||
                   Map[row1, col2] == GameMap.WALL ||
                   Map[row2, col1] == GameMap.WALL ||
                   Map[row2, col2] == GameMap.WALL;
        }

        /// <summary>
        /// 衝突検出
        /// </summary>
        /// <param name="targetCharacter">衝突判定キャラ</param>
        /// <param name="x">X位置</param>
        /// <param name="y">Y位置</param>
        /// <returns></returns>
        public int GetCollision(CharacterBase targetCharacter, int x, int y)
        {
            foreach (var character in Characters)
            {
                switch (character.TypeCode)
                {
                    case GameMap.ALIEN:
                    case GameMap.PLAYER:
                        if (character != targetCharacter)
                        {
                            if (Math.Abs(character.X - x) < UnitWidth && Math.Abs(character.Y - y) < UnitHeight)
                            {
                                return character.TypeCode;
                            }
                        }
                        break;
                }
            }
            return GameMap.NONE;
        }

        #endregion メソッド
    }
}
