using Mov.Accessors;
using Mov.Accessors.Repository;
using Mov.Game.Models;
using Mov.Game.Models.interfaces;
using Mov.Game.Models.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Repository
{
    public class GameRepositoryCollection : DbObjectRepositoryCollectionBase, IGameRepositoryCollection
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public GameRepositoryCollection(string resourceDir, string extension, string encoding = DbConstants.ENCODE_NAME_UTF8) : base(resourceDir, extension)
        {
            Landmarks = new DbObjectRepository<Landmark, LandmarkCollection>(GetRepositoryPath("landmark"), encoding);
            DrawItems = new DbObjectRepository<DrawItem, DrawItemCollection>(GetRepositoryPath("draw_item"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public DbObjectRepository<Landmark, LandmarkCollection> Landmarks { get; }

        public DbObjectRepository<DrawItem, DrawItemCollection> DrawItems { get; }

        #endregion プロパティ
    }
}
