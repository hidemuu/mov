using Mov.Game.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models.Parameters
{
    public interface IGameParameter
    {
        IGameRepository Repository { get; }

        IGameCommand Command { get; }

        IGameQuery Query { get; }
    }
}
