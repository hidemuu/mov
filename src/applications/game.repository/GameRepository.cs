﻿using Mov.Accessors;
using Mov.Game.Models;
using Mov.Game.Models.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Repository
{
    public class GameRepository : DbObjectRepositoryBase, IGameRepository
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public GameRepository(string dir, string extension, string encoding = DbConstants.ENCODE_NAME_UTF8) : base(extension)
        {
            Landmarks = new DbObjectRepository<Landmark, LandmarkCollection>(dir, GetRelativePath("landmark"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbObjectRepository<Landmark, LandmarkCollection> Landmarks { get; }

        #endregion プロパティ
    }
}