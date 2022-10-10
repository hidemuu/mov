using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models
{
    public interface IGameService
    {
        IGameRepository Repository { get; }

        void Run();
    }
}
