using Mov.Controllers.Service;
using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Service
{
    public class GameService : DomainService<IGameRepository>
    {
        /// <summary>
        /// コンストラクター
        /// </summary>
        public GameService(IGameRepository repository) : base(repository, new GameCommandFactory())
        {
        }
    }
}
