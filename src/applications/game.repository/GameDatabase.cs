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
        }

        #endregion コンストラクター

        #region プロパティ

        public IRepository<Landmark, LandmarkCollection> Landmarks { get; }

        #endregion プロパティ
    }
}
