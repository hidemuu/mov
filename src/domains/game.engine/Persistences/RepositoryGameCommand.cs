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
    public class RepositoryGameCommand : IGameCommand
    {
        #region プロパティ

        public IPersistenceCommand<Landmark> Landmark { get; }

        #endregion プロパティ

        #region コンストラクター

        public RepositoryGameCommand(IGameRepository repository)
        {
            Landmark = new DbObjectRepositoryCommand<Landmark, LandmarkCollection>(repository.Landmarks);
        }

        #endregion コンストラクター

    }
}
