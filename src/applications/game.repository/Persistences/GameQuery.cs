using Mov.Accessors;
using Mov.Game.Models;
using Mov.Game.Models.Persistences;
using Mov.Game.Repository.Persistences.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Repository.Persistences
{
    public class GameQuery : IGameQuery
    {
        #region プロパティ

        public IPersistenceQuery<Landmark> Landmark { get; }

        #endregion プロパティ

        #region コンストラクター

        public GameQuery(IGameRepository repository)
        {
            this.Landmark = new LandmarkQuery(repository);
        }

        #endregion コンストラクター

    }
}
