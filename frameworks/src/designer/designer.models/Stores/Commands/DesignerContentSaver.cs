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
    internal class DesignerContentSaver : ISave<DesignerContent>
    {
        private readonly ISave<ContentSchema> _repositorySaver;

        public DesignerContentSaver(IDesignerRepository repository)
        {
            _repositorySaver = new DbRepositorySaver<ContentSchema, Guid>(repository.Contents);
        }

        public void Save(DesignerContent entity)
        {
            //_repositorySaver.Save(entity);
        }
    }
}
