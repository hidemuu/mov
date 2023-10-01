using Mov.Analizer.Service;
using Mov.Designer.Service;
using Mov.Framework;
using Mov.Game.Service;
using System;

namespace Mov.Suite.Facades
{
    public class EmptyMovFacade : IMovFacade
    {
        public IAnalizerFacade Analizer => throw new NotImplementedException();

        public IDesignerFacade Designer => throw new NotImplementedException();

        public IGameFacade Game => throw new NotImplementedException();
    }
}
