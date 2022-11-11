using Mov.Game.Models;
using Mov.Game.Models.Parameters;
using Mov.Game.Models.Persistences;
using Mov.Game.Repository.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Repository
{
    public class GameParameter : IGameParameter
    {
        public IGameCommand Command { get; }

        public IGameQuery Query { get; }

        public GameParameter(IGameRepository repository)
        {
            this.Command = new GameCommand(repository);
            this.Query = new GameQuery(repository);
        }

        
    }
}
