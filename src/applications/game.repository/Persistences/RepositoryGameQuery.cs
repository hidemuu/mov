using Mov.Accessors;
using Mov.Game.Models;
using Mov.Game.Models.Persistences;
using Mov.Game.Repository.Persistences.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Repository.Persistences
{
    public class RepositoryGameQuery : IGameQuery
    {
        #region プロパティ

        public IPersistenceQuery<Landmark> Landmark { get; }

        #endregion プロパティ

        #region コンストラクター

        public RepositoryGameQuery(IGameRepository repository)
        {
            this.Landmark = new RepositoryLandmarkQuery(repository);
        }

        #endregion コンストラクター

    }
}
