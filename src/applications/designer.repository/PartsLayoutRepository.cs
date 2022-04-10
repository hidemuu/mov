using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository
{
    public class PartsLayoutRepository : FileRepositoryBase<PartsLayout, PartsLayoutCollection>
    {
        public PartsLayoutRepository(string path, string encoding = "utf-8") : base(path, encoding)
        {
        }

        #region メソッド

        
        #endregion
    }
}
