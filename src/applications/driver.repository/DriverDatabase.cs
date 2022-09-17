using Mov.Accessors;
using Mov.BaseModel;
using Mov.Driver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Repository
{
    public class DriverDatabase : DomainDatabaseBase<IDriverRepository, DriverRepository>, IDriverDatabase
    {
        public DriverDatabase(string dir, string extension, string encode = SerializeConstants.ENCODE_NAME_UTF8) : base(dir, extension, encode)
        {

        }
    }
}
