﻿using Mov.Accessors;
using Mov.Accessors.Crud.Persistence.Implement;
using Mov.Game.Models;
using Mov.Game.Models.Persistences;
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
            this.Landmark = new DbObjectRepositoryQuery<Landmark, LandmarkCollection>(repository.Landmarks);
        }

        #endregion コンストラクター

    }
}