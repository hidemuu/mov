using Mov.Core.Stores;
using Mov.Core.Stores.Services.Commands.Deleters;
using Mov.Core.Stores.Services.Commands.Savers;
using Mov.Designer.Models.Entities;
using Mov.Designer.Models.Schemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Stores
{
    public class DesignerContentDeleter : IDelete<DesignerContent, Guid>
    {
        private readonly IDelete<ContentSchema, Guid> _repositoryDeleter;


        public DesignerContentDeleter(IDesignerRepository repository) 
        {
            _repositoryDeleter = new DbRepositoryDeleter<ContentSchema, Guid>(repository.Contents);
        }

        public void Delete(DesignerContent entity)
        {
            //_repositoryDeleter.Delete(entity);
        }
    }
}
