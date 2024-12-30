using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Core.Repositories.Services;
using Mov.Drawer.Models;
using Mov.Drawer.Models.Entities;
using System;
using System.IO;

namespace Mov.Drawer.Repository
{
    public class FileDrawerRepository : IDrawerRepository
    {
        private const string DOMAIN_PATH = "drawer";

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public FileDrawerRepository(string endpoint, FileType extension, EncodingValue encoding)
        {
            DrawItems = FileDbRepository<DrawItem, Guid>.Factory.Create(Path.Combine(endpoint, DOMAIN_PATH + "json"), extension, encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbRepository<DrawItem, Guid, DbRequestSchemaString> DrawItems { get; }

        #endregion プロパティ
    }
}