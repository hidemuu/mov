using Mov.Accessors;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models.Persistences
{
    public interface IGameQuery
    {
        IPersistenceQuery<Landmark> Landmark { get; }
    }
}
