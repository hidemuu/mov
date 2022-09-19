using Mov.Accessors;
using Mov.Accessors.Repository.Implement;
using Mov.BaseModel;
using Mov.Game.Models;
using Mov.Game.Models.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Repository
{
    public class FileGameRepository : FileDomainRepositoryBase, IGameRepository
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public FileGameRepository(string dir, string extension, string encoding = SerializeConstants.ENCODE_NAME_UTF8) : base(dir, extension, encoding)
        {
            Landmarks = new FileDbObjectRepository<Landmark, LandmarkCollection>(dir, GetRelativePath("landmark"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbObjectRepository<Landmark, LandmarkCollection> Landmarks { get; }

        #endregion プロパティ
    }
}
