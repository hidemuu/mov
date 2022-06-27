using Mov.Accessors;
using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Repository
{
    public class DrawItemRepository : DbObjectRepositoryBase<DrawItem, DrawItemCollection>
    {
        public DrawItemRepository(string path, string encoding = DbConstants.ENCODE_NAME_UTF8) : base(path, encoding)
        {

        }
    }
}
