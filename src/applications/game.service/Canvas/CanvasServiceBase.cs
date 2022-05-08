using Mov.Game.Models;
using Mov.Game.Models.Engines;
using Mov.Game.Models.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Service.Canvas
{
    public abstract class CanvasServiceBase : ICanvasService
    {
        #region プロパティ

        /// <summary>
        /// ゲームエンジン
        /// </summary>
        protected DrawGameEngine Engine { get; private set; }
        /// <summary>
        /// リポジトリ
        /// </summary>
        protected IGameRepositoryCollection Repository { get; private set; }

        #endregion プロパティ

        #region コンストラクター

        public CanvasServiceBase(IGameRepositoryCollection repository)
        {
            this.Repository = repository;
            this.Engine = new DrawGameEngine();
        }

        #endregion コンストラクター

        #region 抽象メソッド

        public abstract void Initialize();

        public abstract void Run();

        #endregion 抽象メソッド

    }
}
