using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Service
{
    public class GraphicGameService : IGameService
    {
        public IGameRepository Repository { get; }

        public bool IsGameOver { get; set; }

        public bool IsStageClear { get; set; }

        public int Score { get; set; }

        public int Level { get; set; } = 1;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public GraphicGameService(IGameRepository repository)
        {
            this.Repository = repository;
        }

        public void Run()
        {
            
        }
    }
}
