using Mov.Accessors;
using Mov.Controllers;
using Mov.Game.Models.Entities.Schemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models
{
    public interface IGameCommand
    {
        IPersistenceCommand<Landmark> Landmark { get; }
    }
}
