using Mov.Accessors;
using Mov.Accessors.Repository.Implement;
using Mov.Drawer.Models;
using Mov.Schemas.EntityObjects.DbObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Drawer.Repository
{
    public class FileDrawerRepository : FileDomainRepositoryBase, IDrawerRepository
    {
        public override string DomainPath => "drawer";

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public FileDrawerRepository(string endpoint,  string fileDir, string extension, string encoding = SerializeConstants.ENCODE_NAME_UTF8) 
            : base(endpoint, fileDir, extension, encoding)
        {
            DrawItems = new FileDbObjectRepository<DrawItem, DrawItemCollection>(GetPath("draw_item"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbObjectRepository<DrawItem, DrawItemCollection> DrawItems { get; }

        #endregion プロパティ
    }
}
