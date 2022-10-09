using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Service
{
    public class ActionGameService : IGameService
    {
        public IGameRepository Repository { get; }

        private IActionGame game;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ActionGameService(IGameRepository repository, IActionGame game)
        {
            this.Repository = repository;
            this.game = game;
        }
    }
}
