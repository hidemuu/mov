using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models
{
    public interface IGameContext
    {
        IGameRepository Repository { get; }

        IGameCommand Command { get; }

        IGameQuery Query { get; }
    }
}
