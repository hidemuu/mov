using Mov.Controllers.Service;
using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Service
{
    public class GameService : RepositoryCommandService<IGameRepository>, IGameService
    {
        /// <summary>
        /// コンストラクター
        /// </summary>
        public GameService(IGameRepository repository) : base(repository, new GameCommandFactory())
        {
        }
    }
}
