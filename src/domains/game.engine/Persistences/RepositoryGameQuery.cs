using Mov.Accessors;
using Mov.Accessors.Crud.Persistence.Implement;
using Mov.Controllers;
using Mov.Game.Models;
using Mov.Game.Models.Entities.Schemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Engine.Persistences
{
    public class RepositoryGameQuery : IGameQuery
    {
        #region プロパティ

        public IPersistenceQuery<Landmark> Landmark { get; }

        #endregion プロパティ

        #region コンストラクター

        public RepositoryGameQuery(IGameRepository repository)
        {
            Landmark = new DbObjectRepositoryQuery<Landmark, LandmarkCollection>(repository.Landmarks);
        }

        #endregion コンストラクター

    }
}
