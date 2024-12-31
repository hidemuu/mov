using Moq;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Game.Models;
using Mov.Game.Models.Schemas;
using System;
using System.Collections.Generic;

namespace Mov.Game.Test.Builders
{
    internal class GameRepositoryBuilder
    {
        #region field

        private readonly Mock<IGameRepository> _mockRepository;
        private readonly Mock<IDbRepository<LandmarkSchema, Guid, DbRequestSchemaString>> _mockLandmark;

        #endregion field

        #region constructor

        public GameRepositoryBuilder()
        {
            _mockRepository = new Mock<IGameRepository>();
            _mockLandmark = new Mock<IDbRepository<LandmarkSchema, Guid, DbRequestSchemaString>>();
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
