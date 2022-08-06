using Mov.Accessors;
using Mov.Drawer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Drawer.Repository
{
    public class DrawerDatabase : DbObjectDatabaseBase, IDrawerDatabase
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DrawerDatabase(string resourceDir, string extension, string encoding = DbConstants.ENCODE_NAME_UTF8) : base(resourceDir, extension)
        {
            DrawItems = new DbObjectRepository<DrawItem, DrawItemCollection>(this.dir, GetRelativePath("draw_item"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IRepository<DrawItem, DrawItemCollection> DrawItems { get; }

        #endregion プロパティ
    }
}
