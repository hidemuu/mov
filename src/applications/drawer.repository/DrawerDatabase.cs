﻿using Mov.Accessors;
using Mov.Drawer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Drawer.Repository
{
    public class DrawerDatabase : DbObjectDatabaseBase<IDrawerRepository, DrawerRepository>, IDrawerDatabase
    {
        public DrawerDatabase(string dir, string extension, string encode = DbConstants.ENCODE_NAME_UTF8) : base(dir, extension, encode)
        {

        }
    }
}