using Mov.Accessors;
using Mov.Accessors.Repository.Implement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Driver.Clients.Resas
{
    public class FileResasRepository : FileDomainRepositoryBase
    {
        public override string DomainPath => "analizer";

        public FileResasRepository(string endpoint, string fileDir, string extension, string encoding = SerializeConstants.ENCODE_NAME_UTF8)
            : base(endpoint, fileDir, extension, encoding)
        {

        }
    }
}
