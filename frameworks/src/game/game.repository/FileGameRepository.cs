using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Services;
using Mov.Game.Models;
using Mov.Game.Models.Schemas;
using System;
using System.IO;

namespace Mov.Game.Repository
{
    public class FileGameRepository : IGameRepository
    {
        private const string DOMAIN_PATH = "game";

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public FileGameRepository(string endpoint, FileType extension, EncodingValue encoding)
        {
            Landmarks = FileDbRepository<LandmarkSchema, Guid>.Factory.Create(Path.Combine(endpoint, DOMAIN_PATH, "lamdmark.json"), extension, encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbRepository<LandmarkSchema, Guid> Landmarks { get; }

        #endregion プロパティ
    }
}