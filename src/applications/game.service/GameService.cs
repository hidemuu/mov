using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Game.Service
{
    public class GameService : IGameService
    {
        public IGameRepository Repository { get; }

        public bool IsGameOver { get; set; }

        public bool IsStageClear { get; set; }

        public int Score { get; set; }

        public int Level { get; set; } = 1;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public GameService(IGameRepository repository)
        {
            this.Repository = repository;
        }

        public void Run()
        {
            
        }

        public IEnumerable<int> GetLevels()
        {
            return this.Repository.Landmarks.Get().Select(x => x.Lv);
        }

        public Landmark GetLandmark()
        {
            return this.Repository.Landmarks.Get().FirstOrDefault(x => x.Lv == Level);
        }
    }
}
