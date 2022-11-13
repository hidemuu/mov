using Mov.Accessors;
using Mov.Game.Models;
using Mov.Game.Models.Persistences;
using Mov.Game.Repository.Persistences.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Repository.Persistences
{
    public class RepositoryGameCommand : IGameCommand
    {
        #region プロパティ

        public IPersistenceCommand<Landmark> Landmark { get; }

        #endregion プロパティ

        #region コンストラクター

        public RepositoryGameCommand(IGameRepository repository)
        {
            this.Landmark = new RepositoryLandmarkCommand(repository);
        }

        #endregion コンストラクター

    }
}
