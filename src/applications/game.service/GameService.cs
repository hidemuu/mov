using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Service
{
    public class GameService : IGameService
    {
        public IGameRepository Repository { get; }

        /// <summary>
        /// コンストラクター
        /// </summary>
        public GameService(IGameRepository repository)
        {
            this.Repository = repository;
        }
    }
}
