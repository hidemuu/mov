﻿using Mov.Accessors;
using Mov.Drawer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Drawer.Repository
{
    public class DrawerRepository : DbObjectRepositoryBase, IDrawerRepository
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DrawerRepository(string dir, string extension, string encoding = DbConstants.ENCODE_NAME_UTF8) : base(extension)
        {
            DrawItems = new DbObjectRepository<DrawItem, DrawItemCollection>(dir, GetRelativePath("draw_item"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbObjectRepository<DrawItem, DrawItemCollection> DrawItems { get; }

        #endregion プロパティ
    }
}