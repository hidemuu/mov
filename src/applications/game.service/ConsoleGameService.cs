using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Service
{
    public class ConsoleGameService : IGameService
    {
        public IGameRepository Repository { get; }

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ConsoleGameService(IGameRepository repository)
        {
            this.Repository = repository;
        }

        public void Run()
        {
            
        }
    }
}
