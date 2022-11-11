using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models.Persistences
{
    public interface IGameCommand
    {
        IPersistenceCommand<Landmark> Landmark { get; }
    }
}
