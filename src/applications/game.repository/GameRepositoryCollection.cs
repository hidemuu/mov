using Mov.Accessors;
using Mov.Accessors.Repository;
using Mov.Game.Models.interfaces;
using Mov.Game.Models.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Repository
{
    public class GameRepositoryCollection : FileRepositoryCollectionBase, IGameRepositoryCollection
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public GameRepositoryCollection(string resourceDir, string extension, string encoding = "utf-8") : base(resourceDir, extension)
        {
            Landmarks = new LandmarkRepository(GetRepositoryPath("landmark"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public FileRepositoryBase<Landmark, LandmarkCollection> Landmarks { get; }

        #endregion プロパティ
    }
}
