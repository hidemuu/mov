using Mov.Accessors;
using Mov.Accessors.Repository.Implement;
using Mov.Analizer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Repository
{
    public class FileResasRepository : FileDomainRepositoryBase, IAnalizerRepository
    {
        public override string DomainPath => "analizer";

        public FileResasRepository(string endpoint, string fileDir, string extension, string encoding = SerializeConstants.ENCODE_NAME_UTF8)
            : base(endpoint, fileDir, extension, encoding)
        {
            
        }
    }
}
