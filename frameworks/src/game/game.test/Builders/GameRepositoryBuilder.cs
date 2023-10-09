using Moq;
using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Game.Models;
using Mov.Game.Models.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Game.Test.Builders
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

        #endregion method

    }
}
