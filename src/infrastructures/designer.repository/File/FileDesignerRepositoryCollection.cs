using Mov.Accessors.Repository.Implement;
using Mov.Designer.Models;
using Mov.Designer.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository.Implements
{
    public class FileDesignerRepositoryCollection
        : FileDomainRepositoryCollection<IDesignerRepository, FileDesignerRepository>, IDesignerRepositoryCollection
    {
        public FileDesignerRepositoryCollection(string endpoint, string extension) : base(endpoint, extension)
        {

        }
    }
}
