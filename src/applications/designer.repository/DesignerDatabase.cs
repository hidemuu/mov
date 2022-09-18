using Mov.Accessors;
using Mov.Accessors.Repository.Implement;
using Mov.BaseModel;
using Mov.Designer.Models;
using Mov.Designer.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository
{
    public class DesignerDatabase : FileDomainRepositoryCollection<IDesignerRepository, DesignerRepository>, IDesignerDatabase
    {
        public DesignerDatabase(string dir, string extension, string encode = SerializeConstants.ENCODE_NAME_UTF8) : base(dir, extension, encode)
        {

        }
    }
}
