using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Service
{
    public class ConsoleGameService : IGameService
    {
        public IGameRepository Repository { get; }

        private IConsoleGame game;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ConsoleGameService(IGameRepository repository, IConsoleGame game)
        {
            this.Repository = repository;
            this.game = game;
        }

        public void Run()
        {
            this.game.Print();
        }
    }
}
