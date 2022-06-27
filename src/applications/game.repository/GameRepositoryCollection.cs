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
            Landmarks = new LandmarkRepository(GetRepositoryPath("landmark"), encoding);
            DrawItems = new DrawItemRepository(GetRepositoryPath("draw_item"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public DbObjectRepositoryBase<Landmark, LandmarkCollection> Landmarks { get; }

        public DbObjectRepositoryBase<DrawItem, DrawItemCollection> DrawItems { get; }

        #endregion プロパティ
    }
}
