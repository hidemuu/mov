﻿using Mov.Accessors;
using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Repository
{
    public class GameDatabase : DbObjectDatabaseBase<IGameRepository, GameRepository>, IGameDatabase
    {
        public GameDatabase(string dir, string extension, string encode = DbConstants.ENCODE_NAME_UTF8) : base(dir, extension, encode)
        {

        }
    }
}