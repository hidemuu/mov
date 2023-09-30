using Mov.Core.Stores;
using Mov.Core.Stores.Services.Commands.Deleters;
using Mov.Core.Stores.Services.Commands.Savers;
using Mov.Designer.Models.Entities;
using Mov.Designer.Models.Schemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Stores.Commands
{
    internal class DesignerContentDeleter : IDelete<DesignerContent>
    {
        private readonly IDesignerRepository _repository;

        public DesignerContentDeleter(IDesignerRepository repository)
        {
            _repository = repository;
        }

        public void Delete(DesignerContent entity)
        {
            //_repositoryDeleter.Delete(entity);
        }
    }
}
