using Moq;
using Mov.Game.Engine;
using Mov.Game.Models;
using Mov.Game.Service;
using Mov.Game.Service.Graphic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Game.Test
{
    public class GameServiceBuilder
    {
        private readonly IGameFacade service;
        private readonly Mock<IFiniteStateMachineGameEngine> mockEngine;

        public GameServiceBuilder()
        {
            mockEngine = new Mock<IFiniteStateMachineGameEngine>();
            service = new GraphicGameService(mockEngine.Object);
        }

        public GameServiceBuilder WithEngineCalled()
        {
            mockEngine.Setup(r => r.GetLevels()).Returns(new int[] { 0,});
            return this;
        }

        public IGameFacade Build() => service;

    }
}
