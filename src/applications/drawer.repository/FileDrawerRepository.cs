using Mov.Accessors;
using Mov.Accessors.Repository.Implement;
using Mov.BaseModel;
using Mov.Drawer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Drawer.Repository
{
    public class FileDrawerRepository : FileDomainRepositoryBase, IDrawerRepository
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public FileDrawerRepository(string dir, string extension, string encoding = SerializeConstants.ENCODE_NAME_UTF8) : base(dir, extension, encoding)
        {
            DrawItems = new FileDbObjectRepository<DrawItem, DrawItemCollection>(dir, GetRelativePath("draw_item"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbObjectRepository<DrawItem, DrawItemCollection> DrawItems { get; }

        #endregion プロパティ
    }
}
