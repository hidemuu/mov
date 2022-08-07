using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models
{
    public interface IGameDatabase
    {
        IDictionary<string, IGameRepository> Repositories { get; }

        IGameRepository GetRepository(string dirName);
    }
}
