using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Core.Repositories.Services;
using Mov.Game.Models;
using Mov.Game.Models.Schemas;
using System;
using System.IO;

namespace Mov.Game.Repository
{
    public class FileGameRepository : IGameRepository
    {

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        public FileGameRepository(string endpoint, FileType extension, EncodingValue encoding)
        {
            Landmarks = FileDbRepository<LandmarkSchema, Guid>.Factory.Create(Path.Combine(endpoint, "landmark.json"), extension, encoding);
        }

        #endregion constructor

        #region property

        public IDbRepository<LandmarkSchema, Guid, DbRequestSchemaString> Landmarks { get; }

        #endregion property
    }
}