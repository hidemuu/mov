﻿using Mov.Core;
using Mov.Core.Repositories.Repositories.Domains;

namespace Mov.Suite.Resas.Client
{
    public class FileResasRepository : FileDomainRepositoryBase
    {
        public override string DomainPath => "analizer";

        public FileResasRepository(string endpoint, string fileDir, string extension, string encoding = CoreConstants.ENCODE_NAME_UTF8)
            : base(endpoint, fileDir, extension, encoding)
        {
        }
    }
}