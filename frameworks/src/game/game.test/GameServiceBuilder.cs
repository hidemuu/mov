using Moq;
using Mov.Game.Controller.Graphic;
using Mov.Game.Models;
using Mov.Game.Service;

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
            mockEngine.Setup(r => r.GetLevels()).Returns(new int[] { 0, });
            return this;
        }

        public IGameFacade Build() => service;
    }
}