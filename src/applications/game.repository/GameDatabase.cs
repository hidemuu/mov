using Mov.Accessors;
using Mov.BaseModel;
using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Repository
{
    public class GameDatabase : DomainDatabaseBase<IGameRepository, GameRepository>, IGameDatabase
    {
        public GameDatabase(string dir, string extension, string encode = SerializeConstants.ENCODE_NAME_UTF8) : base(dir, extension, encode)
        {

        }
    }
}
