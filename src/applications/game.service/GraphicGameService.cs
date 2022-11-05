using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Service
{
    public class GraphicGameService : IGameService
    {
        public IGameRepository Repository { get; }

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
