using Mov.Game.Models;
using Mov.Game.Models.Characters;
using Mov.Game.Models.Maps;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mov.Game.Engine
{
    /// <summary>
    /// 有限状態マシン（Finite State Machine）手法のゲームエンジン
    /// </summary>
    public class FiniteStateMachineGameEngine : IFiniteStateMachineGameEngine
    {   

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

        public IGameService Service { get; }
        /// <summary>
        /// マップ幅
        /// </summary>
        public int MapWidth { get; }
        /// <summary>
        /// マップ高さ
        /// </summary>
        public int MapHeight { get; }
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
        public int KeyCode { get; set; } = UtilityConstants.KEY_CODE_NONE;
        /// <summary>
        /// キャラクタ配列
        /// </summary>
        public List<ICharacter> Characters { get; private set; }
        /// <summary>
        /// 敵キャラ配列
        /// </summary>
        public List<ICharacter> Aliens { get; private set; }
        /// <summary>
        /// マップ情報
        /// </summary>
        public int[,] Map { get; private set; }
        
        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public FiniteStateMachineGameEngine(IGameService service)
        {
            this.Service = service;
            Characters = new List<ICharacter>();
            Aliens = new List<ICharacter>();
            var map = Service.GetLandmark();
            MapWidth = map.GetCol() * UnitWidth;
            MapHeight = map.GetRow() * UnitHeight;
        }

        #endregion コンストラクター

        #region メソッド

        /// <summary>
        /// 初期化処理
        /// </summary>
        public virtual void Initialize()
        {
            var landMark = Service.GetLandmark();
            Map = Map2D.MakeMap(landMark);
            breadcrumbs = new Breadcrumbs(15, this, landMark.GetRow(), landMark.GetCol());
            Characters.Clear();
            Aliens.Clear();
            KeyCode = UtilityConstants.KEY_CODE_NONE;
            AddCharacters(Characters, Map);
            AddCharacters(Characters, breadcrumbs.breads);
            SortCharacters(new int[] { (int)CharacterType.WALL, (int)CharacterType.BREAD, (int)CharacterType.ALIEN, (int)CharacterType.PLAYER, (int)CharacterType.TREASURE });
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
            Characters.Sort(delegate (ICharacter x, ICharacter y)
            {
                var dif = dic[(int)x.Type] - dic[(int)y.Type];
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
        protected void AddCharacters(List<ICharacter> characters, int[,] map)
        {
            var row = map.GetLength(0);
            var col = map.GetLength(1);
            for (var r = 0; r < row; r++)
            {
                for (var c = 0; c < col; c++)
                {
                    var type = map[r, c];
                    if (type != (int)CharacterType.ROAD)
                    {
                        var character = MakeCharacter(type);
                        character.SetPosition(c * UnitWidth, r * UnitHeight);
                        characters.Add(character);
                        if (type == (int)CharacterType.ALIEN)
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
        protected void AddCharacters(List<ICharacter> characters, ICharacter[] targets)
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
        protected void AddCharacters(List<ICharacter> characters, ICharacter character)
        {
            characters.Add(character);
        }
        /// <summary>
        /// キャラクターを生成
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected virtual ICharacter MakeCharacter(int type)
        {
            switch (type)
            {
                case (int)CharacterType.WALL: return new Wall(this);
                case (int)CharacterType.PLAYER:
                    if (isUseBreadcrumbs) return new BreadPlayer(this, breadcrumbs);
                    else return new Player(this);
                case (int)CharacterType.ALIEN:
                    if (isUseBreadcrumbs) return new BreadAlien(this, breadcrumbs);
                    else return new Alien(this);
                case (int)CharacterType.TREASURE:
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
            return Map[row1, col1] == (int)CharacterType.WALL ||
                   Map[row1, col2] == (int)CharacterType.WALL ||
                   Map[row2, col1] == (int)CharacterType.WALL ||
                   Map[row2, col2] == (int)CharacterType.WALL;
        }

        /// <summary>
        /// 衝突検出
        /// </summary>
        /// <param name="targetCharacter">衝突判定キャラ</param>
        /// <param name="x">X位置</param>
        /// <param name="y">Y位置</param>
        /// <returns></returns>
        public int GetCollision(ICharacter targetCharacter, int x, int y)
        {
            foreach (var character in Characters)
            {
                switch (character.Type)
                {
                    case CharacterType.ALIEN:
                    case CharacterType.PLAYER:
                        if (character != targetCharacter)
                        {
                            if (Math.Abs(character.X - x) < UnitWidth && Math.Abs(character.Y - y) < UnitHeight)
                            {
                                return (int)character.Type;
                            }
                        }
                        break;
                }
            }
            return (int)CharacterType.NONE;
        }

        /// <summary>
        /// ライフ取得
        /// </summary>
        /// <returns></returns>
        public int GetPlayerLife()
        {
            foreach (var character in this.Characters)
            {
                switch (character.Type)
                {
                    case CharacterType.PLAYER:
                        return character.Life;
                }
            }
            return (int)CharacterType.NONE;
        }

        #endregion メソッド
    }
}
