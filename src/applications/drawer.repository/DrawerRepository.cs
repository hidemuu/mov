using Mov.Accessors;
using Mov.Drawer.Models;
using Mov.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Drawer.Repository
{
    public class DrawerRepository : DomainRepositoryBase, IDrawerRepository
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DrawerRepository(string dir, string extension, string encoding = SerializeConstants.ENCODE_NAME_UTF8) : base(extension)
        {
            DrawItems = new DbObjectRepository<DrawItem, DrawItemCollection>(dir, GetRelativePath("draw_item"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbObjectRepository<DrawItem> DrawItems { get; }

        #endregion プロパティ
    }
}
