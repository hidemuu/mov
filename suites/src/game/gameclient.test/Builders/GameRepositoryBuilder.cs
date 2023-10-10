using Moq;
using Mov.Core.Repositories;
using Mov.Game.Models;
using Mov.Game.Models.Schemas;

namespace Mov.Suite.GameClient.Test.Builders
{
    internal class GameRepositoryBuilder
    {
        #region field

        private readonly Mock<IGameRepository> _mockRepository;
        private readonly Mock<IDbRepository<LandmarkSchema, Guid>> _mockLandmark;

        #endregion field

        #region constructor

        public GameRepositoryBuilder()
        {
            _mockRepository = new Mock<IGameRepository>();
            _mockLandmark = new Mock<IDbRepository<LandmarkSchema, Guid>>();
        }

        #endregion constructor

        #region method

        public IGameRepository Build() => _mockRepository.Object;

        public GameRepositoryBuilder WithGetAsyncLandmark(IEnumerable<LandmarkSchema> landmarks)
        {
            _mockRepository.Setup(x => x.Landmarks.GetsAsync()).ReturnsAsync(landmarks);
            return this;
        }

        #endregion method
    }
}
