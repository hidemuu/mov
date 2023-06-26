using Mov.Analizer.Models;
using Mov.Designer.Models;
using Mov.Driver.Models;
using Mov.Game.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Framework
{
    public interface IMovService
    {
        IAnalizerFacade Analizer { get; }
        IDesignerFacade Designer { get; }
        IDriverFacade Driver { get; }
        IGameFacade Game { get; }
    }
}
