using Mov.Accessors;
using Mov.Game.Models;
using Mov.Game.Models.interfaces;
using Mov.Game.Models.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Repository
{
    public class GameDatabase : DbObjectDatabaseBase, IGameDatabase
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public GameDatabase(string resourceDir, string extension, string encoding = DbConstants.ENCODE_NAME_UTF8) : base(resourceDir, extension)
        {
            Landmarks = new DbObjectRepository<Landmark, LandmarkCollection>(this.dir, GetRelativePath("landmark"), encoding);
            DrawItems = new DbObjectRepository<DrawItem, DrawItemCollection>(this.dir, GetRelativePath("draw_item"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public DbObjectRepository<Landmark, LandmarkCollection> Landmarks { get; }

        public DbObjectRepository<DrawItem, DrawItemCollection> DrawItems { get; }

        #endregion プロパティ
    }
}
